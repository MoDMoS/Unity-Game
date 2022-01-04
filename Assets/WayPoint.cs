using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour {

    public Transform WaypointsParent;
    public Transform[] Waypoints;
    public Transform targetWP;

    public int targetWPIndex;

    public float movementSpeed = 30.0f;
    public float rotationSpeed = 10.0f;
    public float Distance = 0f;

	void Start () {
        GetWaypoints();
        targetWP = Waypoints[targetWPIndex];
	}
	
	// Update is called once per frame
	void Update () {
        FollowWayPoints();
	}
    void FollowWayPoints(){
        Distance = Vector3.Distance(transform.position,Waypoints[targetWPIndex].position);

        if(Distance > 1f){

            Vector3 direction = (targetWP.position - transform.position).normalized;

            transform.Translate(direction * movementSpeed * Time.deltaTime, Space.World);
            transform.position = new Vector3(transform.position.x,0.5f,transform.position.z);
        }
        else{
            targetWPIndex++;

            if (targetWPIndex == Waypoints.Length)
            {
                targetWPIndex = 0;
            }
        }
        targetWP = Waypoints[targetWPIndex];
    }

    void GetWaypoints(){
        int num0fwp = WaypointsParent.childCount;

        Waypoints = new Transform[num0fwp];

        for (int i =0;i<Waypoints.Length;i++)
        {
            Waypoints[i] = WaypointsParent.GetChild(i);
        }
    }
}