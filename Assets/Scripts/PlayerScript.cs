﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

	public GameObject _mine;
	static Camera[] cameras;

	public Vector3 zoom = new Vector3(0, 150, 0);
	bool zoomed = false;
	//Vector3 cameraZoom;

	// Use this for initialization
	void Start () {
		ShipStatsScript sss = this.gameObject.GetComponent<ShipStatsScript>(); 
		sss.health += sss.health;
		cameras = FindObjectsOfType<Camera>();
		//cameraZoom = cameras[0].transform.localPosition;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("space"))
        {
            Vector3 behind = this.gameObject.transform.position;
			behind += -transform.forward * 100.0f;
			Instantiate(_mine, behind, this.gameObject.transform.rotation);
        }

		
		if (Input.GetKeyDown("1"))
			if(!zoomed){
				cameras[0].transform.localPosition = (cameras[0].transform.localPosition + zoom);
				zoomed = true;
			}else{
				cameras[0].transform.localPosition = (cameras[0].transform.localPosition - zoom);
				zoomed = false;
			}
		 // toggle between standard camera and closeup camera
       /*  {
        if(cameras[0].enabled == true){
			cameras[0].enabled = false;
			cameras[1].enabled = true;
			}else{ 
				cameras[0].enabled = true;
				cameras[1].enabled = false;
			}
        } */
	}
}
