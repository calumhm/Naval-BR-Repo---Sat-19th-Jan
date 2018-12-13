using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatScript : MonoBehaviour {
    public float waterLevel = 0.0f;
    public float floatThreshold = 2.0f;
    public float waterDensity = 0.125f;
    public float downForce = 4.0f;

    public float forceFactor;
    public Vector3 floatForce;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = Vector3.zero;
    }

    // You'll notice that I have changed this slightly, to remove the slightly embarassing
    //  "bounce" error, which caused the body to shoot high into the air if it started out
    //  too far below the "surface"
    void FixedUpdate () {
        forceFactor = 1.0f - ((transform.position.y - waterLevel) / floatThreshold);
        floatForce = -Physics.gravity * rb.mass * (forceFactor - rb.velocity.y * waterDensity);
        floatForce += new Vector3(0.0f, -downForce * rb.mass, 0.0f);
        rb.AddForceAtPosition(floatForce, transform.position);
	}
}
