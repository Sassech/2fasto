using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuentaAtras : MonoBehaviour
{
    public GameObject motorCarreterasGo;
    public MotorCarreteras motorCarreterasScript;
    public Sprite[] numeros;
    public GameObject contadorNumerosGo;
    public SpriteRenderer contadorNumerosComp;

    public GameObject controladorCocheGo;
    public GameObject cocheGo;
    // Start is called before the first frame update
    void Start()
    {
        InicioComponentes();
    }

    void InicioComponentes()
    {
        motorCarreterasGo = GameObject.Find("MotorCarreteras");
        motorCarreterasScript = motorCarreterasGo.GetComponent<MotorCarreteras>();

        contadorNumerosGo = GameObject.Find("ContadorNumeros");
        contadorNumerosComp = contadorNumerosGo.GetComponent<SpriteRenderer>();

        cocheGo = GameObject.Find("Coche");
        controladorCocheGo = GameObject.Find("ControladorCoche");

        InicioCuentaAtras();
    }

    void InicioCuentaAtras()
    {
        StartCoroutine(Contando());
    }

    IEnumerator Contando()
    {
        controladorCocheGo.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(2);

        contadorNumerosComp.sprite = numeros[1];
        this.gameObject.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(1);

        contadorNumerosComp.sprite = numeros[2];
        this.gameObject.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(1);

        contadorNumerosComp.sprite = numeros[3];
        motorCarreterasScript.inicioJuego = true;
        contadorNumerosGo.GetComponent<AudioSource>().Play();
        cocheGo.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(2);

        contadorNumerosGo.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
