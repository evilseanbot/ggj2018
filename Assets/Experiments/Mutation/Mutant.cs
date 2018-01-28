using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mutant : MonoBehaviour {
	public bool dimensional = false;
	public Dimension dimension = Dimension.none;

	public enum Dimension {A, B, C, none};

	// Use this for initialization
	void Start () {
		WorldMutation.OnScrubbed += OnScrubbed;
		if (dimensional) {
			WorldMutation.OnDimensionalEnter += OnDimensionalEnter;
			WorldMutation.OnDimensionalExit += OnDimensionalExit;
		}
	}
	
	void OnScrubbed() {
		Debug.Log ("A scrub has happened");

		//Heartbeat effect
		transform.localScale = Vector3.one * WorldMutation.instance.heartbeat.scaleMod;
	}

	void OnDimensionalEnter(Dimension dimensionEntered) {
		Debug.Log("On dimensional enter");
		Debug.Log (dimensionEntered);
		if (dimension == dimensionEntered) {
			GetComponent<Renderer> ().enabled = true;
		}
	}

	void OnDimensionalExit(Dimension dimensionExited) {
		Debug.Log("On dimensional exit");
		if (dimension == dimensionExited) {
			GetComponent<Renderer> ().enabled = false;
		}
	}
}
