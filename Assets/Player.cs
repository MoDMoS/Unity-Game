using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    public Board currentRoute;
    public int routePosition;
    public int steps;
    bool isMoving;
    private int num;
    public TextMeshProUGUI Texts;
    public GameObject avatar1;

    public void Random()
    {
        steps = UnityEngine.Random.Range(1,7);
        num = 1;
        Texts.GetComponent<TextMeshProUGUI>().text = steps.ToString();

            if(routePosition+steps <currentRoute.childNodeList.Count)
            {
                StartCoroutine(Move());
            }
            else
            {
                Debug.Log("Rolled Number is to high");
            }
        num = 0;
        
    }
    public void Random1()
    {
        steps = 1;
        if(routePosition+steps <currentRoute.childNodeList.Count)
        {
            StartCoroutine(Move());
        }
        else
        {
            Debug.Log("Rolled Number is to high");
        }
        
    }
    public void Random2()
    {
        steps = 1;
        if(routePosition+steps <currentRoute.childNodeList.Count)
        {
            StartCoroutine(Move1());
        }
        else
        {
            Debug.Log("Rolled Number is to high");
        }
        
    }
        
    IEnumerator Move()
    {
        if(num == 1)
        {
            yield return new WaitForSeconds(1f);
        }
        if (isMoving)
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
        yield return new WaitForSeconds(1f);
        avatar1.gameObject.SetActive(false);
        
    }
    bool MoveToNextNode(Vector3 goal)
    {
            return goal != (transform.position = Vector3.MoveTowards(transform.position,goal,200f * Time.deltaTime));
    }

    IEnumerator Move1()
    {
        if (isMoving)
        {
            yield break;
        }
        isMoving = true;
        while(steps>0)
        {
            Vector3 nextPos = currentRoute.childNodeList[routePosition - 1].position;
            while(MoveToNextNode1(nextPos))
            {
                yield return null;
            }
            yield return new WaitForSeconds(0.1f);
            steps--;
            routePosition--;
        }
        isMoving = false;
        avatar1.gameObject.SetActive(false);
    }
    bool MoveToNextNode1(Vector3 goal)
    {

        return goal != (transform.position = Vector3.MoveTowards(transform.position,goal,200f * Time.deltaTime));
    }
}
