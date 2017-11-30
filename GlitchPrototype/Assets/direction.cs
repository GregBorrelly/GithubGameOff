using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class direction : MonoBehaviour {
	private Rigidbody2D zero; 
	public int forceSideway;
	public int forceDownwards;



	// Use this for initialization
	void Start () {
		zero = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {


				
			zero.velocity = Vector2.zero;
			zero.AddForce (new Vector2(forceSideway, forceDownwards));


	}

	void OnCollisionEnter2D (Collision2D col){
		
		Destroy(this.gameObject);
	}
}