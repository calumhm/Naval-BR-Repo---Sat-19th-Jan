using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatController : MonoBehaviour {
    private Rigidbody rb;
    private ShipStatsScript sss;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        sss = GetComponent<ShipStatsScript>();
    }

    void FixedUpdate () {
        drive();
        steer();
	}

    // I actually tried a "propeller" system, which added force at the back of the ship.
    //  Sadly, this does not work well, as AddForceAtPosition tends to disrupt the torque,
    //  which causes the ship to turn, even if we don't want it to do.
    void drive() {
        float forwardAcceleration = sss.acceleration;
        float currentAcceleration;
        
        float vertical = Input.GetAxis("Vertical");
        float fwdSpeed = Vector3.Dot(rb.velocity, transform.forward);

        if (Mathf.Abs(fwdSpeed) >= (sss.maxspeed / Constants.MpS_TO_KNOTS)) {
            vertical = 0.0f;
        } 

        if(vertical > 0.0f) {
            currentAcceleration = forwardAcceleration;
        } else if(vertical < 0.0f) {
            currentAcceleration = forwardAcceleration / 2.0f;
        } else {
            currentAcceleration = 0.0f;
        }

        rb.AddRelativeForce(vertical * currentAcceleration * Time.deltaTime * Vector3.forward);
    }

    // You will notice that I am now "cheating" with the way that I turn the ship. 
    //  Now I am just using transform.Rotate. (I have also set the angular drag of 
    //  the rigidbody to be very high)
    void steer() {
        float turnSpeed = sss.turnspeed;
        float horizontal = Input.GetAxis("Horizontal");
        float fwdSpeed = Vector3.Dot(rb.velocity, transform.forward);
        if (fwdSpeed >= sss.maxspeed) {
            horizontal = 0.0f;
        } 
        if(fwdSpeed < 1.0f) {
            horizontal = 0.0f;
        }
        
        transform.Rotate(transform.up * Time.deltaTime * sss.turnspeed * horizontal, Space.Self);
    }
}

