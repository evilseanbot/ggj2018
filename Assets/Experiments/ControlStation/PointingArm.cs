using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointingArm : MonoBehaviour {

	public GameObject armBase;
	public GameObject arm;
	public GameObject target;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt (target.transform.position);
		arm.transform.localScale = new Vector3 (0.5f, 0.5f, Vector3.Distance (armBase.transform.position, target.transform.position) * 20);
	}
}
