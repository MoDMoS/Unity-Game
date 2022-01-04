using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMoveControl : MonoBehaviour
{
    public Board currentRoute;
    int routePosition;
    public int steps;
    bool isMoving;

    public void Random1()
    {
        if(routePosition+steps <currentRoute.childNodeList.Count)
        {
            StartCoroutine(Move());
        }
        else
        {
            Debug.Log("Rolled Number is to high");
        }
        
    }
        
    IEnumerator Move()
    {
        if(isMoving)
        {
            yield break;
        }
        isMoving = true;
        while(steps>0)
        {
            Vector3 nextPos = currentRoute.childNodeList[routePosition + 1].position;
            while(MoveToNextNode(nextPos))
            {
                yield return null;
            }
            yield return new WaitForSeconds(0.1f);
            steps--;
            routePosition++;
        }
        isMoving = false;
    }
    bool MoveToNextNode(Vector3 goal)
    {
            return goal != (transform.position = Vector3.MoveTowards(transform.position,goal,200f * Time.deltaTime));
    }
}
