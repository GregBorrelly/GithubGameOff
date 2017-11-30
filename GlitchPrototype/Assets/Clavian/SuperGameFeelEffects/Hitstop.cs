//Copyright (c) 2017 Kai Clavier [kaiclavier.com] Do Not Distribute
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
[CustomEditor(typeof(Hitstop))]
[CanEditMultipleObjects] //why not
public class HitstopEditor : Editor{
	override public void OnInspectorGUI(){
		serializedObject.Update(); //for onvalidate stuff!
		SerializedProperty time = serializedObject.FindProperty("time");
		SerializedProperty curve = serializedObject.FindProperty("curve");
		EditorGUILayout.PropertyField(time);
		EditorGUILayout.PropertyField(curve);
		serializedObject.ApplyModifiedProperties();
	}
}
#endif
[AddComponentMenu("Utility/Super Game Feel Effects/Hitstop", 1)]
public class Hitstop : MonoBehaviour {
	private Transform t;
	private Coroutine c;
	public float time = 1f;
	public AnimationCurve curve = new AnimationCurve(new Keyframe(0f,0f,0f,0f), new Keyframe(1f,0f,0f,0f));
	private float oldTimescale;
	void OnValidate(){
		if(time < 0f){time = 0f;}
	}
	public void Stop () {
		Stop(1f);
	}
	public void Stop (float multi) {
		if(c != null){
			Time.timeScale = oldTimescale;
			StopCoroutine(c);
		}
		c = StartCoroutine(DoStop(multi));
	}
	IEnumerator DoStop(float multi){
		oldTimescale = Time.timeScale;
		float timer = 0f;
		while(timer < multi * time){
			Time.timeScale = curve.Evaluate(timer / multi * time);
			timer += Time.unscaledDeltaTime;
			yield return null;
		}
		Time.timeScale = oldTimescale;
	}
}
