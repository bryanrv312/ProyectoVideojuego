using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour {

	public ScenaCambio change;
	public string NombreScena;

	void OnTriggerEnter2D(Collider2D col){

		Debug.Log(col.tag);

		if(col.tag == "Player"){
			//change.cambioEscena ("SecondLevel");
			//LEVEL2
			change.cambioEscena(NombreScena);
		}
	}
}
