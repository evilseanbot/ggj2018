using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldHue : MonoBehaviour {
    public float hue = 0;
    public Material material;

    public void OnScrubbed() {
        Shader.SetGlobalFloat("_HueOffset", hue);
    }

}
