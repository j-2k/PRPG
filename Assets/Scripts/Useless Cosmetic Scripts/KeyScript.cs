using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    //Just a cosmetic script
    void Update()
    {
        //Just rotating the key endlessly
        transform.Rotate(0f, 1f, 0f);
    }
}
