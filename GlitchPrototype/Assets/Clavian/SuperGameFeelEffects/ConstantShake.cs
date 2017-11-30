//Copyright (c) 2016-2017 Kai Clavier [kaiclavier.com] Do Not Distribute
using UnityEngine;
using System.Collections;
[AddComponentMenu("Utility/Super Game Feel Effects/Constant Shake")]
public class ConstantShake : MonoBehaviour {
	private Transform t;
	private Vector3 lastShake;
	public Vector3 strength = Vector2.one;
	public float intensity = 1f;
	void Awake () {
		t = this.transform;
	}
	void Update () {
		t.localPosition -= lastShake;
		lastShake = new Vector3(Random.Range(-strength.x,strength.x) * intensity, 
								Random.Range(-strength.y,strength.y) * intensity, 
								Random.Range(-strength.z,strength.z) * intensity);
		t.localPosition += lastShake;
	}
}
