using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunMountRotator : MonoBehaviour {
private float targetRange;
public float rangeMissFactor = 1.5f; //This editable var defines the extend to which range causes the guns to be innacurate
protected TurretAimerScript tas;
GameObject parentGO; 
GameObject debugGO;
Debugs debugScript;


    private void Start() {
        debugGO = GameObject.Find("DebugOptions").gameObject;
        debugScript = debugGO.GetComponent<Debugs>();
        rangeMissFactor = Constants.DEFAULTrangeMissFactor; // Allows for an accuracy upgrade later on, if I have time!
    }

    void Calibrate_Gun (ObjectParameters targetParams) //This new Function is now called by SendMessage, as it only reqs 1 parameter
    {
        Vector3 tPos = targetParams.tPos;
        string tName = targetParams.tName;
        float tRange = targetParams.tRange;
        rotate_towards(tPos, tName, tRange );
    }
    
    void rotate_towards(Vector3 targetPos,  string targetName, float targetRange) 
    //Now rotate_towards can use these variables without being constrained to the 1-parameter limit of SendMessage()
    {
        targetPos.y = transform.position.y;
        
        if(debugScript.debugTargetFinder)
        {
            Debug.Log("I am " + this.transform.parent.parent.name + ", Target = " + targetName + " targetRange = "  + targetRange + ". SpreadRadius = " 
                                + targetRange/rangeMissFactor);
        }
        targetPos.z = targetPos.z + Random.Range(-targetRange*rangeMissFactor, targetRange*rangeMissFactor);
        //targetPos.y = transform.position.y + Random.Range(-targetRange*rangeMissFactor*0.25f, targetRange*rangeMissFactor*0.25f);
        targetPos.x = targetPos.z + Random.Range(-targetRange*rangeMissFactor, targetRange*rangeMissFactor);
        transform.LookAt(targetPos);
        
        //Debug.DrawRay(transform.position,  Color.green, 0.3f, false);
        Vector3 direction = (targetPos - transform.position).normalized;
        Debug.DrawRay(transform.position, (transform.forward*targetRange), Color.green, 0.3f, depthTest: false);
    }

    private void Awake() 
    {
/*         TurretAimerScript tas = this.gameObject.gameObject.GetComponent<TurretAimerScript>();

 */ 
 parentGO = this.transform.parent.parent.gameObject;
 tas = parentGO.GetComponent<TurretAimerScript>();
 
    }
}   
