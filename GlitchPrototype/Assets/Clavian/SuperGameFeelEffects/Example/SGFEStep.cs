using UnityEngine;
using System.Collections;

public class SGFEStep : MonoBehaviour {
	public float shakeMulti;

	public void Step(){
		Camera.main.Shake(shakeMulti);
	}
}
