using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionScreen : MonoBehaviour
{
    public GameObject missionUI;
    public GameObject note1;
    public GameObject note2;
    public GameObject note3;
    public GameObject note4;
    public GameObject note5;
    public GameObject returnButton;
    public GameObject closePhone;

    private void Start() 
    {
        missionUI.setActive(false);
        note1.setActive(false);
        note2.setActive(false);
        note3.setActive(false);
        note4.setActive(false);
        note5.setActive(false);
        returnButton.setActive(false);
        closePhone.setActive(false);
        
    }
    

    public void OnButtonPress()
    {
        missionUI.setActive(true);
        note1.setActive(true);
        note2.setActive(true);
        note3.setActive(true);
        note4.setActive(true);
        note5.setActive(true);
        returnButton.setActive(true);
        closePhone.setActive(true);
    }

}
