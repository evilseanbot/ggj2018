using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldDistortion : MonoBehaviour {
    public float intensity = 0;
    public Material material;

    public void OnScrubbed() {
        Shader.SetGlobalFloat("_ScaleOffset", intensity);
    }

}
