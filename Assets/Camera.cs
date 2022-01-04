using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject player;
    private Vector3 xyz;
    
    // Start is called before the first frame update
    void Start()
    {
        xyz = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position + xyz;
    }
}
