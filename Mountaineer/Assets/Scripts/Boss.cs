using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] GameObject _snowball;
    float snowballCooldown = .8f;//snowball cooldown 
    float nextSnowball = 0;//Same concept as the cooldown for the jump in player.cs
    void Update()
    {
        if(Mathf.Abs(Player.instance.transform.position.x - transform.position.x) <= 12 && Mathf.Abs(Player.instance.transform.position.y - transform.position.y) <= 6){
        //sets area where snowballs will be fired if player enters based on player position relative to the boss
            if(Time.time > nextSnowball){
                //timer for snowballs so infinite snowballs arent fired
                Instantiate(_snowball,transform.position, Quaternion.identity);//instantiation of new snowball
                nextSnowball = Time.time + snowballCooldown;//setting timer
            }
        }
        
    }
}
