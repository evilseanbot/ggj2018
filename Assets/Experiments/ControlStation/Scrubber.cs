using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrubber : MonoBehaviour {

	[System.Serializable]
	public class Effect
	{
		public bool on;
		public bool inverted;
	}

	public GameObject reciever;
	private bool on;
	private float oldScrubPoint = 0;

	public Effect heartbeat;
	public Effect shiftingTexture;
	public Effect dimensionA;
	public Effect dimensionB;
	public Effect dimensionC;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (on) {
			float scrubPoint = 0.5f + (Mathf.Sin (Player.instance.transform.rotation.eulerAngles.y / 30) / 2);

			if (scrubPoint != oldScrubPoint) {
				float effectiveScrubPoint;

				if (heartbeat.on) {
					effectiveScrubPoint = GetEffectiveScrubPoint (scrubPoint, heartbeat);
					WorldMutation.instance.heartbeat.bps = Mathf.Pow (10, effectiveScrubPoint);
				}

				if (shiftingTexture.on) {
					effectiveScrubPoint = GetEffectiveScrubPoint (scrubPoint, shiftingTexture);
					WorldMutation.instance.shiftingTexture.intensity = effectiveScrubPoint;
				}

				if (dimensionA.on) {
					effectiveScrubPoint = GetEffectiveScrubPoint (scrubPoint, dimensionA);
					WorldMutation.instance.dimension.dimensionA = effectiveScrubPoint;
				}

				if (dimensionB.on) {
					effectiveScrubPoint = GetEffectiveScrubPoint (scrubPoint, dimensionB);
					WorldMutation.instance.dimension.dimensionB = effectiveScrubPoint;
				}

				if (dimensionC.on) {
					effectiveScrubPoint = GetEffectiveScrubPoint (scrubPoint, dimensionC);
					WorldMutation.instance.dimension.dimensionC = effectiveScrubPoint;
				}

					
				reciever.transform.position = Player.instance.transform.position + (Vector3.up * 0.8f) + (Player.instance.camera.transform.forward * 0.75f);

				oldScrubPoint = scrubPoint;
				WorldMutation.instance.CallOnScrubbed ();
			}
		} 

		if (Input.GetKeyDown ("e")) {
			on = !on;
		}
	}

	float GetEffectiveScrubPoint(float scrubPoint, Effect effect) {
		return effect.inverted ? scrubPoint : 1 - scrubPoint;
	}
}
