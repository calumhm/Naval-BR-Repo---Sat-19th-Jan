using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TurretAimerScript : MonoBehaviour {
    private RaycastHit[] hitsLeft;
    private RaycastHit[] hitsRight;

    private RaycastHit[] hitsFront;
    public LayerMask layerMask;


    private Transform sideGunMount00;
    private TurretScript[] turretScripts;

    private Transform frontGunMount00;
    private Transform sideGunMount01;
    private Transform sideGunMount02;
    private Transform sideGunMount03;
    private Transform sideGunMount04;
    private Transform sideGunMount05;
    public ObjectParameters m_params;

    GameObject sideGunTurret;
    
    
    [HideInInspector] public float range = 1;
    public bool debugTargets = false;
    Debugs debuggerScript;

    // Use this for initialization

    void Awake()
    {
        m_params = new ObjectParameters();  
    }

    void Start () {
        
        debuggerScript = GameObject.Find("DebugOptions").GetComponent<Debugs>();

  
        //sideGunTurret = sideGunMount00.transform.Find("SideGuns/SideGunMount01/SideTurret(Clone)/Barrels").gameObject;
      /*   turretScripts = new TurretScript[] {transform.Find("SideGuns/SideGunMount00/SideTurret(Clone)/TurretScript"), 
            transform.Find("SideGuns/SideGunMount01/SideTurret(Clone)/TurretScript"), 
            transform.Find("SideGuns/SideGunMount02/SideTurret(Clone)/TurretScript"), 
            transform.Find("SideGuns/SideGunMount03/SideTurret(Clone)/TurretScript"), 
            transform.Find("SideGuns/SideGunMount04/SideTurret(Clone)/TurretScript"), 
            transform.Find("SideGuns/SideGunMount05/SideTurret(Clone)/TurretScript")};
 */     sideGunMount00 = transform.Find("SideGuns/SideGunMount00");
        sideGunMount01 = transform.Find("SideGuns/SideGunMount01");
        sideGunMount02 = transform.Find("SideGuns/SideGunMount02");
        sideGunMount03 = transform.Find("SideGuns/SideGunMount03");
        sideGunMount04 = transform.Find("SideGuns/SideGunMount04");
        sideGunMount05 = transform.Find("SideGuns/SideGunMount05");
        frontGunMount00 = transform.Find("FrontGuns/FrontGunMount00");
        layerMask = LayerMask.GetMask("Ships");
        InvokeRepeating("do_raycasts", 0.0f, 2.0f);
    }

    void do_raycasts() {

        hitsLeft = Physics.SphereCastAll(transform.position, 50.0f, -transform.right, 400.0f, layerMask);
        Debug.DrawRay(transform.position, (transform.right*50), Color.red, 1.0f, false);
        Debug.DrawRay(transform.position, (-transform.right*50), Color.red, 1.0f, false);
        foreach(RaycastHit hit in hitsLeft) {
           // if(hit.distance >= 55.0f) {
                if(hit.collider.gameObject.name != gameObject.name ) {

                    range = Vector3.Distance(hit.point, transform.position);  //find range to Raycast hit
                    if(debuggerScript.debugTargetting) 
                    {
                        if(gameObject.tag == "aiship" && debuggerScript.debugAITargetting){
                                Debug.Log("I am " + gameObject.name + " - - Target("+ hit.collider.gameObject.name +") range = " + range);
                        }else {Debug.Log("I am " + gameObject.name + " - - Target("+ hit.collider.gameObject.name +") range = " + range);}
                        
                    }
                    m_params.tRange = range; //Assign range, name and transform values to the m_params ObjectParameters vars 
                    m_params.tName = hit.collider.gameObject.name;
                    m_params.tPos = hit.point;

                    sideGunMount00.SendMessage("Calibrate_Gun", m_params, SendMessageOptions.DontRequireReceiver);
                    sideGunMount02.SendMessage("Calibrate_Gun", m_params, SendMessageOptions.DontRequireReceiver);
                    sideGunMount04.SendMessage("Calibrate_Gun", m_params, SendMessageOptions.DontRequireReceiver);

                    sideGunMount00.SendMessage("Fire", SendMessageOptions.DontRequireReceiver);
                    sideGunMount02.SendMessage("Fire", SendMessageOptions.DontRequireReceiver);
                    sideGunMount04.SendMessage("Fire", SendMessageOptions.DontRequireReceiver);
                }
           // }
        }

        hitsRight = Physics.SphereCastAll(transform.position, 50.0f, transform.right, 400.0f, layerMask);
        foreach(RaycastHit hit in hitsRight) {
           // if(hit.distance >= 55.0f) {
                if(hit.collider.gameObject.name != gameObject.name && hit.collider.gameObject.layer == gameObject.layer) {
                    range = Vector3.Distance(hit.point, transform.position);  //find range to Raycast hit

                    if(debuggerScript.debugTargetting) 
                    {
                        Debug.Log("I am " + gameObject.name + " - - Target("+ hit.collider.gameObject.name +") range = " + range);
                    }
                    m_params.tRange = range;
                    m_params.tName = hit.collider.gameObject.name;
                    m_params.tPos = hit.point;

                    sideGunMount01.SendMessage("Calibrate_Gun", m_params, SendMessageOptions.DontRequireReceiver);
                    sideGunMount03.SendMessage("Calibrate_Gun", m_params, SendMessageOptions.DontRequireReceiver);
                    sideGunMount05.SendMessage("Calibrate_Gun", m_params, SendMessageOptions.DontRequireReceiver);

                    sideGunMount01.SendMessage("Fire", m_params, SendMessageOptions.DontRequireReceiver);
                    sideGunMount03.SendMessage("Fire", m_params, SendMessageOptions.DontRequireReceiver);
                    sideGunMount05.SendMessage("Fire", m_params, SendMessageOptions.DontRequireReceiver);
                }
           // }
        }

        hitsFront = Physics.SphereCastAll(transform.position, 50.0f, transform.forward, 400.0f, layerMask);
        
        foreach(RaycastHit hit in hitsFront) {
           // if(hit.distance >= 55.0f) {
                if(hit.collider.gameObject.name != gameObject.name ) {

                    range = Vector3.Distance(hit.point, transform.position);  //find range to Raycast hit
                    if(debuggerScript.debugTargetting) 
                    {
                        if(gameObject.tag == "aiship" && debuggerScript.debugAITargetting){
                                Debug.Log("I am " + gameObject.name + "FrontGun - - Target("+ hit.collider.gameObject.name +") range = " + range);
                        }else {Debug.Log("I am " + gameObject.name + " FrontGun - - Target("+ hit.collider.gameObject.name +") range = " + range);}
                        
                    }
                    m_params.tRange = range; //Assign range, name and transform values to the m_params ObjectParameters vars 
                    m_params.tName = hit.collider.gameObject.name;
                    m_params.tPos = hit.point;

                    frontGunMount00.SendMessage("Calibrate_Gun", m_params, SendMessageOptions.DontRequireReceiver);
                    frontGunMount00.SendMessage("Fire", SendMessageOptions.DontRequireReceiver);

   
   
                }
            }
        }
}
    public class ObjectParameters
    {
            [HideInInspector] public float tRange;
            [HideInInspector] public Vector3 tPos;
            [HideInInspector] public string tName;

    }
