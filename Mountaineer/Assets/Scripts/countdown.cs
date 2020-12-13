using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class countdown : MonoBehaviour
{
    [SerializeField] float _timeToComplete;//total time for the player to reach the top......I set it to 600 seconds or 10 minutes by default
    [SerializeField] GameObject Timer;//text for timer to be displayed
    
    public float minutes;//minutes variable
    public float seconds;//seconds variable 

    void Update()
    {
        if(!gamestate.instance.isOver){//checks to see if the game is still going
            _timeToComplete -= Time.deltaTime;//updates current clock

            minutes = (int)_timeToComplete/60;//nearest minute
            seconds = (int)_timeToComplete%60;//rounds to second
            
            Timer.GetComponent<Text>().text = minutes + ":" + seconds;//formats the clock
            if(_timeToComplete < 1){//if the time is less than one second the game ends
                gamestate.instance.gameover();
                Timer.SetActive(false);//clock is turned off as it is 0 seconds
                
            }
        }
        else if(gamestate.instance.isOver){//if game is over then the timer should stop
            minutes = (int)_timeToComplete/60;//nearest minute
            seconds = (int)_timeToComplete%60;//nearest second
            Timer.GetComponent<Text>().text = minutes + ":" + seconds;//keeps the clock at what it was at the point of game over
            
        }
        
    }
    
}
