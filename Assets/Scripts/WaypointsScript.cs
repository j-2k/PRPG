using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointsScript : MonoBehaviour
{
    public List<Transform> waypoints = new List<Transform>();                               //making a public list of transforms for setting waypoints
    Transform targetWaypoint;
    int targetWaypointIndex = 0;
    float minDistance = 0.1f;
    int lastWaypointIndex;
    Animator animator;
    float movementStep;
    float distance;
    AIScript passEnum;

    public float speed = 4f;

    void Start()
    {
        passEnum = GetComponent<AIScript>();
        animator = GetComponent<Animator>();
        lastWaypointIndex = waypoints.Count - 1;                                            //minusing by 1 because waypoints system starts at 0
        targetWaypoint = waypoints[targetWaypointIndex];                                    //matching the transform to the waypointsindex
    }

    void Update()
    {
        animator.SetInteger("Action", 1);                                                   //changing animator to the moving animation

        //ROTATION CALCUATION
        Vector3 directionToWaypoint = targetWaypoint.position - transform.position;         //calcuating the direction vector from the point minus this object
        Quaternion rotationToTarget = Quaternion.LookRotation(directionToWaypoint);         //storing a quaternion to the calcuated direction vector in the previous line
        transform.rotation = rotationToTarget;                                              //using lookrotation function now which is being calcuated from line26

        movementStep = speed * Time.deltaTime;                                              
        distance = Vector3.Distance(transform.position, targetWaypoint.position);           
        CheckDistanceToWaypoint(distance);                                                  //keeps checking the distance between the distance of this object & the target waypoint

        transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, movementStep); // moves this object to the targetwaypoints position
    }

    void CheckDistanceToWaypoint(float currentDistance)
    {
        if(currentDistance <= minDistance)
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
            speed = 0;
            targetWaypointIndex = 2;
            passEnum.currentAIStates = AIScript.AIStates.Waiting;
            //targetWaypointIndex = 0;
        }

        targetWaypoint = waypoints[targetWaypointIndex];                                            //this will update a new target waypoint if the previous waypoint has been reached
    }

}
