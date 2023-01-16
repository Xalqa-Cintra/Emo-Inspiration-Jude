using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.XR;


public class MissionScreen : MonoBehaviour
{
    [Header("Menu")]
    public GameObject openPhone;
    public GameObject missionUI;
    public GameObject note1;
    public GameObject note2;
    public GameObject note3;
    public GameObject note4;
    public GameObject note5;
    public GameObject returnButton;
    public GameObject closePhone;
    public GameObject HUD;

    [Header("Errand Tab")]
    public GameObject errandUI;
    public GameObject errandTextBox;

    [Header ("Text")]
    public string errand1Text = ("Go help the bullfighter, More will be added in the full game");
   
    public string errand3Text = ("Go fix the bridge");
    public string errand4Text = ("Go help the elderly");
    public string errand5Text = ("Go save Mr. Mariachi");

    [Header ("Flamenco phases")]
    public string errand2Text = ("Go help the Flamenco dancer");
    public string errand2p2Text = ("");
    public string errand2p3Text = ("");

    [Header ("Variables")]
    public bool flamencoPart2;
    public bool flamencoPart3;

    

    Text textElement;

    private void Start() 
    {
        missionUI.SetActive(false);
        errandUI.SetActive(false);
        returnButton.SetActive(false);
        textElement = errandTextBox.GetComponent<Text>();

    }
    

    public void OpenMenu()
    {
        openPhone.SetActive(false);
        missionUI.SetActive(true);
        HUD.SetActive(false);


    }
    
    public void CloseMenu()
    {
        missionUI.SetActive(false);
        openPhone.SetActive(true);
        errandUI.SetActive(false);
        HUD.SetActive(true);
    }

    public void OpenNote()
    {
        missionUI.SetActive(false);
        errandUI.SetActive(true);
        returnButton.SetActive(true);
        errandTextBox.SetActive(true);
    }
    public void OpenNote1() 
    {
        //bullfighter
        textElement.text = errand1Text;
        //if(missioncheckbool=true){settexttothis}

    }
    public void OpenNote2() 
    {
        //flamenco
        if(flamencoPart2 == false && flamencoPart3 == false)
        {
           textElement.text = errand2Text; 
        }
        if(flamencoPart2 == true && flamencoPart3 == false)
        {
           textElement.text = errand2p2Text; 
        }
        if(flamencoPart2 == true && flamencoPart3 == true)
        {
           textElement.text = errand2p3Text; 
        }
        

    }
    public void OpenNote3() 
    {
        //bridge
        textElement.text = errand3Text;
        //if(missioncheckbool=true){settexttothis}

    }
    public void OpenNote4() 
    {
        //elders
        textElement.text = errand4Text;
        //if(missioncheckbool=true){settexttothis}

    }
    public void OpenNote5() 
    {
        //mariachi
        textElement.text = errand5Text;
        //if(missioncheckbool=true){settexttothis}

    }

    public void returnScreen()
    {
        errandUI.SetActive(false);
        missionUI.SetActive(true);
        errandTextBox.SetActive(false);
    }

}
