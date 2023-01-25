using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scamera : MonoBehaviour {


	public Transform target;
	public float Speed;
	public Vector3 PCamera;


	private void FixedUpdate(){
		
		Vector3 Dposition = target.position + PCamera;
		Vector3 Sposition = Vector3.Lerp (transform.position, Dposition, Speed * Time.deltaTime );

		transform.position = Sposition;
	}


}
