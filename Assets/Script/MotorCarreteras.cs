using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotorCarreteras : MonoBehaviour
{
    public float velocidad;
    public bool inicioJuego;
    public bool juegoTerminado;

    public GameObject contenedorCallesGo;
    public GameObject[] contenedorCallesArray;

    int contadorCalles = 0;
    int numeroSelectorCalles;

    public GameObject calleAnterior;
    public GameObject calleNueva;

    public float tamañoCalle;

    public Vector3 medidadLimitePantalla;
    public bool salioDePantalla;

    public GameObject mCamGo;
    public Camera mCamComp;

    public GameObject cocheGo;
    public GameObject audioFXGo;
    public AudioFX audioFXScript;
    public GameObject bgFinalGo;

    // Start is called before the first frame update
    void Start()
    {
        InicioJuego();
    }

    void InicioJuego()
    {
        contenedorCallesGo = GameObject.Find("ContenedorCalles");
        mCamGo = GameObject.Find("MainCamera");
        mCamComp = mCamGo.GetComponent<Camera>();

        bgFinalGo = GameObject.Find("PanelGameOver");
        bgFinalGo.SetActive(false);

        audioFXGo = GameObject.Find("AudioFX");
        audioFXScript = audioFXGo.GetComponent<AudioFX>();

        cocheGo = GameObject.FindFirstObjectByType<Coche>().gameObject;

        VelocidadCarretera();
        MedirPantalla();
        BucoCalles();
    }

    public void juegoTerminadoEstados()
    {
        cocheGo.GetComponent<AudioSource>().Stop();
        audioFXScript.FXMusic();
        bgFinalGo.SetActive(true);
    }

    void BucoCalles()
    {
        contenedorCallesArray = GameObject.FindGameObjectsWithTag("Calle");
        for (int i = 0; i < contenedorCallesArray.Length; i++)
        {
            contenedorCallesArray[i].gameObject.transform.parent = contenedorCallesGo.transform;
            contenedorCallesArray[i].gameObject.SetActive(false);
            contenedorCallesArray[i].gameObject.name = "CalleOFF_" + i;
        }
        CrearCalles();
    }

    void CrearCalles()
    {
        contadorCalles++;
        numeroSelectorCalles = Random.Range(0, contenedorCallesArray.Length);
        GameObject Calle = Instantiate(contenedorCallesArray[numeroSelectorCalles]);
        Calle.SetActive(true);
        Calle.name = "Calle" + contadorCalles;
        Calle.transform.parent = gameObject.transform;
        PosicionoCalles();
    }

    void PosicionoCalles()
    {
        calleAnterior = GameObject.Find("Calle" + (contadorCalles - 1));
        calleNueva = GameObject.Find("Calle" + contadorCalles);
        MidoCalle();
        calleNueva.transform.position = new Vector3(calleAnterior.transform.position.x, calleAnterior.transform.position.y + tamañoCalle, 0);
        salioDePantalla = false;
    }

    void MidoCalle()
    {
        for (int i = 0; i < calleAnterior.transform.childCount; i++)
        {
            if (calleAnterior.transform.GetChild(i).gameObject.GetComponent<Pieza>() != null)
            {
                float tamañoPieza = calleAnterior.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().bounds.size.y;
                tamañoCalle = tamañoCalle + tamañoPieza;
            }
        }
    }

    void MedirPantalla()
    {
        medidadLimitePantalla = new Vector3(0, mCamComp.ScreenToWorldPoint(new Vector3(0, 0, 0)).y - 0.5f, 0);
    }

    void DestruyoCalles()
    {
        Destroy(calleAnterior);
        tamañoCalle = 0;
        calleAnterior = null;
        CrearCalles();
    }

    void VelocidadCarretera()
    {
        velocidad = 18;
    }
    // Update is called once per frame
    void Update()
    {
        if (inicioJuego == true && juegoTerminado == false)
        {
            transform.Translate(Vector3.down * velocidad * Time.deltaTime);
        }
        if (calleAnterior.transform.position.y + tamañoCalle < medidadLimitePantalla.y && salioDePantalla == false)
        {
            salioDePantalla = true;
            DestruyoCalles();
        }
    }
}