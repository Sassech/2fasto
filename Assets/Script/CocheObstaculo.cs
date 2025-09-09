using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CocheObstaculo : MonoBehaviour
{
    public GameObject cronometroGo;
    public Cronometro cronometroScript;

    public GameObject audioFXGo;
    public AudioFX audioFXScript;
    // Start is called before the first frame update
    void Start()
    {
        cronometroGo = GameObject.FindFirstObjectByType<Cronometro>().gameObject;
        cronometroScript = cronometroGo.GetComponent<Cronometro>();

        audioFXGo = GameObject.FindFirstObjectByType<AudioFX>().gameObject;
        audioFXScript = audioFXGo.GetComponent<AudioFX>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Coche>() != null)
        {
            audioFXScript.FXSonidoChoque();
            cronometroScript.tiempo = cronometroScript.tiempo - 20;
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
