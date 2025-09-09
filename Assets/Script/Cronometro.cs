using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cronometro : MonoBehaviour
{
    public GameObject motorCarreterasGo;
    public MotorCarreteras motorCarreterasScript;

    public float tiempo;
    public float distancia;
    public Text txtTiempo;
    public Text txtDistancia;
    public Text txtDistanciaFinal;

    // Start is called before the first frame update
    void Start()
    {
        motorCarreterasGo = GameObject.Find("MotorCarreteras");
        motorCarreterasScript = motorCarreterasGo.GetComponent<MotorCarreteras>();

        txtTiempo.text = "2:00";
        txtDistancia.text = "0";

        tiempo = 120;
    }

    void CalculoTiempoDistancia()
    {
        distancia+=Time.deltaTime*motorCarreterasScript.velocidad;

        txtDistancia.text = ((int)distancia).ToString();

        tiempo-=Time.deltaTime;
        int minutos = (int)tiempo/60;
        int segundos = (int)tiempo%60;

        txtTiempo.text = minutos.ToString() + ":" + segundos.ToString().PadLeft(2, '0');
    }

    // Update is called once per frame
    void Update()
    {
        if(motorCarreterasScript.inicioJuego == true && motorCarreterasScript.juegoTerminado == false)
        {
            CalculoTiempoDistancia();
        }

        if(tiempo <= 0 && motorCarreterasScript.juegoTerminado == false)
        {
            motorCarreterasScript.juegoTerminado = true;
            motorCarreterasScript.juegoTerminadoEstados();
            txtDistanciaFinal.text = ((int)distancia).ToString() + " mts";
            txtTiempo.text = "0:00";
        }
    }
}
