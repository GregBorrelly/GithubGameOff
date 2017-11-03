using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScaling : MonoBehaviour {

	public static float pixelToUnits =1f;
	public static float scale = 1f; 
	public Vector2 nativeResolution = new Vector2(240,160);

	// Use this for initialization
	void  Awake () {
		// Reference the camera
		var camera= GetComponent<Camera>();
		
		if(camera.orthographic){
			scale = Screen.height/nativeResolution.y;
			pixelToUnits *= scale;
			camera.orthographicSize = (Screen.height / 2.0f)/pixelToUnits;
		}		
	}
	

}
