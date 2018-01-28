using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldMutation : MonoBehaviour {

	public delegate void ScrubAction();
	public static event ScrubAction OnScrubbed;

	public delegate void DimensionalEnterAction (Mutant.Dimension dimension);
	public static event DimensionalEnterAction OnDimensionalEnter;
	public delegate void DimensionalExitAction (Mutant.Dimension dimension);
	public static event DimensionalExitAction OnDimensionalExit;

	public static WorldMutation instance;
	public WorldHeartbeat heartbeat;
	public WorldShiftingTexture shiftingTexture;
	public Material shiftingMaterial;
	public float dimensionA;
	public float dimensionB;
	public float dimensionC;
	public bool dimensionAActive = false;
	public bool dimensionBActive = false;
	public bool dimensionCActive = false;
	private float dimensionalThreshold = 0.75f;

	// Use this for initialization
	void Start () {
		instance = this;
		heartbeat = gameObject.AddComponent<WorldHeartbeat> ();
		shiftingTexture = gameObject.AddComponent<WorldShiftingTexture> ();
		shiftingTexture.material = shiftingMaterial;
		OnScrubbed += OnScrubbedProcedure;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void CallOnScrubbed() {
		OnScrubbed();
	}
		
	public void OnScrubbedProcedure() {
		if (dimensionA > dimensionalThreshold && !dimensionAActive) {
			dimensionAActive = true;
			OnDimensionalEnter (Mutant.Dimension.A);
		}

		if (dimensionA <= dimensionalThreshold && dimensionAActive) {
			dimensionAActive = false;
			OnDimensionalExit (Mutant.Dimension.A);
		}
	}
}
