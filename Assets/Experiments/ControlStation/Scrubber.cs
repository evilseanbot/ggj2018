using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Scrubber : MonoBehaviour {

	[System.Serializable]
	public class Effect
	{
		public bool on;
		public bool inverted;

		public Effect(bool newOn, bool newInverted) {
			on = newOn;
			newInverted = newInverted;
		}
	}

	public GameObject reciever;
	public UnityEngine.UI.Text instructionText;
	private bool on;
	private bool playerInZone;

	private float oldScrubPoint = 0;

	public Effect heartbeat;
	public Effect shiftingTexture;
    public Effect hue;
    public Effect bend;
    public Effect distortion;
    public Effect skybox;

	public List<Effect> dimensionEffectsList;
	Dictionary<Mutant.Dimension, Effect> dimensionEffects;

	// Use this for initialization
	void Start () {
		dimensionEffects = new Dictionary<Mutant.Dimension, Effect> ();
		int i = 0;
		foreach (Mutant.Dimension dimension in Enum.GetValues(typeof(Mutant.Dimension))) {
			if (dimension != Mutant.Dimension.none) {
				if (dimensionEffectsList.Count > i) {
					dimensionEffects.Add (dimension, new Effect (dimensionEffectsList [i].on, dimensionEffectsList [i].inverted));
				} else {
					dimensionEffects.Add (dimension, new Effect (false, false));
				}
			}
			i++;
		}		
	}
	
	// Update is called once per frame
	void Update () {
		if (on) {
			if (!playerInZone) {
				on = false;
				return;
			}

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

                if (hue.on)
                {
                    effectiveScrubPoint = GetEffectiveScrubPoint(scrubPoint, hue);
                    WorldMutation.instance.hue.hue = effectiveScrubPoint;
                }
                if (bend.on)
                {
                    effectiveScrubPoint = GetEffectiveScrubPoint(scrubPoint, bend);
                    WorldMutation.instance.bend.intensity = effectiveScrubPoint;
                }
                if (distortion.on)
                {
                    effectiveScrubPoint = GetEffectiveScrubPoint(scrubPoint, distortion);
                    WorldMutation.instance.distortion.intensity = effectiveScrubPoint;
                }
                if (skybox.on)
                {
                    effectiveScrubPoint = GetEffectiveScrubPoint(scrubPoint, skybox);
                    WorldMutation.instance.skybox.intensity = effectiveScrubPoint;
                }

				foreach (Mutant.Dimension dimension in Enum.GetValues(typeof(Mutant.Dimension))) {
					if (dimension != Mutant.Dimension.none) {
						if (dimensionEffects[dimension].on) {
							effectiveScrubPoint = GetEffectiveScrubPoint (scrubPoint, dimensionEffects[dimension]);
							WorldMutation.instance.dimension.dimensionData[dimension].value = effectiveScrubPoint;
						}
					}
				}		
					
				reciever.transform.position = Player.instance.transform.position + (Vector3.up * 0.8f) + (Player.instance.camera.transform.forward * 0.75f);

				oldScrubPoint = scrubPoint;
				WorldMutation.instance.CallOnScrubbed ();
			}
		}  

		if (Input.GetKeyDown ("e") && playerInZone) {
			on = !on;
		}

		if (playerInZone && !on) {
				instructionText.enabled = true;
		} else {
			instructionText.enabled = false;
		}
	}

	float GetEffectiveScrubPoint(float scrubPoint, Effect effect) {
		return effect.inverted ? scrubPoint : 1 - scrubPoint;
	}

	void OnTriggerEnter(Collider col) {
		if (col.GetComponent<Player> () != null) {
			playerInZone = true;
		}
	}

	void OnTriggerExit(Collider col) {
		if (col.GetComponent<Player> () != null) {
			playerInZone = false;
		}
	}
}
