using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float mouseX;
    float mouseY;
    public float speed = 5;
    float sensitivity = 5;
    Rigidbody myRB;
    //==new things here==
    float gravity = 5;
    Vector3 movement = Vector3.zero;
    CharacterController controller;
    Animator animator;
    public GameObject blueKey;
    public GameObject redKey;
    public GameObject greenKey;
    public GameObject whiteKey;
    int keyIndex = 0;
    public PortalController openPortal;
    public AIScript aiToPortal;
    //==new things here==

    void Start()
    {
        myRB = GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        //Assigning values for mouseX/Y
        mouseX += Input.GetAxis("Mouse X") * sensitivity;
        mouseY += Input.GetAxis("Mouse Y") * sensitivity;
        //Clamp min/max to set values for restricting mouse values
        mouseY = Mathf.Clamp(mouseY, -40, 80);
        //Transform to rotate on the Y axis only
        transform.rotation = Quaternion.Euler(0, mouseX, 0);
        //Camera moving according to the values of mouseX/mouseY
        Camera.main.transform.rotation = Quaternion.Euler(-mouseY, mouseX, 0);

        myRB.velocity = new Vector3(0, myRB.velocity.y, 0);

        //new things here
        if (controller.isGrounded)
        {
            if (Input.GetKey(KeyCode.W))
            {
                animator.SetInteger("Action", 1);
                movement = new Vector3(0, 0, 1);
                movement *= speed;
                movement = transform.TransformDirection(movement);
            }
            if (Input.GetKeyUp(KeyCode.W))
            {
                animator.SetInteger("Action", 0);
                movement = Vector3.zero;
            }

            if (Input.GetKey(KeyCode.A))
            {
                animator.SetInteger("Action", 1);
                movement = new Vector3(-1, 0, 0);
                movement *= speed;
                movement = transform.TransformDirection(movement);
            }
            if (Input.GetKeyUp(KeyCode.A))
            {
                animator.SetInteger("Action", 0);
                movement = Vector3.zero;
            }

            if (Input.GetKey(KeyCode.S))
            {
                animator.SetInteger("Action", 1);
                movement = new Vector3(0, 0, -1);
                movement *= speed;
                movement = transform.TransformDirection(movement);
            }
            if (Input.GetKeyUp(KeyCode.S))
            {
                animator.SetInteger("Action", 0);
                movement = Vector3.zero;
            }

            if (Input.GetKey(KeyCode.D))
            {
                animator.SetInteger("Action", 1);
                movement = new Vector3(1, 0, 0);
                movement *= speed;
                movement = transform.TransformDirection(movement);
            }
            if (Input.GetKeyUp(KeyCode.D))
            {
                animator.SetInteger("Action", 0);
                movement = Vector3.zero;
            }
        }
        movement.y -= gravity * Time.deltaTime;
        controller.Move(movement * Time.deltaTime);

        if (keyIndex == 4)
        {
            aiToPortal.keysOpenPortal = true;
            openPortal.disabledPortal = true;
        }
    }

    void OnTriggerEnter(Collider playerTrigger)
    {
        if (playerTrigger.gameObject.tag == "BlueKey")
        {
            keyIndex += 1;
            Destroy(blueKey);
        }

        if (playerTrigger.gameObject.tag == "GreenKey")
        {
            keyIndex += 1;
            Destroy(greenKey);
        }

        if (playerTrigger.gameObject.tag == "WhiteKey")
        {
            keyIndex += 1;
            Destroy(whiteKey);
        }

        if (playerTrigger.gameObject.tag == "RedKey")
        {
            keyIndex += 1;
            Destroy(redKey);
        }
    }
}