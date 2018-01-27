using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldMutation : MonoBehaviour {

	public static WorldMutation instance;
	public WorldHeartbeat heartbeat;
	public WorldShiftingTexture shiftingTexture;

	// Use this for initialization
	void Start () {
		instance = this;
		heartbeat = gameObject.AddComponent<WorldHeartbeat> ();
		shiftingTexture = gameObject.AddComponent<WorldShiftingTexture> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
