using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gamestate : MonoBehaviour
{
    public bool isOver = false;//bool for the countdown
    public int lives = 1;//starting lives
    public int ability = 1;//starting ability level
    public static gamestate instance;//singleton
    //The following four lines are for the various UI elements that are displayed to the player, other than the instructions
    [SerializeField] GameObject _livesText;
    [SerializeField] GameObject _abilityText;
    [SerializeField] GameObject _gameOverText;
    [SerializeField] GameObject _gameoverSuccessText;
    private void Awake() {//sets singleton to this
        instance = this;
    }
    public void addLives(int x){
        lives += x;//adds life
        _livesText.GetComponent<Text>().text = "Lives: " + lives;//updates text
    }
    public void removeLives(int z){
        lives -= z;//removes life
        _livesText.GetComponent<Text>().text = "Lives: "+ lives;//updates text
        if(lives == 0){//checks if lifes = 0 if so then initiates game over
            gameover();
        }
    }
    public void addAbility(int y){
        ability += y;//adds ability
        _abilityText.GetComponent<Text>().text = "Ability Level: " + ability;//updates text

    }
    void Update() {
        if(Input.GetKeyDown(KeyCode.R)){// checks to see if r is pressed and if so reloads the game
        //I did not include the isOver bool here because my game is a bit difficult so I thought making it so you can restart whenever is smart
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);//reloads scene
        }
    }
    
    public void gameover(){//initiates game over
        _gameOverText.SetActive(true);//makes game over text readable
        _abilityText.SetActive(false);//removes ability text
        _livesText.SetActive(false);//removes lives text
        Destroy(Player.instance);//destroys the instance of the player so they cannot keep moving
        isOver = true;//sets is over to true for the player and countdown
    } 
    public void gameoverSuccess(){
        _gameoverSuccessText.SetActive(true);//makes game over succesful text readable
        _abilityText.SetActive(false);//removes ability text
        _livesText.SetActive(false);//removes lives text
        Destroy(Player.instance);//destroys the instance of the player so they cannot keep moving
        isOver = true;//sets is over to true for the player and countdown
    }
}
