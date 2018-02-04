using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaultStuff : MonoBehaviour {
	public string alliance;
	public PowerCubeTrigger forceTrigger1;
	public PowerCubeTrigger forceTrigger2;
	public PowerCubeTrigger forceTrigger3;
	public Light forceLight1;
	public Light forceLight2;
	public Light forceLight3;
	public Light forceLight4;
	public Light forceLight5;

	public PowerCubeTrigger levitateTrigger1;
	public PowerCubeTrigger levitateTrigger2;
	public PowerCubeTrigger levitateTrigger3;
	public Light levitateLight1;
	public Light levitateLight2;
	public Light levitateLight3;
	public Light levitateLight4;
	public Light levitateLight5;

	public PowerCubeTrigger boostTrigger1;
	public PowerCubeTrigger boostTrigger2;
	public PowerCubeTrigger boostTrigger3;
	public Light boostLight1;
	public Light boostLight2;
	public Light boostLight3;
	public Light boostLight4;
	public Light boostLight5;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Color redAlliance = new Color32 (255,0,0,255);
		Color blueAlliance = new Color32 (0, 0, 255,255);
		Color yellow = new Color32 (251, 255, 0,255);
		Color off = new Color32 (45, 45, 45,255);
		Color thisAlliance = new Color32(255,0,255,255);
		if (alliance == "blue") {
			thisAlliance = blueAlliance;
		} else if (alliance == "red") {
			thisAlliance = redAlliance;
		}

		/*********************
		 * Boost
		*********************/
		boostLight1.color = off;
		boostLight5.color = off;
		if (boostTrigger1.isTriggered) {
			boostLight2.color = yellow;
			if (boostTrigger2.isTriggered) {
				boostLight3.color = yellow;
				if (boostTrigger3.isTriggered) {
					boostLight4.color = yellow;
				} else {
					boostLight4.color = off;
				}
			} else {
				boostLight3.color = off;
				boostLight4.color = off;
			}
		} else {
			boostLight2.color = off;
			boostLight3.color = off;
			boostLight4.color = off;
		}

		/*********************
		 * Levitate
		*********************/
		levitateLight1.color = off;
		levitateLight5.color = off;
		if (levitateTrigger1.isTriggered) {
			levitateLight2.color = yellow;
			if (levitateTrigger2.isTriggered) {
				levitateLight3.color = yellow;
				if (levitateTrigger3.isTriggered) {
					levitateLight4.color = yellow;
				} else {
					levitateLight4.color = off;
				}
			} else {
				levitateLight3.color = off;
				levitateLight4.color = off;
			}
		} else {
			levitateLight2.color = off;
			levitateLight3.color = off;
			levitateLight4.color = off;
		}
			
		/*********************
		 * Force
		*********************/
		forceLight1.color = off;
		forceLight5.color = off;
		if (forceTrigger1.isTriggered) {
			forceLight2.color = yellow;
			if (forceTrigger2.isTriggered) {
				forceLight3.color = yellow;
				if (forceTrigger3.isTriggered) {
					forceLight4.color = yellow;
				} else {
					forceLight4.color = off;
				}
			} else {
				forceLight3.color = off;
				forceLight4.color = off;
			}
		} else {
			forceLight2.color = off;
			forceLight3.color = off;
			forceLight4.color = off;
		}





	}
}
