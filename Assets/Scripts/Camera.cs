using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private GameObject player;
    void Start()
    {
        player = GameObject.Find("Player");
    }

    
    void LateUpdate()
    {
        if (player != null)
        {
            transform.position = player.transform.position + new Vector3(0, 5, -8);
            transform.LookAt(player.transform.position);
        }
        
    }
}
