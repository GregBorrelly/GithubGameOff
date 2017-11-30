using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gem : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D (Collision2D col){

		if (col.gameObject.name == "Glitch") {
			GameControl.instance.playerDoubleScore();
			Destroy(this.gameObject);



		}

	}
}
