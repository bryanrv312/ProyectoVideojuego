using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenaCambio : MonoBehaviour {

	public void cambioEscena(string sc){
		SceneManager.LoadScene (sc);
	}

	public void nextEscena(){
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 1);
	}
}
