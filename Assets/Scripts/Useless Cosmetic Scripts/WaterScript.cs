using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterScript : MonoBehaviour
{
    //Just a cosmetic script
    void Update()
    {
        // Instead of using the assets script iv done this very simple script to imitate water movement
        // This spins the object around the world origin at 20 degrees/second
        transform.RotateAround(Vector3.zero, Vector3.up, 20 * Time.deltaTime);
    }
}
