using UnityEngine;
using System.Collections;

public class SGFEEnemy : MonoBehaviour {
	public float startingHealth = 3;
	public float health = 3;
	public float damageStopTime = 0.1f;
	public float dieStopTime = 1f;

	public Vector3 startPos;
	public Vector3 spawnOffset;
	public float spawnAnimSpeed = 1f;

	void SpawnNew(){
		SGFEEnemy newEnemy = Instantiate(this, startPos + spawnOffset, transform.rotation) as SGFEEnemy;

		newEnemy.health = startingHealth;
	}
	void Update(){
		transform.position = Vector3.MoveTowards(transform.position, startPos, Time.deltaTime * spawnAnimSpeed);
	}

	void OnCollisionEnter2D(Collision2D other){
		if(other.transform.name == "Bullet"){
			health--;
			Destroy(other.transform.gameObject);
			if(health <= 0f){
				Camera.main.Stop(dieStopTime);
				SpawnNew();
				Destroy(this.gameObject);
			}else{
				Camera.main.Stop(damageStopTime);
			}
		}
	}
}
