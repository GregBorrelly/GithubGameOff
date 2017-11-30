using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour {
	public float speed= 0.2f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (GameControl.instance.gameOver == false) {
			Vector2 offset = new Vector2 (Time.time * speed, 0);
			GetComponent<Renderer>().material.mainTextureOffset = offset;﻿
		}

	}
}
