using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coleccionable : MonoBehaviour
{
    public PlayerHealth VidaJugador;
    public ETipoColeccionable TipoColeccionable;
    public static int cant = 0;//separar los obj y q sea la misma para los demas
                               //public Text cantText;  //error en canvas, debe estar en no publico y obtener el componente
    Text cantText;

    ParticleSystem particulas;//particulas
    AudioSource sonido;

    public enum ETipoColeccionable
    {
        Rombo,
        Vida
    }

    void Start()
    {
        cant = 0;//para el sgt nivel o al reiniciar

        cantText = GameObject.Find("ColeccionableCantidadText").GetComponent<Text>();
        particulas = GameObject.Find("ColeccionableParticula").GetComponent<ParticleSystem>();
        //sonido = GameObject.Find("ColeccionableParticula").GetComponent<AudioSource>();
        sonido = GetComponentInParent<AudioSource>();

    }


    void Update()
    {

    }




    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.tag == "Player")
        {



            if (TipoColeccionable == ETipoColeccionable.Rombo)
            {
                particulas.transform.position = transform.position;
                particulas.Play();//para q la particula se ejecute
                sonido.Play();
                gameObject.SetActive(false);
                cant++;
                cantText.text = cant.ToString();
            }
            else
            {
                particulas.transform.position = transform.position;
                particulas.Play();//para q la particula se ejecute
                sonido.Play();
                gameObject.SetActive(false);


                Debug.Log("Agarro vida");
                VidaJugador.CogerVida();
            }
        }
    }

}
