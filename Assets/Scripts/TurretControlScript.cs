using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretControlScript : MonoBehaviour {
	private Vector3 pos;

	// Use this for initialization
	void Start () {
		pos = gameObject.transform.localPosition;
	}
	
    void scan_for_ships() {

    }

	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.R)) {
			gameObject.transform.RotateAround(pos, Vector3.up, 10 * Time.deltaTime);
			gameObject.transform.localPosition = pos;
		
		}
	}
}
