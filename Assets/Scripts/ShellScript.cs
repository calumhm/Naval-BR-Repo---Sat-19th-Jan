using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellScript : MonoBehaviour {
    public float damage { get; set; }
    private Rigidbody rb;
    private ShellHolderScript shellHolderScript;

	// Use this for initialization
	void Start () {
        GameObject shellHolder = GameObject.Find("ShellHolderObject");
        shellHolderScript = shellHolder.GetComponent<ShellHolderScript>();
	}

    private void Update() {
        if(transform.position.y < 0.0f) {
            shellHolderScript.return_shell(gameObject);
        }
    }

    private void OnEnable() {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * Constants.SHELLFORCE, ForceMode.Impulse);
    }

}
