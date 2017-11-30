using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class startGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if ( Input.anyKey ) {

			SceneManager.LoadScene("Main");

			//			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
		} 

	}
}
