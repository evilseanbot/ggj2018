using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldHue : MonoBehaviour {
    public float hue = 0;
    public Material material;
    private void Start()
    {
        Shader.SetGlobalFloat("_HueOffset", 0);
    }
    public void OnScrubbed() {
        Shader.SetGlobalFloat("_HueOffset", hue);
    }

}
