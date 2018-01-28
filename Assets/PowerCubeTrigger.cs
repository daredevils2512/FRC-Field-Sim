using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerCubeTrigger : MonoBehaviour {
	public bool isTriggered;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerStay(Collider other) {
		if (other.tag == "Power Cube") {
			isTriggered = true;
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.tag == "Power Cube") {
			isTriggered = false;
		}
	}
}
