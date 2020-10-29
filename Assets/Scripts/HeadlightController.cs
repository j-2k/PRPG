using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadlightController : MonoBehaviour
{
    public GameObject cameraObject;

    void Update()
    {
        transform.position = cameraObject.transform.position;
        transform.rotation = cameraObject.transform.rotation;
    }
}
