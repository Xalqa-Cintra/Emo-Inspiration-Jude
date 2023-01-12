using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;


public class MissionScreen : MonoBehaviour
{
    [Header("Menu")]
    public GameObject missionUI;
    public GameObject note1;
    public GameObject note2;
    public GameObject note3;
    public GameObject note4;
    public GameObject note5;
    public GameObject returnButton;
    public GameObject closePhone;

    [Header("Errand Tab")]
    public GameObject errandUI;
    public GameObject errand1text;
    public GameObject errand2text;
    public GameObject errand3text;
    public GameObject errand4text;
    public GameObject errand5text;

    private void Start() 
    {
        missionUI.SetActive(false);
        errandUI.SetActive(false);
    }
    

    public void OpenMenu()
    {
        missionUI.SetActive(true);

    }
    
    public void CloseMenu()
    {
        missionUI.SetActive(false);

        errandUI.SetActive(false);
    }

    public void OpenNote()
    {
        missionUI.SetActive(false);

        errandUI.SetActive(true);
    }
    public void OpenNote1() 
    {

        errand1text.SetActive(true);
        //if(missioncheckbool=true){settexttothis}

    }
    public void OpenNote2() 
    {

        errand2text.SetActive(true);
        //if(missioncheckbool=true){settexttothis}

    }
    public void OpenNote3() 
    {

        errand3text.SetActive(true);
        //if(missioncheckbool=true){settexttothis}

    }
    public void OpenNote4() 
    {

        errand4text.SetActive(true);
        //if(missioncheckbool=true){settexttothis}

    }
    public void OpenNote5() 
    {

        errand5text.SetActive(true);
        //if(missioncheckbool=true){settexttothis}

    }

}
