using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {

	public float walkingSpeed = 150f;
	public float jumpsLeft = 2;
	public bool glitchState = false; 


	static bool grounded = false; 

	//check if player is dead
	private bool isDead = false;
	private Rigidbody2D rb2d; 
	private float holdTime = 0f;
	public static float upforce = 900f; 
	private float move;
	public float maxSpeed;

	Animator myAnim; 

	//for shooting
	public Transform gunTip;
	public Transform gunTip2;
	public Transform gunTip3;
	public GameObject bullet; 
	public GameObject bullet2; 
	public GameObject bullet3; 

	float  fireRate = 0.5f;
	float 	nextfire = 0f;
	AudioSource PlayerAs;
	public AudioClip playerJumped; 

	public bool Reversegravity = false; 

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		myAnim = GetComponent<Animator> ();
		PlayerAs = GetComponent<AudioSource> ();

	
	}

	void Update(){



		if (Input.GetKeyDown("z")  ) 
		{


			PlayerAs.clip = playerJumped;
			PlayerAs.pitch = Random.Range(1f, 2f);
			PlayerAs.Play ();


				jumpsLeft -= 1;
				rb2d.velocity = Vector2.zero;
//				rb2d.velocity = new Vector2 (0,100);
				rb2d.AddForce (new Vector2(rb2d.velocity.x, upforce));
							



		}

		if (Input.GetKeyDown("x")){

			fireShuriken ();
//			glitchState = !glitchState;
//			Debug.Log (glitchState);
//			myAnim.SetBool ("defense", glitchState);



		}
//		if (Input.GetKeyDown("z")) {
//			myAnim.SetBool ("attack", true);
//		}
	}


	
	// Update is called once per frame
	void FixedUpdate () {


		if (isDead == false) {
			myAnim.SetBool ("attack", false);


//			move = Input.GetAxis ("Horizontal");
//			rb2d.velocity = new Vector2 (move*maxSpeed, rb2d.velocity.y);

		
		



//			if (Input.GetAxis ("Horizontal") > 0.001) {
//
//				rb2d.velocity = Vector2.zero;
//				rb2d.AddForce (new Vector2 (walkingSpeed, 0));
//
//			} else if (Input.GetAxis ("Horizontal") < -0.001) {
//
//				rb2d.velocity = Vector2.zero;
//				rb2d.AddForce (new Vector2 (-walkingSpeed, 0));
//
//			}

//			else if (Input.GetAxis ("Vertical") > 0.001) {
//				
//				rb2d.velocity = Vector2.zero;
//				rb2d.AddForce (new Vector2 (0, upforce));
//
//			}


//			else if (Input.GetAxis ("Vertical") < -0.001) {
//				// This is down
//
//				rb2d.velocity = Vector2.zero;
//				rb2d.AddForce (new Vector2 (0, -upforce));
//
//			} else {
//				
//			
//
//			}

	


		}
			
	}

	void OnCollisionExit2D(Collision2D col){
		if (col.gameObject.tag == "ground") {

			myAnim.SetBool ("defense", true);
			grounded = false;
			jumpsLeft -= 1;


		}
	
	}
	void OnCollisionEnter2D (Collision2D col){
		Debug.Log (col.gameObject.name);
		if (col.gameObject.tag == "ground") {
			Camera.main.Kick(Vector3.up, 0.2f);

			myAnim.SetBool ("defense", false);



		}
		if(col.gameObject.tag == "enemy"  ){
			isDead = true;
			GameControl.instance.PlayerDied ();	
			rb2d.transform.localScale = new Vector3 (5,6,0);

			myAnim.SetBool ("die", true);
			Camera.main.Shake(4f);
			Destroy (this.gameObject, 0.6f);
			}

		if(col.gameObject.name == "one(Clone)"){
			Destroy(col.gameObject);
			GameControl.instance.playerScore ();

		}
		if (col.gameObject.name == "zero(Clone)" ) {
			isDead = true;
			GameControl.instance.PlayerDied ();
		} else {
			grounded = true; 
			jumpsLeft = 2;
		}
	
	}

	void fireShuriken(){
	
		if (Time.time > nextfire) {
			
			nextfire = Time.time + fireRate;
			Instantiate (bullet, gunTip.position, Quaternion.Euler(new Vector3(0,0,0)));
			Instantiate (bullet2, gunTip2.position, Quaternion.Euler(new Vector3(0,0,0)));
			Instantiate (bullet3, gunTip3.position, Quaternion.Euler(new Vector3(0,0,0)));



		}
	}
}
