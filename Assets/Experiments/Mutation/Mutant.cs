using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mutant : MonoBehaviour {
	public bool dimensional = false;
	public Dimension dimension = Dimension.none;
	public bool prop = false;

	public enum Dimension {A, B, C, none};

	// Use this for initialization
	void Start () {
		WorldMutation.OnScrubbed += OnScrubbed;
		if (dimensional) {
			WorldDimension.OnDimensionalEnter += OnDimensionalEnter;
			WorldDimension.OnDimensionalExit += OnDimensionalExit;
		}
	}

	void OnScrubbed() {
		//Debug.Log ("A scrub has happened");
	}

	void Update() {
		//Heartbeat effect
		if (prop) {
			transform.localScale = Vector3.one * WorldMutation.instance.heartbeat.scaleMod;
		}
	}

	void OnDimensionalEnter(Dimension dimensionEntered) {
		//Debug.Log("On dimensional enter");
		if (dimension == dimensionEntered) {
			GetComponent<Renderer> ().enabled = true;
		}
	}

	void OnDimensionalExit(Dimension dimensionExited) {
		//Debug.Log("On dimensional exit");
		if (dimension == dimensionExited) {
			GetComponent<Renderer> ().enabled = false;
		}
	}
}