using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Rigidbody2D enemy;
    [SerializeField]float speed;//enemy speed
    [SerializeField] float moveRange;//this is zero for my current enemies but its the minumum point for the enemy track
    [SerializeField] float maxRange;//this is the max point for the enemy movement
    bool direction;//the direction the enemy is facing so i could flip the sprites
    void Update()
    {
        if(direction){
            enemy.velocity = new Vector2(speed,enemy.velocity.y);//moves the enemy
            moveRange-=speed;//sets new position
            if(moveRange<=0){
                direction = false;
                transform.localScale = new Vector2(1.5f,1.5f);//flips sprite 
            }
        }
        if(!direction){
            enemy.velocity = new Vector2(-speed,enemy.velocity.y);//moves in opposite direction
            moveRange+=speed;//sets new position
            if(moveRange>=maxRange){
                direction = true;
                transform.localScale = new Vector2(-1.5f,1.5f);//flips sprite
            }
        }
        
        
    }
}
