using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldMutation : MonoBehaviour {

	public delegate void ScrubAction();
	public static event ScrubAction OnScrubbed;

	public static WorldMutation instance;
	public WorldHeartbeat heartbeat;
	public WorldShiftingTexture shiftingTexture;
	public WorldDimension dimension;
	public Material shiftingMaterial;

	// Use this for initialization
	void Start () {
		instance = this;
		heartbeat = gameObject.AddComponent<WorldHeartbeat> ();
		shiftingTexture = gameObject.AddComponent<WorldShiftingTexture> ();
		dimension = gameObject.AddComponent<WorldDimension> ();

		shiftingTexture.material = shiftingMaterial;
		OnScrubbed += OnScrubbedProcedure;
	}

	public void CallOnScrubbed() {
		OnScrubbed();
	}

	public void OnScrubbedProcedure() {
		heartbeat.OnScrubbed ();
		shiftingTexture.OnScrubbed ();
		dimension.OnScrubbed ();
	}
}