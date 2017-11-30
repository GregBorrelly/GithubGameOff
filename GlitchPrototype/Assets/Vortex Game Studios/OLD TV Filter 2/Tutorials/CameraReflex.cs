using UnityEngine;
using System.Collections;

public class CameraReflex : MonoBehaviour {
    OLDTVTube _oldtvtube;

	// Use this for initialization
	void Start () {
        _oldtvtube = GetComponent<OLDTVTube>();

        string frontCam = WebCamTexture.devices[0].name;
        foreach ( WebCamDevice device in WebCamTexture.devices ) {
            if ( device.isFrontFacing ) {
                frontCam = device.name;
                break;
            }
        }

        Debug.Log( "Using " + frontCam + " as webcam" );
        WebCamTexture webcamTexture = new WebCamTexture( frontCam );

        // You can use any kind of texture as reflex, as your webcam or a render to texture
        _oldtvtube.reflex = webcamTexture;
        webcamTexture.Play();
	}
}
