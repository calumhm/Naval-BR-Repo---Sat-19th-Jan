using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeShipScript : MonoBehaviour {

    private ShellHolderScript shellHolderScript;
    GameObject cs;
	// Use this for initialization
	void Start () {
       shellHolderScript = GameObject.Find("ShellHolderObject").GetComponent<ShellHolderScript>();	
        cs = GameObject.Find("Crate Spawner");
	}
	

	void OnTriggerEnter(Collider coll) {
		if(coll.gameObject.tag == "upgradecrate") {
            upgrade_if_better(coll.gameObject);
            cs.GetComponent<CrateSpawnerScript>().return_crate(coll.gameObject);
		} else if(coll.gameObject.tag == "upgradefrontgun") {
            // What do we want to do here?
            Destroy(coll.gameObject);
        } else if(coll.gameObject.tag == "upgradesidegun") {
            // What do we want to do here?
            Destroy(coll.gameObject);
        } else if(coll.gameObject.tag == "shell") {
            // Week08 Week 08
            ShipStatsScript sss = GetComponent<ShipStatsScript>();
            ShellScript shellScript = coll.gameObject.GetComponent<ShellScript>();
            sss.take_damage(shellScript.damage);
            shellHolderScript.return_shell(coll.gameObject);
            shellHolderScript.get_Exp();
            //coll.point
        }
        else if(coll.gameObject.tag == "mine") {
    
            ShipStatsScript sss = GetComponent<ShipStatsScript>();
            MineScript mineScript = coll.gameObject.GetComponent<MineScript>();
            sss.take_damage(mineScript.damage);
            }
    }



    void upgrade_if_better(GameObject crate) {
        CrateContents cc = crate.GetComponent<CrateContents>();
        ShipStatsScript sss = GetComponent<ShipStatsScript>();

        if(cc.type == Constants.UpgradeTypes.topSpeed) {
            if(cc.value + sss.topSpeed > sss.topSpeed) {
                sss.topSpeed = cc.value;
            }
        } else if(cc.type == Constants.UpgradeTypes.SHIELD) {
            if(cc.value > sss.shield) {
                sss.shield = cc.value;
            }
        } else if(cc.type == Constants.UpgradeTypes.ACCELERATION) {
            if(cc.value > sss.acceleration) {
                sss.acceleration = cc.value;
            }
        } else if(cc.type == Constants.UpgradeTypes.TURNSPEED) {
            if(cc.value > sss.turnspeed) {
                sss.turnspeed = cc.value;
            }
        }
    }

}
