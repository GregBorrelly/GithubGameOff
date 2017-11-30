using UnityEngine;
using System.Collections;

public class CameraReflexNew : MonoBehaviour {
    OLDTVFilter3 _oldtvfilter;

    // Use this for initialization
    void Start() {
        _oldtvfilter = GetComponent<OLDTVFilter3>();

        string frontCam = WebCamTexture.devices[ 0 ].name;
        foreach ( WebCamDevice device in WebCamTexture.devices ) {
            if ( device.isFrontFacing ) {
                frontCam = device.name;
                break;
            }
        }

        Debug.Log( "Using " + frontCam + " as webcam" );
        WebCamTexture webcamTexture = new WebCamTexture( frontCam );

        // You can use any kind of texture as reflex, as your webcam or a render to texture
        _oldtvfilter.preset.tubeFilter.reflexPattern = webcamTexture;
        webcamTexture.Play();
    }
}
