using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldDistortion : MonoBehaviour {
    public float intensity = 0;
    public Material material;
    private void Start()
    {
        Shader.SetGlobalFloat("_ScaleOffset", 0);
    }
    public void OnScrubbed() {
        Shader.SetGlobalFloat("_ScaleOffset", intensity);
    }

}
