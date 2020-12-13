using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform player;//transform variable for player 
    void Update()
    {
        transform.position = new Vector3(player.position.x,player.position.y,transform.position.z);
        //sets camera position to that of the player so camera follows
    }
}
