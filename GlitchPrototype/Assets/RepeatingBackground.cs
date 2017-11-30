using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour {
	private BoxCollider2D groundCollider;
	private float groundHorizontalLength;

	// Use this for initialization
	void Start () 
	{
		groundCollider = GetComponent<BoxCollider2D> ();
		groundHorizontalLength = groundCollider.size.x; 
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (transform.position.x);
		if (transform.position.x < -groundHorizontalLength) {

			repositionBackground ();
		
		}
	}

	private void repositionBackground()
	{
		Vector2 groundOffSet = new Vector2 (groundHorizontalLength * 1f, 0);
		transform.position = (Vector2)transform.position + groundOffSet;
	}
}
