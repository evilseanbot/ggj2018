using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldBend : MonoBehaviour {
    public float intensity = 0;
    public Material material;

    public void OnScrubbed() {
        Shader.SetGlobalFloat("_BendOffset", intensity);
    }

}
