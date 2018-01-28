using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mutant : MonoBehaviour {
	public bool dimensional = false;

	// Use this for initialization
	void Start () {
		gameObject.AddComponent<Heartbeat> ();	
	}
	
	// Update is called once per frame
	void Update () {
		if (dimensional) {
			if (WorldMutation.instance.dimensionA > 0.75f) {
				GetComponent<Renderer> ().enabled = true;
			} else {
				GetComponent<Renderer> ().enabled = false;
			}
		}
	}
}
