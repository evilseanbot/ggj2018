using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrubber : MonoBehaviour {

	public GameObject reciever;
	public bool on;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (on) {
			float scrubPoint = Mathf.Sin (Player.instance.transform.rotation.eulerAngles.y / 30);
			Debug.Log (scrubPoint);

			WorldMutation.instance.heartbeat.bps = Mathf.Pow (10, scrubPoint);
			WorldMutation.instance.shiftingTexture.intensity = scrubPoint;
			WorldMutation.instance.dimensionA = scrubPoint;

			reciever.transform.position = Player.instance.transform.position + (Vector3.up * 0.8f) + (Player.instance.camera.transform.forward * 0.75f);
		} 

		if (Input.GetKeyDown ("e")) {
			on = !on;
		}
	}
}
