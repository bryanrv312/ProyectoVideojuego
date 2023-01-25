using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    int hp = 3;
    public Image[] imgcorazones;
    bool hascooldown = false;//para q no se nos acabe la vida inmediatamente al golpear algo

    public ScenaCambio cambioscena;

    void OnCollisionEnter2D(Collision2D col)
    {


        Debug.Log("Choco con : " + col.gameObject.tag);

        if (col.gameObject.CompareTag("PisoMaton"))
        {
            restarVida2();

        }

        if (col.gameObject.CompareTag("Picos"))
        {
            restarVida();

        }


        if (col.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("me golpeo enemy");

            if (GetComponent<PlayerMovement>().enPiso)
            {
                restarVida();
            }
        }
    }


    void restarVida()
    {//restar la vida
        if (!hascooldown)
        {//ver si tiene cooldown
            if (hp > 0)
            {
                hp--;
                Debug.Log("hp = " + hp);
                hascooldown = true;

                StartCoroutine(cooldown());
            }

            if (hp <= 0)
            {//ver si la vida es menor a 0
                cambioscena.cambioEscena("EscenaFin");
            }
            //actualiza los corazones
            vaciarCorazon();//checar q los corazones se vacien
        }
    }
    //agregado, cuando cae al vacio
    void restarVida2()
    {//restar la vida
        if (!hascooldown)
        {//ver si tiene cooldown

            cambioscena.cambioEscena("EscenaFin");
            vaciarCorazon();//checar q los corazones se vacien
        }
    }

    public void CogerVida()
    {
        if (hp < 3)
        {
            hp++;

            for(int i = 0; i < imgcorazones.Length; i++)
            {
                if(hp -1 == i)
                {
                    imgcorazones[i].gameObject.SetActive(true);
                }
            }

        }
    }

    void vaciarCorazon()
    {
        for (int i = 0; i < imgcorazones.Length; i++)
        {
            if (hp - 1 < i)
            {
                imgcorazones[i].gameObject.SetActive(false);
            }
        }
    }


    IEnumerator cooldown()
    {//despues de 5seg se vuelve falso
        yield return new WaitForSeconds(.5f);
        hascooldown = false;

        StopCoroutine(cooldown());
    }

}
