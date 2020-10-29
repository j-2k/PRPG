using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalScript : MonoBehaviour
{
    public float timer;
    public GameObject aiObject;

    void Update()
    {
        transform.Rotate(1f, 0f, 0f);
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            timer += Time.deltaTime;
            if (timer >= 3)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            print("player is in the portal");
        }
        if (other.gameObject.tag == "AI")
        {
            timer += Time.deltaTime;
            if (timer >= 3)
            {
                Destroy(aiObject);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        timer = 0;
        print("player is leaving the portal");
    }
}
