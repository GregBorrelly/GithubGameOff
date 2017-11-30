//Copyright (c) 2016-2017 Kai Clavier [kaiclavier.com] Do Not Distribute
using UnityEngine;
using System.Collections;
//Allows you to call transform.GetComponent<Camera>().Screenshake();
//instead of transform.GetComponent<Screenshake>().Shake();
public static class SuperGameFeelEffectsExtentions {

	public static void Shake (this Camera cam) {
		Screenshake shake = cam.transform.GetComponent<Screenshake>();
		if(shake != null){
			shake.Shake();
		}else{
			Debug.Log("Camera doesn't have Screenshake component, adding one!");
			cam.transform.gameObject.AddComponent<Screenshake>().Shake(); //add and shake
		}
	}
	public static void Shake (this Camera cam, float multi) {
		Screenshake shake = cam.transform.GetComponent<Screenshake>();
		if(shake != null){
			shake.Shake(multi);
		}else{
			Debug.Log("Camera doesn't have Screenshake component, adding one!");
			cam.transform.gameObject.AddComponent<Screenshake>().Shake(multi); //add and shake
		}
	}
	
	public static void Kick (this Camera cam, Vector3 dir) {
		Kickback kick = cam.transform.GetComponent<Kickback>();
		if(kick != null){
			kick.Kick(dir);
		}else{
			Debug.Log("Camera doesn't have Kickback component, adding one!");
			cam.transform.gameObject.AddComponent<Kickback>().Kick(dir); //add and shake
		}
	}
	public static void Kick (this Camera cam, Vector3 dir, float multi) {
		Kickback kick = cam.transform.GetComponent<Kickback>();
		if(kick != null){
			kick.Kick(dir, multi);
		}else{
			Debug.Log("Camera doesn't have Kickback component, adding one!");
			cam.transform.gameObject.AddComponent<Kickback>().Kick(dir, multi); //add and shake
		}
	}

	public static void Stop (this Camera cam){
		Hitstop stop = cam.transform.GetComponent<Hitstop>();
		if(stop != null){
			stop.Stop();
		}else{
			Debug.Log("Camera doesn't have Hitstop component, adding one!");
			cam.transform.gameObject.AddComponent<Hitstop>().Stop(); //add and stop
		}
	}
	public static void Stop (this Camera cam, float multi){
		Hitstop stop = cam.transform.GetComponent<Hitstop>();
		if(stop != null){
			stop.Stop(multi);
		}else{
			Debug.Log("Camera doesn't have Hitstop component, adding one!");
			cam.transform.gameObject.AddComponent<Hitstop>().Stop(multi); //add and stop
		}
	}

}