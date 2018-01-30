using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loading : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	private bool loading = false;
	IEnumerator load () {
		AsyncOperation async = Application.LoadLevelAsync("frc field");
		while (!async.isDone) {
			yield return async.isDone;
			Debug.Log("loading progress: " + async.progress);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (!loading && Time.time > 1) {
			loading = true;
			StartCoroutine(load ());
		}
	}
}
