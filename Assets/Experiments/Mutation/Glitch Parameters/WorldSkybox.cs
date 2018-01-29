using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldSkybox : MonoBehaviour {

    public float intensity = 0;

    public void Start()
    {
        RenderSettings.skybox.SetColor("_Color", new Color(0, 0, 0));
    }

    public void OnScrubbed()
    {
        float powIntensity = Mathf.Clamp01(Mathf.Pow(intensity, 5));
        RenderSettings.skybox.SetColor("_Color", new Color(powIntensity, powIntensity, powIntensity));
    }
}
