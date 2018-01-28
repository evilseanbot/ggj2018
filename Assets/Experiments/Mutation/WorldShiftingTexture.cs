using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldShiftingTexture : MonoBehaviour {

	public float intensity = 0;
	public Material material;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		material.color = new Color (1 - intensity, 1 - intensity, 1 - intensity);
		material.SetColor ("_EmissionColor", new Color (intensity, intensity, intensity));
	}
}
