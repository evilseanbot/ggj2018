using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldShiftingTexture : MonoBehaviour {

	public float intensity = 0;
	public Material material;

	public void OnScrubbed () {
		material.color = new Color (1 - intensity, 1 - intensity, 1 - intensity);
		material.SetColor ("_EmissionColor", new Color (intensity, intensity, intensity));
	}
}
