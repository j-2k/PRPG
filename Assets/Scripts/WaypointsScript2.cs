using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointsScript2 : MonoBehaviour
{
    public List<Transform> waypoints = new List<Transform>();                               //making a public list of transforms for setting waypoints
    Transform targetWaypoint;
    int targetWaypointIndex = 0;
    float minDistance = 0.1f;
    int lastWaypointIndex;
    Animator animator;
    float movementStep;
    float distance;
    AIScript2 passEnum;
    public float speed = 4f;
    public Transform doorTransform;
    public Transform frontOfDoor;
    public Transform portalTransform;

    public enum WaypointAI
    {
        Introduction,
        Idle,
        Roaming,
        ExitPortal
    }
    public WaypointAI currentWaypointAI;

    void Start()
    {
        passEnum = GetComponent<AIScript2>();
        animator = GetComponent<Animator>();
        lastWaypointIndex = waypoints.Count - 1;                                            //minusing by 1 because waypoints system starts at 0
        targetWaypoint = waypoints[targetWaypointIndex];                                    //matching the transform to the waypointsindex
        currentWaypointAI = WaypointAI.Introduction;

    }

    void Update()
    {
        movementStep = speed * Time.deltaTime;
        switch (currentWaypointAI)
        {
            case WaypointAI.Introduction:
                //calcuating direction for AI to face door
                Vector3 directionToDoor = doorTransform.position - transform.position;
                Quaternion rotateToDoor = Quaternion.LookRotation(directionToDoor);
                animator.SetInteger("Action", 1);
                transform.rotation = rotateToDoor;
                transform.position = Vector3.MoveTowards(transform.position, frontOfDoor.position, movementStep);
                if (Vector3.Distance(transform.position, frontOfDoor.position) <= 0.2f)
                {
                    currentWaypointAI = WaypointAI.Idle;
                }
                break;
            case WaypointAI.Idle:
                animator.SetInteger("Action", 0);
                break;
            case WaypointAI.Roaming:
                animator.SetInteger("Action", 1);
                distance = Vector3.Distance(transform.position, targetWaypoint.position);
                CheckDistanceToWaypoint(distance);
                //calcuating direction to waypoints
                Vector3 directionToWaypoint = targetWaypoint.position - transform.position;
                Quaternion rotationToTarget = Quaternion.LookRotation(directionToWaypoint);
                transform.rotation = rotationToTarget;
                transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, movementStep);
                break;
            case WaypointAI.ExitPortal:
                //calcuating direction for AI to face door
                Vector3 directionToPortal = portalTransform.position - transform.position;
                Quaternion rotateToPortal = Quaternion.LookRotation(directionToPortal);
                animator.SetInteger("Action", 1);
                transform.rotation = rotateToPortal;
                transform.position = Vector3.MoveTowards(transform.position, portalTransform.position, movementStep);
                if (Vector3.Distance(transform.position, portalTransform.position) <= 0.2f)
                {
                    currentWaypointAI = WaypointAI.Idle;
                }
                break;

        }
    }

    void CheckDistanceToWaypoint(float currentDistance)
    {
        if (currentDistance <= minDistance)
        {
            targetWaypointIndex++;                                                                  //if the current distance of this object is smaller than the min distance the waypoint index will increase
            UpdateTargetWaypoint();
        }
    }

    void UpdateTargetWaypoint()
    {
        if (targetWaypointIndex > lastWaypointIndex)                                                //if the last target waypoint has been reached this object will stop
        {
            animator.SetInteger("Action", 0);
            targetWaypointIndex = 7;
            passEnum.currentAIStates = AIScript2.AIStates.InspectingDoor;
            currentWaypointAI = WaypointAI.Introduction;
            targetWaypointIndex = 0;
        }

        targetWaypoint = waypoints[targetWaypointIndex];                                            //this will update a new target waypoint if the previous waypoint has been reached
    }

}
