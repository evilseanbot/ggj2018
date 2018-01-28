using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldShiftingTexture : MonoBehaviour {

	private float offsetX;
	public float intensity = 0;
	public Material material;

	public void OnScrubbed () {
		material.color = new Color (1 - intensity, 1 - intensity, 1 - intensity);
		material.SetColor ("_EmissionColor", new Color (intensity, intensity, intensity));
	}

	void Update() {
		offsetX += 0.001f;
		material.SetTextureOffset ("_MainTex", new Vector3 (offsetX, 0));
	}
}
