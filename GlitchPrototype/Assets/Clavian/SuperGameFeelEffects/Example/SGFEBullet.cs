using UnityEngine;
using System.Collections;

public class SGFEBullet : MonoBehaviour {
	private float spawnTime;
	public float aliveTime;
	public Rigidbody2D rb;
	public SpriteRenderer sr;
	
	void Start () {
		spawnTime = Time.time;
	}
	
	void Update () {
		if(Time.time > spawnTime + aliveTime){
			Destroy(this.gameObject);
		}
	}
}
