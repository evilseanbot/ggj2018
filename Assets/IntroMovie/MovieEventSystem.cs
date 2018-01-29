using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovieEventSystem : MonoBehaviour {

	public AnimatedPPP anim;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (anim.done && Input.anyKeyDown) {
			anim.CallOutAnimation ();
			Invoke ("StartGame", 5);
		}
	}

	void StartGame() {
		Debug.Log ("Game would be started here");
		SceneManager.LoadScene ("main");
	}
}
