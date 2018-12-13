using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayInBoundsScript : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		float absZ = Mathf.Abs(transform.position.z);
		float absX = Mathf.Abs(transform.position.x);

		if(absZ > 3500.0f || absX > 3500.0f) {
			transform.LookAt(Vector3.zero, Vector3.up);
		}
	}
}
