using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingObject : MonoBehaviour {
	public float speed = -2f;
	private Rigidbody2D rb2d;
	public bool slowDownTime = false;

	// Use this for initialization
	void Start () {

		if (slowDownTime) {
			rb2d = GetComponent<Rigidbody2D> ();
			rb2d.velocity = new Vector2( 0, 0);
		} else {
			rb2d = GetComponent<Rigidbody2D> ();
			rb2d.velocity = new Vector2( 0,0);
		}




	}

	// Update is called once per frame
	void Update () {
		if (GameControl.instance.gameOver == true) {
			rb2d.velocity = Vector2.zero;
		}
	}


}
