using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snowball : MonoBehaviour
{
    static System.Random rnd = new System.Random();//creates random rnd
    float randX = rnd.Next(-5,5);//rand between -5 and 5
    float randY = rnd.Next(-5,-1);//rand between -5 and -1


    void Update()
    {
        transform.position += new Vector3(Time.deltaTime * randX, Time.deltaTime * randY,0);

        
    }
}