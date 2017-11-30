using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {
    public Vector3 rotation = new Vector3( 10.0f, -15.0f, 7.5f );

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.Rotate( rotation * Time.deltaTime );
	}
}
