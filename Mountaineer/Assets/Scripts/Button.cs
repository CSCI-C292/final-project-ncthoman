using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField]GameObject _instructions;
    //set _instructions to text of instructions on a serialized field

    bool isActive = false;//boolean for toggling active below
    public void toggleScript(){//set active or not on button press
        if(isActive){
            _instructions.SetActive(isActive);//set active
            isActive = false;//set switch
        }
        else{
            _instructions.SetActive(isActive);//set inactive
            isActive = true;//set switch
        }
    }
   
}
