using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class landMine : MonoBehaviour {

	Animator mineAnim; 
	public bool destroyObject;
	private Rigidbody2D landMineBody;
	public AudioClip explosionClip;
	private AudioSource source;

	void Awake(){
		source = GetComponent<AudioSource> ();
	}
	// Use this for initialization
	void Start () {
		mineAnim = GetComponent<Animator> ();
		landMineBody = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(destroyObject){
			Destroy (this.gameObject);
		}

	}

	void OnCollisionEnter2D (Collision2D col){

		if(col.gameObject.name == "Glitch"){
			source.PlayOneShot(explosionClip);
			mineAnim.SetBool ("explode", true);	
			landMineBody.transform.position = new Vector3 (landMineBody.transform.position.x,landMineBody.transform.position.y + 8.5f, 0);
			landMineBody.transform.localScale = new Vector3 (5,6,0);
		}

		if (col.gameObject.tag == "shuriken") {
	
			Destroy (col.gameObject);
		}
	}


}


