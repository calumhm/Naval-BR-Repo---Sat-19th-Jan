using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstallShipsScript : MonoBehaviour {

    public GameObject aiShip;
    
	// Use this for initialization
	void Start () {
        GameObject newShip;
        Vector3 location;
        int x;
        int z;
        location.y = 4.0f;
        for (x = -3000; x <= 3000; x+=600) {
            for(z = -3000; z <= 3000; z+=600) {
                // The player's ship starts in the centre!
                if (x == 0 && z == 0) continue;
                location.x = x + Random.Range(-100.0f, +100.0f);
                location.z = z + Random.Range(-100.0f, +100.0f);
                newShip = Instantiate(aiShip, location, Quaternion.identity);
                newShip.transform.Rotate(0, Random.Range(-180, +180), 0);
                newShip.transform.parent = transform;
            }
        }
	}
}

