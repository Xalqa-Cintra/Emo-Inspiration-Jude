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
    public GameObject photo;

    [Header("Errand Tab")]
    public GameObject errandUI;
    public GameObject errandTextBox;

    [Header ("Text")]
    public string errand1Text = ("Go help the bullfighter, More will be added in the full game");
    public string errand3Text = ("Go fix the bridge");
    public string errand4Text = ("Go help the elderly");
    
    [Header ("Flamenco phases")]
    public string errand2Text = ("Go help the Flamenco dancer");
    public string errand2p2Text = ("");
    public string errand2p3Text = ("");

    [Header("Mariachi phases")]
    public string errand5Text = ("Go save Mr. Mariachi");
    public string errand5p2Text;
    public string errand5p3Text;

    [Header ("Variables")]
    public bool flamencoPart2;
    public bool flamencoPart3;
    public bool mariachiPart2;
    public bool mariachiPart3;
    public bool note1Open;
    public bool note2Open;
    public bool note3Open;
    public bool note4Open;
    public bool note5Open;

    [Header ("Materials for photos")]
    public Material photoBull;
    public Material photoFlamenco;
    public Material photoElders;
    public Material photoMariachi;

    [Header ("Audio")]
    public AudioClip bull;
    public AudioClip flam;
    public AudioClip elder;
    public AudioClip Music;
    public AudioSource photoButton;

    Text textElement;

    private void Start() 
    {
        photo.SetActive(false);
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
    {//bullfighter
        textElement.text = errand1Text;
        photo.SetActive(true);
        note1Open = true;
    }
    public void OpenNote2() 
    {//flamenco
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
           photo.SetActive(true);
           //set photo material to photo
        }
        note2Open = true;
    }
    public void OpenNote3() 
    {//bridge
        textElement.text = errand3Text;
        //if(missioncheckbool=true){settexttothis}
        note3Open = true;
    }
    public void OpenNote4() 
    {//elders
        textElement.text = errand4Text;
        //if(missioncheckbool=true){settexttothis}
        photo.SetActive(true);
        note4Open = true;
    }
    public void OpenNote5()
    { //Mariachi
        if (mariachiPart2 == false && mariachiPart3 == false)
        {
            textElement.text = errand5Text;
        }
        if (mariachiPart2 == true && mariachiPart3 == false)
        {
            textElement.text = errand5p2Text;
        }
        if (mariachiPart2 == true && mariachiPart3 == true)
        {
            textElement.text = errand5p3Text;
            photo.SetActive(true);
            //set photo material to photo
            note5Open = true;
        }
    }
    public void returnScreen()
    {
        errandUI.SetActive(false);
        missionUI.SetActive(true);
        errandTextBox.SetActive(false);
        photo.SetActive(false);
        note1Open = false;
        note2Open = false;
        note3Open = false;
        note4Open = false;
        note5Open = false;
    }   
    public void MusicButton()
    {
        if(note1Open == true)
        {
            photoButton.clip = bull;   
            photoButton.Play();
        }
        if(note2Open == true)
        {
            photoButton.clip = flam;
            photoButton.Play();
        }
        if(note4Open == true)
        {
            photoButton.clip = elder;
            photoButton.Play();
        }
        if(note5Open == true)
        {
            photoButton.clip = Music;
            photoButton.Play();
        }
    }

}
