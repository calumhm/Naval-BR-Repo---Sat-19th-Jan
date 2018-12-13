using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunMountRotator : MonoBehaviour {
    void rotate_towards(Vector3 target) {
        target.y = transform.position.y;
        transform.LookAt(target);
    }

}
