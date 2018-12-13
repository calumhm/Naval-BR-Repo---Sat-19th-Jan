using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAimerScript : MonoBehaviour {
    private RaycastHit[] hitsLeft;
    private RaycastHit[] hitsRight;

    private Transform sideGunMount00;
    private Transform sideGunMount01;
    private Transform sideGunMount02;
    private Transform sideGunMount03;
    private Transform sideGunMount04;
    private Transform sideGunMount05;

    // Use this for initialization
    void Start () {
        sideGunMount00 = transform.Find("SideGuns/SideGunMount00");
        sideGunMount01 = transform.Find("SideGuns/SideGunMount01");
        sideGunMount02 = transform.Find("SideGuns/SideGunMount02");
        sideGunMount03 = transform.Find("SideGuns/SideGunMount03");
        sideGunMount04 = transform.Find("SideGuns/SideGunMount04");
        sideGunMount05 = transform.Find("SideGuns/SideGunMount05");
        InvokeRepeating("do_raycasts", 0.0f, 2.0f);
    }

    void do_raycasts() {
        hitsLeft = Physics.SphereCastAll(transform.position, 50.0f, -transform.right, 400.0f);
        foreach(RaycastHit hit in hitsLeft) {
            if(hit.distance >= 55.0f) {
                if(hit.collider.gameObject.tag == "aiship" || hit.collider.gameObject.tag == "ship") {
                    sideGunMount00.SendMessage("rotate_towards", hit.point, SendMessageOptions.DontRequireReceiver);
                    sideGunMount02.SendMessage("rotate_towards", hit.point, SendMessageOptions.DontRequireReceiver);
                    sideGunMount04.SendMessage("rotate_towards", hit.point, SendMessageOptions.DontRequireReceiver);
                }
            }
        }
        hitsRight = Physics.SphereCastAll(transform.position, 50.0f, transform.right, 400.0f);
        foreach(RaycastHit hit in hitsRight) {
            if(hit.distance >= 55.0f) {
                if(hit.collider.gameObject.tag == "aiship" || hit.collider.gameObject.tag == "ship") {
                    sideGunMount01.SendMessage("rotate_towards", hit.point, SendMessageOptions.DontRequireReceiver);
                    sideGunMount03.SendMessage("rotate_towards", hit.point, SendMessageOptions.DontRequireReceiver);
                    sideGunMount05.SendMessage("rotate_towards", hit.point, SendMessageOptions.DontRequireReceiver);
                }
            }
        }
    }

}
