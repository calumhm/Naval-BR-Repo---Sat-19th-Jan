using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstallShipsScript : MonoBehaviour {

    public GameObject aiShip;


       public int AIshipCount;

[Header("Value of 10 represents Andrew's original scale.")]
    public int scale = 2;
    
	// Use this for initialization
	void Start () {
        GameObject newShip;
        Vector3 location;
        int x;
        int z, count = 0;
        location.y = 4.0f;
        for (x = -300*scale; x < 300*scale; x+=(150*scale) ) {
            for(z = -300*scale; z < 300*scale; z+= ((150*scale)) ) {
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
                if(count >= AIshipCount){
                    return;
                }
            }
        }
	}
}

