using UnityEngine;
using System.Collections;

public class InstantVelocity : MonoBehaviour {

	public Vector2 velocity = Vector2.zero;
	private bool stop = false; 

	private Rigidbody2D body2d;

	void Awake(){
		body2d = GetComponent<Rigidbody2D> ();
	}

	void Update(){


		if (GameControl.instance.gameOver) {

			body2d.velocity =  new Vector2 (0,0);

		} else {
		
			body2d.velocity = velocity;

		}
	}

	void OnCollisionEnter2D (Collision2D col){

		if(col.gameObject.tag == "Player"){
			stop = true;
		}


	}
}
