using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Robot : MonoBehaviour {
	public HingeJoint wheel1;
	public HingeJoint wheel2;
	public HingeJoint wheel3;
	public HingeJoint wheel4;
	public HingeJoint wheel5;
	public HingeJoint wheel6;
	public HingeJoint wheel7;
	public HingeJoint wheel8;
	public HingeJoint wheel9;
	public HingeJoint wheel10;
	public PlayerController player;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//Vector3 speed = new Vector3(1,0,0)* 10;
		float z = Input.GetAxis("Vertical");
		float x = Input.GetAxis ("Horizontal");
		if (player.robotControl) {
			DriveTank (Mathf.Clamp(z-x,-1.0f,1.0f),Mathf.Clamp(z+x,-1.0f,1.0f));
		} else {
			DriveTank (0,0);
		}

	}

	void DriveTank(double left, double right){
		double robotSpeed = -2500;
		SetWheelSpeed(wheel1,robotSpeed * left);
		SetWheelSpeed(wheel2,robotSpeed * left);
		SetWheelSpeed(wheel3,robotSpeed * left);
		SetWheelSpeed(wheel4,robotSpeed * left);
		SetWheelSpeed(wheel5,robotSpeed * left);

		SetWheelSpeed(wheel6,(-robotSpeed) * right);
		SetWheelSpeed(wheel7,(-robotSpeed) * right);
		SetWheelSpeed(wheel8,(-robotSpeed) * right);
		SetWheelSpeed(wheel9,(-robotSpeed) * right);
		SetWheelSpeed(wheel10,(-robotSpeed) * right);
	}

	void SetWheelSpeed(HingeJoint wheel, double speed){
		JointMotor motor = wheel.motor;
		motor.targetVelocity = (float)speed;
		wheel.motor = motor;
	}
}
