using System;
using UnityEngine;

[RequireComponent( typeof( Camera ) )]
[AddComponentMenu( "" )]
public class FilterBehavior : MonoBehaviour {
	/// Provides a shader property that is set in the inspector
	/// and a material instantiated from the shader
	public Shader shader;
	private Material _Material;

	protected virtual void Start() {
		// Disable if we don't support image effects
		if ( !SystemInfo.supportsImageEffects ) {
			enabled = false;
			return;
		}

		// Disable the image effect if the shader can't
		// run on the users graphics card
		if ( !shader || !shader.isSupported )
			enabled = false;
	}


	protected Material material {
		get {
			if ( _Material == null ) {
				_Material = new Material( shader );
				_Material.hideFlags = HideFlags.HideAndDontSave;
			}
			return _Material;
		}
	}


	protected virtual void OnDisable() {
		if ( _Material ) {
			DestroyImmediate( _Material );
		}
	}
}