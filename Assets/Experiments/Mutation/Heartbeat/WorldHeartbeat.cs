using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldHeartbeat : MonoBehaviour {

	public float bps = 1;
	public float size = 0.1f;
	public float scaleMod;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		scaleMod = (1-(size/2)) + (Mathf.Sin(Time.time * bps) * size);
	}
}
