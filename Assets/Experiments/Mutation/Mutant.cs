using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mutant : MonoBehaviour {
	public bool dimensional = false;
	public Dimension dimension = Dimension.none;
	public bool prop = false;

	public enum Dimension {A, B, C, D, E, F, G, H, I, J, none};

	// Use this for initialization
	void Start () {
		WorldMutation.OnScrubbed += OnScrubbed;
		if (dimensional) {
			WorldDimension.OnDimensionalEnter += OnDimensionalEnter;
			WorldDimension.OnDimensionalExit += OnDimensionalExit;
            if (dimension != Dimension.A)
            {
                TurnOff();
            }
		}
	}

	void OnScrubbed() {
		//Debug.Log ("A scrub has happened");
	}

	/*void Update() {
		//Heartbeat effect
		if (prop) {
			transform.localScale = Vector3.one * WorldMutation.instance.heartbeat.scaleMod;
		}
	}*/

	void OnDimensionalEnter(Dimension dimensionEntered) {
        //Debug.Log("On dimensional enter");
        gameObject.active = true;

        if (dimension == dimensionEntered) {
            if (GetComponent<Renderer>())
            {
                GetComponent<Renderer>().enabled = true;
            }
            if (GetComponent<AudioSource>())
            {
                GetComponent<AudioSource>().enabled = true;
            }
            if (GetComponent<Collider>())
            {
                GetComponent<Collider>().enabled = true;
            }
            if (GetComponent<Light>())
            {
                GetComponent<Light>().enabled = true;
            }
        }
	}

	void OnDimensionalExit(Dimension dimensionExited) {
		//Debug.Log("On dimensional exit");
		if (dimension == dimensionExited) {
            TurnOff();
        }
	}

    void TurnOff()
    {
        if (GetComponent<Renderer>()) {
            GetComponent<Renderer>().enabled = false;
        }
        if (GetComponent<AudioSource>())
        {
            GetComponent<AudioSource>().enabled = false;
        }
        if (GetComponent<Collider>())
        {
            GetComponent<Collider>().enabled = false;
        }
        if (GetComponent<Light>())
        {
            GetComponent<Light>().enabled = false;
        }

        gameObject.active = false;

    }
}