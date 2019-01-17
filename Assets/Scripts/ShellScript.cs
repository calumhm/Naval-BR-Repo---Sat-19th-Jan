using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellScript : MonoBehaviour {
    public GameObject debugGO;
    GameObject shellHolder;
    Debugs debuggerScript;
    private bool debugImpact;
    private bool debugShellImpact;
    public float missFactor = 0.5f;
	public float vMissFactor = 0.2f;
    GameObject exp;
	public GameObject explosionPref;
	public GameObject splashPref;
    ParticleSystem[] pfx; 

    public float damage = 20;
    private Rigidbody rb;
    private ShellHolderScript shellHolderScript;

	// Use this for initialization
	void Start () {
    //The Get "Debugs" script from Debug Loggers gameobject
        //debugGO = GameObject.FindWithTag("debug");
        debuggerScript = GameObject.Find("DebugOptions").GetComponent<Debugs>();
        debugShellImpact = debuggerScript.debugShellImpact;
        //
        shellHolder = GameObject.Find("ShellHolderObject");
        shellHolderScript = shellHolder.GetComponent<ShellHolderScript>();
         
   
	}

    private void Update() {
        if(transform.position.y < -5.0f) {
            shellHolderScript.return_shell(gameObject);
            this.gameObject.SetActive(false);
        }
    }

    private void OnEnable() {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * Constants.SHELLFORCE, ForceMode.Impulse);
    }

    void OnCollisionEnter(Collision col)
	{
		

            if(debuggerScript == null){Debug.Log("DebuggerScript null");}

		if(debugShellImpact == true)
        {
            Debug.Log("hit " + col.gameObject.name);

        }
		if(col.gameObject.name != gameObject.name && col.gameObject.layer == 9)
		{
			
            ShipStatsScript sss = col.gameObject.GetComponent<ShipStatsScript>();
            ContactPoint cont = col.contacts[0];   // new ContactPoint 
			exp = shellHolderScript.get_Exp();
            if(!exp){ Debug.Log("Exp is null"); }
            exp.transform.position = cont.point;
           // exp.transform.position = gameObject.transform.position;

			
			shellHolderScript.invoke_return_Exp(exp);
			
			sss.take_damage(damage);
            damage = Constants.MINIMUMDAMAGE;			
		}

		if(col.gameObject.tag == "water")
		{
/* 			ContactPoint cont = col.contacts[0];   // new ContactPoint 
			GameObject splash = Instantiate(splashPref, cont.point, Quaternion.identity);
			Destroy(splash, 3.0f); */
		}
		
	}

}
