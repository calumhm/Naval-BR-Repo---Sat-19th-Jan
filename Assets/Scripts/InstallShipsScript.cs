using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstallShipsScript : MonoBehaviour {

    public GameObject aiShip;
    public int AIshipCount;
    public int scale = 2;
    
	// Use this for initialization
	void Start () {
        GameObject newShip;
        Vector3 location;
        float x;
        float z, count = 0;
        location.y = 4.0f;
        for (x = -128f*scale; x < 128f*scale; x+=((Mathf.Abs(x*scale))/(float)AIshipCount) ) {
            for(z = -128f*scale; z < 128f*scale; z+= ((Mathf.Abs(z*scale))/(float)AIshipCount) ) {
            //for(z = -1000*scale; z < 1000*scale; z+=200*scale) {
                // The player's ship starts in the centre!
                if (x == 0 && z == 0) continue;
                
                location.x = x + Random.Range(-100.0f, +100.0f);
                location.z = z + Random.Range(-100.0f, +100.0f);
                newShip = Instantiate(aiShip, location, Quaternion.identity);
                newShip.transform.Rotate(0, Random.Range(-180, +180), 0);
                ++count;
                newShip.gameObject.name = ("AI Ship No." + count);
                newShip.transform.parent = transform;
            }
        }
	}
}

