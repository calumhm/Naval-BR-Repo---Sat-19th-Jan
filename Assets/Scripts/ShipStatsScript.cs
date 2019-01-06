using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;

public class ShipStatsScript : MonoBehaviour
{
    public TextMeshProUGUI uiCurrentSpeed;
    public TextMeshProUGUI uiMaxSpeed;
    public TextMeshProUGUI uiHealth;
    public TextMeshProUGUI uiShield;
    public TextMeshProUGUI uiAcceleration;
    public TextMeshProUGUI uiTurnSpeed;

    public TextMeshProUGUI uiAIShield;
    public TextMeshProUGUI uiAIHealth;
    private GameObject uiAIcanvas;

    public float acceleration { get; set; }
    public float maxspeed { get; set; }
    public float health { get; set; }
    public float shield { get; set; }
    public float turnspeed { get; set; }

    private Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        this.acceleration = Constants.DEFAULTSHIPACCELERATION;
        this.maxspeed = Constants.DEFAULTMAXSHIPSPEED;
        this.turnspeed = Constants.DEFAULTTURNSPEED;
        this.health = Constants.MAXIMUMSHIPHEALTH;
        this.shield = Constants.MAXIMUMSHIPSHIELD;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag == "ship")
        {
            update_ui();
        }
        if (gameObject.tag == "aiship")
        {
            update_aiship_ui();
        }
        check_if_sinking();
    }


    void update_ui()
    {
        uiMaxSpeed.text = "MAX speed = " + this.maxspeed.ToString("F1") + "kts";
        float fwdSpeed = Vector3.Dot(rb.velocity, transform.forward);
        float knots = fwdSpeed * Constants.MpS_TO_KNOTS;
        uiCurrentSpeed.text = "CURRENT speed = " + knots.ToString("F1") + "kts";
        uiHealth.text = "Health: " + this.health.ToString("F1");
        uiShield.text = "Shield: " + this.shield.ToString("F1");
        uiAcceleration.text = "Acceleration: " + this.acceleration.ToString("F1");
        uiTurnSpeed.text = "Turn speed: " + this.turnspeed.ToString("F1");
    }

    void update_aiship_ui()
    {
        uiAIHealth.text = "Health: " + this.health.ToString("F1");
        uiAIShield.text = "Shield: " + this.shield.ToString("F1");
        uiAIShield.transform.rotation = Camera.main.transform.rotation;
        uiAIHealth.transform.rotation = Camera.main.transform.rotation;
      /*  Vector3 relative = transform.InverseTransformPoint(Camera.position);
        float angle = Mathf.Atan2(relative.x, relative.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, -angle); */
    }

    // Week 08 Week08
    public void take_damage(float dmg)
    {
        if(dmg <= shield) {
            shield = shield - dmg;
        } else {
            dmg = dmg - shield;
            shield = 0;
            health = health - dmg;
            if(health < 0) {
                health = 0;
            }
        }
    }

    void check_if_sinking()
    {
        if(health <= 0) {
            FloatScript floatScript = GetComponent<FloatScript>();
            floatScript.enabled = false;
            if(gameObject.tag == "aiship") {
                NavMeshAgent agent = GetComponent<NavMeshAgent>();
                agent.enabled = false;
            }
            if(transform.position.y < -40.0f) {
                Destroy(gameObject);
            }
        }
    }
}
