using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class AnimatedPPP : MonoBehaviour {

	public PostProcessingProfile profile;
	public UnityEngine.UI.Text text;
	public UnityEngine.UI.Text pressText;
	public Camera camera;
	public bool done = false;

	// Use this for initialization
	void Start () {
		StartCoroutine ("Animation");
	}

	IEnumerator Animation() {
		for (float i = 0; i < 300; i++) {
			VignetteModel.Settings vignette = profile.vignette.settings;
			vignette.intensity = 1 - (i / 600);
			vignette.smoothness = 1 - ((i * 0.8f) / 300);
			profile.vignette.settings = vignette;

			GrainModel.Settings grain = profile.grain.settings;
			grain.intensity = (i / 300);
			profile.grain.settings = grain;

			MakeTitleTextBlink (i);
			MakeCameraFadeIn (i);
			MakePressTextAppear (i);

			//Debug.Log (i);
			yield return null;
		}
		done = true;
	}

	void MakeTitleTextBlink(float i) {
		if (i > 150) {
			if (i / 25 % 2 < 1) {
				text.enabled = false;
			} else {
				text.enabled = true;
			}
		}
	}

	void MakeCameraFadeIn(float i) {
		if (i < 50) {
			camera.backgroundColor = new Color(i / 100, i / 100, i / 100);
		}
	}

	void MakePressTextAppear(float i) {
		if (i == 299) {
			pressText.enabled = true;
		}
	}

	public void CallOutAnimation() {
		StartCoroutine ("OutAnimation");
	}

	IEnumerator OutAnimation() {
		for (float i = 300; i > 0; i--) {
			VignetteModel.Settings vignette = profile.vignette.settings;
			vignette.intensity = 1 - (i / 600);
			vignette.smoothness = 1 - ((i * 0.8f) / 300);
			profile.vignette.settings = vignette;

			GrainModel.Settings grain = profile.grain.settings;
			grain.intensity = (i / 300);
			profile.grain.settings = grain;

			MakeTitleTextDissappear (i);
			MakeCameraFadeIn (i);
			MakePressTextDissappear (i);

			//Debug.Log (i);
			yield return null;
		}
		done = true;
	}

	void MakeTitleTextDissappear(float i) {
		text.enabled = false;
	}

	void MakePressTextDissappear(float i) {
		pressText.enabled = false;
	}

}
