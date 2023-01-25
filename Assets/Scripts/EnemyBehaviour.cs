using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {
	

	Rigidbody2D enemyRb;
	SpriteRenderer enemySrenderer;
	Animator enemyAnim;

	ParticleSystem particulas;
	AudioSource sonidoMuerte;

	float timeBeforeChange;
	public float delay = .8f;
	public float speed = .5f;



	// Use this for initialization
	void Start () {

		particulas = GameObject.Find ("EnemyParticula").GetComponent<ParticleSystem> ();
		sonidoMuerte = GameObject.Find("Enemies").GetComponent<AudioSource> ();

		enemyRb = GetComponent <Rigidbody2D> (); 
		enemySrenderer = GetComponent<SpriteRenderer> ();
		enemyAnim = GetComponent<Animator> ();
		
	}
	
	// Update is called once per frame
	void Update () {

		enemyRb.velocity = Vector2.right * speed;


		if(speed < 0){
			enemySrenderer.flipX = true;
		}else if( speed > 0){
			enemySrenderer.flipX = false;
		}

		if(timeBeforeChange < Time.time){
			speed *= -1;
			timeBeforeChange = Time.time + delay;
		}
	}


	void OnCollisionEnter2D(Collision2D collision){
		if(collision.gameObject.tag == "Player"){
			//Debug.Log ("ME TOCO");
			if(transform.position.y + .03f < collision.transform.position.y){
				enemyAnim.SetBool ("isDead",true);
			}
		}
	}

	public void DisableEnemy(){
		gameObject.SetActive (false);
		//Destroy (GameObject);

		particulas.transform.position = transform.position;
		particulas.Play ();
		sonidoMuerte.Play ();

	}

}
