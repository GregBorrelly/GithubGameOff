//Copyright (c) 2016 Kai Clavier [kaiclavier.com] Do Not Distribute
using UnityEngine;
using System.Collections;
#if UNITY_EDITOR
using UnityEditor;

[CustomEditor(typeof(Kickback))]
[CanEditMultipleObjects] //why not
public class KickbackEditor : Editor{
	override public void OnInspectorGUI(){
		serializedObject.Update(); //for onvalidate stuff!
		SerializedProperty curve = serializedObject.FindProperty("curve");
		SerializedProperty intensity = serializedObject.FindProperty("intensity");
		SerializedProperty time = serializedObject.FindProperty("time");
		SerializedProperty roundDecimals = serializedObject.FindProperty("roundDecimals");
		SerializedProperty useLocalSpace = serializedObject.FindProperty("useLocalSpace");
		EditorGUILayout.PropertyField(curve);
		EditorGUILayout.PropertyField(useLocalSpace);
		EditorGUILayout.PropertyField(intensity);
		EditorGUILayout.PropertyField(time);
		EditorGUILayout.PropertyField(roundDecimals);
		serializedObject.ApplyModifiedProperties();
	}
}
#endif
[AddComponentMenu("Utility/Super Game Feel Effects/Kickback", 1)]
public class Kickback : MonoBehaviour {
	private Transform _t;
	private Transform t{
		get{
			if(_t == null) _t = this.transform;
			return _t;
		}
	}
	private Coroutine c;
	private Vector3 lastMovement;
	
	public AnimationCurve curve = new AnimationCurve(new Keyframe(0f,1f,-1f,-1f), new Keyframe(1f,0f,-1f,-1f));
	public bool useLocalSpace = false;
	public float intensity = 0.5f; //default intensity
	public float time = 0.1f;
	[Range(0,7)]
	public int roundDecimals = 7;
	
	void OnValidate(){
		if(time < 0f){time = 0f;}
	}
	public void Kick(Vector3 dir){ //call default 
		Kick(dir,1f);
	}
	public void Kick(Vector3 dir, float multi){ //call default 
		if(c != null){
			StopCoroutine(c);
		}
		c = StartCoroutine(DoKick(dir, multi));
	}
	IEnumerator DoKick (Vector3 dir, float multi) {
		float timer = 0f;
		while(timer < time){
			t.localPosition -= lastMovement; //move back
			float myStrength = curve.Evaluate(timer / time) * multi * intensity;
			if(useLocalSpace){
				lastMovement = t.localRotation * dir.normalized * myStrength;//relative to camera's rotation
			}else{
				lastMovement = dir.normalized * myStrength;
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