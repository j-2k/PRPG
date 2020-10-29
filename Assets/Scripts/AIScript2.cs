using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIScript2 : MonoBehaviour
{
    public GameObject player;
    public GameObject door;
    Rigidbody rigidBody;
    float speakingtime;
    Vector3 movement = Vector3.zero;
    CharacterController controller;
    Animator animator;
    float gravity = 5;
    public Transform frontOfDoor;
    public Vector3 destinationPointToPortal;
    float timer;
    public float randomPick;
    UIText textHandler;
    WaypointsScript2 waypoints;

    public enum AIStates
    {
        Speaking,
        InspectingDoor,
        WaitingAtDoor,
        Roaming,
        EndPortal,
        Idle
    }
    public AIStates currentAIStates;

    void Start()
    {
        waypoints = GetComponent<WaypointsScript2>();
        textHandler = GameObject.FindGameObjectWithTag("Text").GetComponent<UIText>();
        player.GetComponent<PlayerController2>().enabled = false;
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
                textHandler.currentText = UIText.TextPart.NewIntro1;
                speakingtime += Time.deltaTime;
                if (speakingtime >= 5)
                {
                    player.GetComponent<PlayerController2>().enabled = true;
                    currentAIStates = AIStates.InspectingDoor;
                }
                movement.y -= gravity * Time.deltaTime;
                controller.Move(movement * Time.deltaTime);
                break;
            case AIStates.InspectingDoor:
                print("InspectingDoor state");
                controller.enabled = false;
                waypoints.enabled = true;
                animator.SetInteger("Action", 1);
                if (Vector3.Distance(rigidBody.transform.position, frontOfDoor.position) <= 0.2f)
                {
                    currentAIStates = AIStates.WaitingAtDoor;
                }
                break;
            case AIStates.WaitingAtDoor:
                print("Waiting State");
                waypoints.enabled = false;
                controller.enabled = true;
                animator.SetInteger("Action", 0);
                movement = Vector3.zero;
                transform.LookAt(door.transform.position);
                timer += Time.deltaTime;
                if (timer >= 10)
                {
                    randomPick = Random.Range(1, 4);
                    {
                        if (randomPick == 1)
                        {

                        }
                        if (randomPick == 2)
                        {

                        }
                        if (randomPick == 3)
                        {
                            currentAIStates = AIStates.Roaming;
                        }
                    }
                    timer = 0;
                }
                break;
            case AIStates.Roaming:
                controller.enabled = false;
                waypoints.enabled = true;
                waypoints.currentWaypointAI = WaypointsScript2.WaypointAI.Roaming;
                break;
            case AIStates.EndPortal:
                textHandler.currentText = UIText.TextPart.NewPortal1;
                waypoints.currentWaypointAI = WaypointsScript2.WaypointAI.ExitPortal;
                controller.enabled = false;
                waypoints.enabled = true;
                animator.SetInteger("Action", 1);
                if (Vector3.Distance(rigidBody.transform.position, destinationPointToPortal) <= 0.2f)
                {
                    currentAIStates = AIStates.Idle;
                }
                break;
            case AIStates.Idle:
                controller.enabled = true;
                waypoints.enabled = false;
                animator.SetInteger("Action", 0);
                transform.LookAt(player.transform.position);
                break;
        }
    }
}