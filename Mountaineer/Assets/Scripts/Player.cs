using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;//singleton of player
    public Rigidbody2D player;//player for position ect
    public float jumpCool = 1f;//jump time cooldown
    public float nextJump = 0;//set 0 for timer
    public Animator animate;//animator
    [SerializeField] float speed;//speed of player
    [SerializeField] GameObject _gamestate;//gamestate
    [SerializeField] GameObject _bossLock;//boundary for boss fight so the boss must be defeated
    public enum currentState{ isStill, isRunning, isJumping}//enums for Finite states 
    public currentState actual = currentState.isStill;//standard set to isStill
    private void Awake() {
        
        instance = this;//singleton = this
    }
   
    void Update()
    {
        
        if(Input.GetKey(KeyCode.A))//left movement
        {
            player.velocity = new Vector2(-speed,player.velocity.y);//vector of movement
            transform.localScale = new Vector2(-1, 1);//sets sprite direction
            if(Mathf.Abs(player.velocity.y) < 0.1){//checks for left velocity for run animation
                actual = currentState.isRunning;//sets to isrunning
            }
            
        }
        else if(Input.GetKey(KeyCode.D))//Right movement
        {
            player.velocity = new Vector2(speed,player.velocity.y);//vector of movement
            transform.localScale = new Vector2(1, 1);//sets sprite direction
            if(Mathf.Abs(player.velocity.y) < 0.1){//checks for left velocity for run animation
                actual = currentState.isRunning;//sets to isrunning
            }

        }
        
        if(Time.time > nextJump){//jump timer check
            if(Input.GetKeyDown(KeyCode.Space))//jump movement
            {
                 player.velocity = new Vector2(player.velocity.x, 7f);//vector of movement
                 actual = currentState.isJumping;//sets state to isJumping
                 nextJump = Time.time + jumpCool;//starts cooldown

            }
        }
        if(Input.GetKey(KeyCode.S))//downward movement
        {
            player.velocity = new Vector2(player.velocity.x, -5f);//downwards velocity vector
        }
        States();//runs states function

        animate.SetInteger("State", (int)actual);//sets animate to the integer of the enum
    }
    void States(){//checks states
        if(actual == currentState.isJumping){

        }
        else if(Mathf.Abs(player.velocity.x) < .1f){
            actual = currentState.isStill;
        }

    }
    private void OnTriggerEnter2D(Collider2D other) {//all collisions with sprites
        Debug.Log(other.name);

        if(other.tag == "life"){//the candycanes are tagged with "life"
            gamestate.instance.addLives(1);//adds one life to the player
            Destroy(other.gameObject);//destroys the candycane
        }

        if(other.name == "Ability"){//checks for sprite name "Ability", the prefab is two parts the name ability is given to the candy part of the lollipop
            gamestate.instance.addAbility(1);//adds one ability level
            Destroy(other.gameObject);//destroys the candy part and leaves the stick
        }

        if(other.name == "Death"){//boundaries are labeled with an internal sprite called death that sets player boundaries and spikes ect....
            gamestate.instance.removeLives(1);//removes one life
            transform.position = new Vector3(-2.24f,2.03f,0);//sets position to the start
        }

        if(other.name == "Enemy"){//if name is enemy
            if(actual == currentState.isStill || actual == currentState.isJumping){//checks state of player... if jumping or falling (still in air) the player can kill
                 Destroy(other.gameObject);//destroys enemy
            }
            else if(actual == currentState.isRunning){//if the player is in the running state 
                gamestate.instance.removeLives(1);//remove 1 life
                transform.position = new Vector3(-2.24f,2.03f,0);//respawn
            }
            else{   
                gamestate.instance.removeLives(1);//remove a life
                transform.position = new Vector3(-2.24f,2.03f,0);//respawn... just covers else if above just in case
            }
        }

        if(other.tag == "Boss" ){//if tag is boss 
            if((actual == currentState.isStill || actual == currentState.isJumping)&& gamestate.instance.ability >= 3){//the player must be jumping and have abnility level of 3 or higher
                Destroy(other.gameObject);// boss is deleted 
                Destroy(_bossLock);//the wall separating the player from the end is removed 
            }
            else if(actual == currentState.isRunning||gamestate.instance.ability <= 3){//if the player is running or has a low ability level 
                gamestate.instance.removeLives(1);//remove 1 life
                transform.position = new Vector3(-2.24f,2.03f,0);//reset player position
            }
        }

        if(other.tag == "snowball"){//if tag is snowball
            gamestate.instance.removeLives(1);//remove a life
            transform.position = new Vector3(-2.24f,2.03f,0);//reset player position  
        }

        if(other.name == "Success"){
            gamestate.instance.gameoverSuccess();//if igloo is reached the game ends and calls gameoverSuccess()
        }
        
    }
    
}
