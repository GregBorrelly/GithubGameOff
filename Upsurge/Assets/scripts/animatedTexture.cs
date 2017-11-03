using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animatedTexture : MonoBehaviour {
	public Vector2 speed = Vector2.zero; 
	private Vector2 offset = Vector2.zero;
	private Material material; 


	// Use this for initialization
	void Start () {
		material = GetComponent<Renderer>().material;
		offset = material.GetTextureOffset("_MainTex");		
	}
	
	// Update is called once per frame
	void Update () {
		offset += speed * Time.deltaTime;
		material.SetTextureOffset("_MainTex", offset);
	}
}
