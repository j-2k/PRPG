using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIScript : MonoBehaviour
{
    public GameObject player;
    Rigidbody rigidBody;
    float speed = 5;
    float speakingtime;
    Vector3 movement = Vector3.zero;
    CharacterController controller;
    Animator animator;
    float gravity = 5;
    public bool keysOpenPortal;
    UIText textHandler;
    WaypointsScript waypoints;
    AIScript aiScript;

    public enum AIStates
    {
        Speaking,
        Following,
        Portal,
        Waiting
    }
    public AIStates currentAIStates;

    void Start()
    {
        waypoints = GetComponent<WaypointsScript>();
        aiScript = GetComponent<AIScript>();
        textHandler = GameObject.FindGameObjectWithTag("Text").GetComponent<UIText>();
        player.GetComponent<PlayerController>().enabled = false;
        currentAIStates = AIStates.Speaking;
        rigidBody = GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        controller.enabled = true;
        waypoints.enabled = false;
    }

    void Update()
    {
        rigidBody.velocity = new Vector3(0, rigidBody.velocity.y, 0);
        switch (currentAIStates)
        {
            case AIStates.Speaking:
                print("Speaking state");
                transform.LookAt(player.transform.position);
                player.transform.LookAt(rigidBody.transform.position);
                speakingtime += Time.deltaTime;
                if (speakingtime > 25)
                {
                    currentAIStates = AIStates.Following;
                }
                movement.y -= gravity * Time.deltaTime;
                controller.Move(movement * Time.deltaTime);
                break;
            case AIStates.Following:
                print("Following state");
                transform.LookAt(player.transform.position);
                player.GetComponent<PlayerController>().enabled = true;
                rigidBody.velocity = transform.forward * speed;
                if (Vector3.Distance(player.transform.position, rigidBody.transform.position) <= 3)
                {
                    animator.SetInteger("Action", 0);
                    movement = Vector3.zero;
                }
                else
                {
                    animator.SetInteger("Action", 1);
                    movement = new Vector3(0, 0, 1);
                    movement *= speed;
                    movement = transform.TransformDirection(movement);
                }
                if (keysOpenPortal == true)
                {
                    currentAIStates = AIStates.Portal;
                }
                movement.y -= gravity * Time.deltaTime;
                controller.Move(movement * Time.deltaTime);
                break;
            case AIStates.Portal:
                print("Portal state");
                textHandler.currentText = UIText.TextPart.Portal1;
                waypoints.enabled = true;
                controller.enabled = false;
                animator.SetInteger("Action", 1);
                break;
            case AIStates.Waiting:
                print("Waiting State");
                controller.enabled = true;
                waypoints.enabled = false;
                animator.SetInteger("Action", 0);
                movement = Vector3.zero;
                transform.LookAt(player.transform.position);
                break;

        }
    }
}