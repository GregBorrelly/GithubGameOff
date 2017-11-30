//Copyright (c) 2016-2017 Kai Clavier [kaiclavier.com] Do Not Distribute
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SGFEPlayer : MonoBehaviour {
	[Header("Effect Multipliers")]
	public float shakeMulti = 1f;
	public float kickMulti = 1f;
	//public float stopMulti = 1f;

	[Header("Variables")]
	public float moveSpeed = 5f;
	public float jumpVelocity = 10f;
	public float bulletVelocity = 10f;
	public float kickbackVelocity = 1f;

	[Header("Transforms")]
	public Transform pivot;
	public Vector3 additionalRotation;
	public Rigidbody2D rb;
	public SGFEBullet bulletPrefab;
	public Animator anim;
	public Transform bulletSpawn; //bullets are spawned here
	

	void Update () {
		Vector3 rawInput = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0f);
		float mag = rawInput.magnitude;
		mag = Mathf.Clamp01(mag);
		Vector3 input = rawInput.normalized * mag;
/*
		if(mag > 0f){
			pivot.LookAt(pivot.position + rawInput);
			pivot.Rotate(additionalRotation);
		}
*/
		
		if(Input.GetKeyDown(KeyCode.Space)){
			Jump();
		}
		
		if(Input.GetKeyDown(KeyCode.Z)){
			Attack();
		}
		if(Input.GetKeyDown(KeyCode.R)){
			Reset();
		}
		transform.position += Vector3.Scale(input, Vector3.right) * moveSpeed * Time.deltaTime;
		anim.SetFloat("MoveSpeed", mag);
		if(input.x != 0f) anim.SetBool("FacingRight", input.x > 0f);
	}
	void OnCollisionEnter2D(Collision2D other){
		/*
		if(other.contacts[0].point.y <= pivot.position.y){
			Camera.main.Shake(shakeMulti);
		}
		*/
		if(other.transform.position.y <= pivot.position.y){
			Camera.main.Shake(shakeMulti);
		}
	}
	void Jump(){
		rb.velocity = new Vector2(rb.velocity.x, jumpVelocity);
		Camera.main.Kick(Vector3.up, kickMulti);
	}
	void Attack(){
		//fire a bullet
		anim.SetTrigger("Shoot");
		SGFEBullet newBullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletPrefab.transform.rotation) as SGFEBullet;
		newBullet.transform.name = "Bullet";
		newBullet.rb.velocity = Vector3.Scale(transform.localScale, Vector3.right) * bulletVelocity;
		newBullet.sr.flipX = transform.localScale.x < 0f;
		Camera.main.Kick(Vector3.Scale(transform.localScale, Vector3.right), kickMulti); //kick in direction plater is facing
		rb.velocity += new Vector2(-transform.localScale.x * kickbackVelocity, 0f);
	}
	void Reset(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}