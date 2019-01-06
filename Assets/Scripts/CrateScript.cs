using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateScript : MonoBehaviour {
	private float timeRemaining = Constants.CRATETIMEOUT;
	// Use this for initialization
	void Start () {
		
	}
    private void OnEnable()
    {
        timeRemaining = Constants.CRATETIMEOUT;
    }

    // Update is called once per frame
    void Update () {
		if(transform.position.y > -1.0) {
			timeRemaining = timeRemaining - Time.deltaTime;
			if(timeRemaining < 0.0f) {
                GameObject.Find("Crate Spawner").GetComponent<CrateSpawnerScript>().return_crate(gameObject);
			}
		}	
	}
}
