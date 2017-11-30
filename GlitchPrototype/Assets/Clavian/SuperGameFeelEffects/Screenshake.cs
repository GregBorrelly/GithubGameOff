//Copyright (c) 2016-2017 Kai Clavier [kaiclavier.com] Do Not Distribute

using UnityEngine;
using System.Collections;
#if UNITY_EDITOR
using UnityEditor;

[CustomEditor(typeof(Screenshake))]
[CanEditMultipleObjects] //why not
public class ScreenshakeEditor : Editor{
	override public void OnInspectorGUI(){
		serializedObject.Update(); //for onvalidate stuff!
		SerializedProperty curve = serializedObject.FindProperty("curve");
		SerializedProperty intensity = serializedObject.FindProperty("intensity");
		SerializedProperty time = serializedObject.FindProperty("time");
		SerializedProperty roundDecimals = serializedObject.FindProperty("roundDecimals");
		SerializedProperty useLocalSpace = serializedObject.FindProperty("useLocalSpace");
		SerializedProperty strength = serializedObject.FindProperty("strength");
		EditorGUILayout.PropertyField(curve);
		EditorGUILayout.PropertyField(useLocalSpace);
		EditorGUILayout.PropertyField(strength);
		EditorGUILayout.PropertyField(intensity);
		EditorGUILayout.PropertyField(time);
		EditorGUILayout.PropertyField(roundDecimals);
		serializedObject.ApplyModifiedProperties();
	}
}
#endif
[AddComponentMenu("Utility/Super Game Feel Effects/Screenshake", 1)]
public class Screenshake : MonoBehaviour {
	private Transform _t;
	private Transform t{
		get{
			if(_t == null) _t = this.transform;
			return _t;
		}
	}
	private Coroutine c;
	private Vector3 lastMovement = Vector3.zero; //the amound of random shake done last frame
	
	public AnimationCurve curve = new AnimationCurve(new Keyframe(0f,1f,-1f,-1f), new Keyframe(1f,0f,-1f,-1f));
	public bool useLocalSpace = true;
	public Vector3 strength = Vector2.one;
	public float intensity = 1f; //default intensity
	public float time = 0.2f;
	[Range(0,7)]
	public int roundDecimals = 7;
	
	void OnValidate(){
		if(time < 0f){time = 0f;}
	}
	public void Shake(){ //call default 
		Shake(1f);
	}
	public void Shake(float multi){ //call default 
		if(c != null){
			StopCoroutine(c);
		}
		c = StartCoroutine(DoShake(multi));
	}
	IEnumerator DoShake (float multi) {
		float timer = 0f;
		while(timer < time){
			t.localPosition -= lastMovement; //move back
			Vector3 myStrength = new Vector3(curve.Evaluate(timer / time) * multi * intensity * strength.x,
									curve.Evaluate(timer / time) * multi * intensity * strength.y,
									curve.Evaluate(timer / time) * multi * intensity* strength.z);
			if(useLocalSpace){
				lastMovement = t.localRotation * new Vector3(Random.Range(-myStrength.x,myStrength.x), 
															Random.Range(-myStrength.y,myStrength.y), 
															Random.Range(-myStrength.z,myStrength.z));//relative to camera's rotation
			}else{
				lastMovement = new Vector3(Random.Range(-myStrength.x,myStrength.x), 
											Random.Range(-myStrength.y,myStrength.y), 
											Random.Range(-myStrength.z,myStrength.z));
			}
			if(roundDecimals != 7){
				lastMovement.x = (float)System.Math.Round(lastMovement.x, roundDecimals);
				lastMovement.y = (float)System.Math.Round(lastMovement.y, roundDecimals);
				lastMovement.z = (float)System.Math.Round(lastMovement.z, roundDecimals);
			}
			
			t.localPosition += lastMovement;
			
			timer += Time.unscaledDeltaTime; //count up using unscaled time.
			yield return null;
		}
		t.localPosition -= lastMovement; //move back
		lastMovement = Vector3.zero;
	}
}