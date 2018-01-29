using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

	public List<string> lines;
	public UnityEngine.UI.Text text;

	private int currentLine = 0;
	bool playerInZone;
    public bool finalPerson = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (playerInZone) {
			if (Input.GetKeyDown (KeyCode.E)) {
				AdvanceLine ();
			}
		}
	}

	void AdvanceLine() {
		currentLine++;
		if (currentLine >= lines.Count) {
            if (finalPerson)
            {
                Application.Quit();
            }
			currentLine = 0;
		}
		text.text = lines [currentLine];
	}

	void OnTriggerEnter(Collider col) {
		Debug.Log ("Entering trigger");
		if (col.GetComponent<Player> () != null) {
			playerInZone = true;
			text.enabled = true;
			currentLine = 0;
			text.text = lines [currentLine];
		}
	}

	void OnTriggerExit(Collider col) {
		if (col.GetComponent<Player> () != null) {
			playerInZone = false;
			text.enabled = false;
		}
	}

}
