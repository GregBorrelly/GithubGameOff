using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundTiles : MonoBehaviour {
	
	public int textureSize = 32;
	
	
	// Use this for initialization
	void Start () {
		var newWidth = Mathf.Ceil(Screen.width / (textureSize * cameraScaling.scale));
		var newHeight = Mathf.Ceil(Screen.height / (textureSize * cameraScaling.scale));

		transform.localScale = new Vector3 (newWidth * textureSize, newHeight *textureSize, 1);
		GetComponent<Renderer>().material.mainTextureScale = new Vector3(newWidth, newHeight,1); 
	}
	
	
}
