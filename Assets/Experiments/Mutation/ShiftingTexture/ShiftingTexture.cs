using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShiftingTexture : MonoBehaviour {

	private float offsetX;
	public Material material;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		offsetX += 0.001f;
		material.SetTextureOffset ("_MainTex", new Vector3 (offsetX, 0));
	}
}
