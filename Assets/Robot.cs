using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour {
	public WheelCollider[] leftWheels;
	public WheelCollider[] rightWheels;
	public PlayerController player;
	public GameObject upperRail;
	public GameObject hug;
	public GameObject hugRightFinger;
	public GameObject hugLeftFinger;
	public GameObject hugBase;

	private double upperRailMaxYIncrease = 16.95;
	private double upperRailMinY;

	private double hugMaxYIncrease =  14.47;
	private double hugMinY;

	private float originalBaseX;
	private float baseXRetracted = -3.93f;

	private float originalRightFingerZ;
	private float originalLeftFingerZ;

	private float fingerOffset = 7.84f;
	// Use this for initialization
	void Start () {
		upperRailMinY = (double)upperRail.transform.localPosition.y;
		hugMinY = (double)hug.transform.localPosition.y-1.1;
		originalBaseX = hugBase.transform.localPosition.x;
		originalRightFingerZ = hugRightFinger.transform.localPosition.z;
		originalLeftFingerZ = hugLeftFinger.transform.localPosition.z;
	}
	
	// Update is called once per frame
	void Update () {
		float z = Input.GetAxis("Vertical");
		float x = Input.GetAxis ("Horizontal");
		float left = 0;
		float right = 0;
		float speed = 10;
		if (player.robotControl) {
			left = Mathf.Clamp (z + x, -1.0f, 1.0f)*speed;
			right = Mathf.Clamp (z - x, -1.0f, 1.0f)*speed;

			double upperRailSpeed = 0.1;
			if (Input.GetKey (KeyCode.Keypad1) && upperRail.transform.localPosition.y > upperRailMinY) {
				upperRail.transform.localPosition = 
					new Vector3 (upperRail.transform.localPosition.x,
						(float)(upperRail.transform.localPosition.y - upperRailSpeed),
						upperRail.transform.localPosition.z);
			} else if (Input.GetKey (KeyCode.Keypad4) && upperRail.transform.localPosition.y < upperRailMinY + upperRailMaxYIncrease) {
				upperRail.transform.localPosition = 
					new Vector3 (upperRail.transform.localPosition.x,
						(float)(upperRail.transform.localPosition.y + upperRailSpeed),
						upperRail.transform.localPosition.z);
			}

			double hugSpeed = 0.1;
			if (Input.GetKey (KeyCode.Keypad2) && hug.transform.localPosition.y > hugMinY) {
				hug.transform.localPosition = 
					new Vector3 (hug.transform.localPosition.x,
						(float)(hug.transform.localPosition.y - hugSpeed),
						hug.transform.localPosition.z);
			} else if (Input.GetKey (KeyCode.Keypad5) && hug.transform.localPosition.y < hugMinY + hugMaxYIncrease) {
				hug.transform.localPosition = 
					new Vector3 (hug.transform.localPosition.x,
						(float)(hug.transform.localPosition.y + hugSpeed),
						hug.transform.localPosition.z);
			}

			if (Input.GetKey (KeyCode.Keypad0)) {
				hugBase.transform.localPosition =
					new Vector3 (baseXRetracted,
						hugBase.transform.localPosition.y,
						hugBase.transform.localPosition.z);
			} else {
				hugBase.transform.localPosition =
					new Vector3 (originalBaseX,
						hugBase.transform.localPosition.y,
						hugBase.transform.localPosition.z);
			}

			if (Input.GetKey (KeyCode.KeypadPeriod)) {
				hugRightFinger.transform.localPosition = 
					new Vector3 (hugRightFinger.transform.localPosition.x,	
					hugRightFinger.transform.localPosition.y,
					(float)(originalRightFingerZ - fingerOffset));
				hugLeftFinger.transform.localPosition = 
					new Vector3 (hugRightFinger.transform.localPosition.x,	
					hugRightFinger.transform.localPosition.y,
					(float)(originalLeftFingerZ + fingerOffset));
			} else {
				hugRightFinger.transform.localPosition = 
					new Vector3 (hugRightFinger.transform.localPosition.x,	
					hugRightFinger.transform.localPosition.y,
					originalRightFingerZ);
				hugLeftFinger.transform.localPosition = 
					new Vector3 (hugRightFinger.transform.localPosition.x,	
					hugRightFinger.transform.localPosition.y,
					originalLeftFingerZ);
			}
		}
		

		for (int i = 0; i < leftWheels.Length; i++) {
			leftWheels [i].motorTorque = left;
			leftWheels [i].gameObject.transform.Rotate (0,leftWheels [i].rpm / 60 * 360 * Time.deltaTime, 0);
		}
		for (int i = 0; i < rightWheels.Length; i++) {
			rightWheels [i].motorTorque = right;
			rightWheels [i].gameObject.transform.Rotate (0,rightWheels [i].rpm / 60 * 360 * Time.deltaTime, 0);
		}
	}
}
