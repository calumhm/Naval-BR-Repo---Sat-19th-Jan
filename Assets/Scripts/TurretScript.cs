﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretScript : MonoBehaviour {
    public GameObject shell;
    public float damage {get; set;}
    private float firingFrequency;
    private ShellHolderScript shellHolderScript;
    private List<GameObject> ssGOs = new List<GameObject>();

    //  We use this to find all the shell spawners that are attached to
    //   this turret. If there is only one, it's a side turret. If there's 
    //   two, that means that it is a front turret
    void Start () {
        Component[] shellSpawners;
        shellSpawners = GetComponentsInChildren<ShellSpawnerScript>();

        damage = 20.0f;

        foreach(ShellSpawnerScript ss in shellSpawners) {
            ssGOs.Add(ss.gameObject);
        }

        if(ssGOs.Count == 1) {
            firingFrequency = 0.5f;
        } else {
            firingFrequency = 1.0f;
        }
        //InvokeRepeating("fire", 0.0f, Random.Range(firingFrequency-0.1f, firingFrequency+0.1f));

        // Get the shell holder object
        GameObject shellHolder = GameObject.Find("ShellHolderObject");
        shellHolderScript = shellHolder.GetComponent<ShellHolderScript>();
    }
	

    void fire(float range) {
        RaycastHit hit;
        GameObject newShell;
        foreach(GameObject ss in ssGOs) {

            Debug.DrawRay(ss.transform.position, (ss.transform.forward*range), Color.blue, 0.3f, depthTest: false);
             if(Physics.Raycast(ss.transform.position, ss.transform.forward, out hit, 400.0f)) {
                if(hit.collider.gameObject.tag == "aiship" || hit.collider.gameObject.tag == "ship") { 

                    newShell = shellHolderScript.get_shell();
                    if(newShell != null) {
                        newShell.transform.position = ss.transform.position;
                        newShell.transform.rotation = ss.transform.rotation;
                        ShellScript shellScript = newShell.GetComponent<ShellScript>();
                        shellScript.damage *= firingFrequency;
                        newShell.SetActive(true);
                     }else{
                        newShell = Instantiate(shell, ss.transform.position, ss.transform.rotation);
                        ShellScript shellScript = newShell.GetComponent<ShellScript>();
                        shellScript.damage *= firingFrequency;
                        newShell.SetActive(true);
                     } 
                     
                } 
                
            }
        }
    }
}


