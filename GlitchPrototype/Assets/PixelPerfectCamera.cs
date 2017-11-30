using UnityEngine;
using System.Collections;

public class PixelPerfectCamera : MonoBehaviour {

	public static float pixelsToUnits = 1f;
	public static float scale = 1f;
	public static bool runOnce = true;

	public Vector2 nativeResolution = new Vector2 (240, 160);

	void Start () {
		var camera = GetComponent<Camera> ();

		if (camera.orthographic && runOnce) {
			scale = Screen.height/nativeResolution.y;
			pixelsToUnits *= scale;
			camera.orthographicSize = (Screen.height / 2.0f) / pixelsToUnits;
			runOnce = false;
		}
	}



}
