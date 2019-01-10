using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CrateContents : MonoBehaviour {

	public TextMeshProUGUI uiCrateType;
	public TextMeshProUGUI uiCrateValue;
	public Constants.UpgradeTypes type { get; set; }
	
	public float value { get; set; }


	Quaternion test;

	// Use this for initialization
	void Start () {
		test = Camera.main.transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
		update_ui();
	}

	string convert_crate_type() {
		string crateTypeString;
		// Show the type
		if(type == Constants.UpgradeTypes.ACCELERATION) {
			crateTypeString = "ACCELERATION";
		} else if(type == Constants.UpgradeTypes.HEALTH) {
			crateTypeString = "HEALTH";
		} else if(type == Constants.UpgradeTypes.SHIELD) {
			crateTypeString = "SHIELD";
		} else if(type == Constants.UpgradeTypes.topSpeed) {
			crateTypeString = "topSpeed";
		} else if(type == Constants.UpgradeTypes.TURNSPEED) {
			crateTypeString = "TURNSPEED";
		} else {
			crateTypeString = "NOTHING";
		}
		return crateTypeString;
	}

	void update_ui() {
		uiCrateType.text = convert_crate_type();
		uiCrateValue.text = value.ToString("F1");
		uiCrateType.transform.rotation = test; 
		
		uiCrateValue.transform.rotation = test;
	}


}
