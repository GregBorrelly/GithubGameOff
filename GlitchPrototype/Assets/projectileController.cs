using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileController : MonoBehaviour {
	Rigidbody2D myRB;
	public float speedShuriken;
	Vector3 targetPosition; 
	Vector3 lookAtTarget;
	Quaternion playerRot;

	void Awake(){
		myRB = GetComponent<Rigidbody2D> ();
		myRB.AddForce (new Vector2(1,0)* speedShuriken, ForceMode2D.Impulse);
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		myRB.AddForce (new Vector2(1,0)* speedShuriken, ForceMode2D.Impulse);


	
	}


}
