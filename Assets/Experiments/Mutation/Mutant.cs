using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mutant : MonoBehaviour {

	// Use this for initialization
	void Start () {
		gameObject.AddComponent<Heartbeat> ();	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
