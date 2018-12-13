using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Example : MonoBehaviour
{
    // Toggles the time scale between regular and inspector value
    // whenever the user hits the Fire1 button.
	public float fastScale;
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (Time.timeScale == 1.0f)
                Time.timeScale = fastScale;
            else
                Time.timeScale = 1.0f;
            // Adjust fixed delta time according to timescale
            // The fixed delta time will now be 0.02 frames per real-time second
            Time.fixedDeltaTime = 0.02f * Time.timeScale;
        }
    }
}
