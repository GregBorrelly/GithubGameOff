using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

	Animator myAnim; 
	private Rigidbody2D rb2d; 
	public bool stop = false;
	AudioSource PlayerAs;
	public AudioClip playerScored; 



	float originalY;

	public float floatStrength = 1f; // You can change this in the Unity Editor to 
	// change the range of y positions that are possible.


	// Use this for initialization
	void Start () {
		myAnim = GetComponent<Animator> ();
		rb2d = GetComponent<Rigidbody2D> ();
		PlayerAs = GetComponent<AudioSource> ();
		this.originalY = this.transform.position.y;

	}
	
	// Update is called once per frame
	void Update () {

		rb2d.transform.position = new Vector3(transform.position.x,
			originalY + ((float)Mathf.Sin(Time.time * 2f) * floatStrength),
			transform.position.z);



		if(stop){
			rb2d.velocity =  new Vector2 (0,0);

		}
	}

	void OnCollisionEnter2D (Collision2D col){
		Debug.Log (col.gameObject.name);
		if (col.gameObject.tag == "shuriken") {
			Camera.main.Shake(0.6f);

			PlayerAs.clip = playerScored;
			PlayerAs.pitch = Random.Range(0.5f, 1.5f);
			PlayerAs.Play ();
			stop = true;
			myAnim.SetBool ("explode", true);
			this.gameObject.transform.position = new Vector3 (this.gameObject.transform.position.x,this.gameObject.transform.position.y + 8.5f, 0);

			Destroy (this.gameObject, 0.5f);
			Destroy (col.gameObject);


		}



		if(col.gameObject.name == "Glitch"){
			

		}

	}
}
