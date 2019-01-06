using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

	public GameObject _mine;
	

	// Use this for initialization
	void Start () {
		ShipStatsScript sss = this.gameObject.GetComponent<ShipStatsScript>(); 
		sss.health += sss.health;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("space"))
        {
            Vector3 behind = this.gameObject.transform.position;
			behind += -transform.forward * 100.0f;
			Instantiate(_mine, behind, this.gameObject.transform.rotation);
        }
	}
}
