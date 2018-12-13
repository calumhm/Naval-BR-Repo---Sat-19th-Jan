using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipListScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        InvokeRepeating("find_ships", 3.0f, 3.0f);
	}



    void find_ships() {
        List<GameObject> shipsList = new List<GameObject>();
        GameObject[] aiShipArray = GameObject.FindGameObjectsWithTag("aiship");
        foreach(GameObject aiShip in aiShipArray) {
            shipsList.Add(aiShip);
        }
        GameObject playerShip = GameObject.FindGameObjectWithTag("ship");
        if(playerShip) {
            shipsList.Add(playerShip);            
        }

        foreach(GameObject ship in shipsList) {
            float closestDistance = float.MaxValue;
            GameObject closestTarget = ship;
            foreach(GameObject target in shipsList) {
                if (target == ship) continue;
                float distance = Vector3.Distance(ship.transform.position, target.transform.position);
                if(distance < closestDistance) {
                    closestDistance = distance;
                    closestTarget = target;
                }
            }
            ship.SendMessage("set_destination", closestTarget.transform.position, SendMessageOptions.DontRequireReceiver);
        }
    }

}
