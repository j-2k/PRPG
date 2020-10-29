using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalController : MonoBehaviour
{
    public GameObject objectToDisable;
    public bool disabledPortal = false;

    void Update()
    {
        if (disabledPortal == false)
            objectToDisable.SetActive(false);
        else
            objectToDisable.SetActive(true);
    }
}
