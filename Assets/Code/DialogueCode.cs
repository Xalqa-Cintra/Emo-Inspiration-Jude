using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.XR;

public class DialogueCode : MonoBehaviour
{
    [Header("Variables")]
    public bool inDialogue;
    public int flamencoDialogue;
    public int mariachiDialogue;
    public bool mariachiErrand2;
    public bool canQuest;
    public bool canQuestP2;

    [Header("GameObjects")]
    public GameObject playerLive;
    public GameObject playerDead;
    public GameObject textBox;
    public GameObject textBoxBorder;

    [Header("Text")]
    public string mLine1 = "Hi there!";
    public string mLine2 = "Can you help me?";
    public string mLine3 = "I seem to have misplaced my dvd, it has my most precious memory";
    public string mLine4 = "If you find it, i would be so grateful";
    public string mLine5 = "Wait a minute. You went to the same flamenco college as me. Sm";
    public string mLine6 = "Well once you help me find this dvd, i'd love to have a dance with you";
    public string mLine7 = "Is that alright?";
    public string mLine8 = "Perfect!";
    public string mLine9 = "Aww. Maybe next time, see ya later then!";
    public string mLine10 = "Thank you, lets hurry up and find that dvd!";

    public Text textElement;

    // Start is called before the first frame update
    void Start()
    {
        textBox.SetActive(false);
        textBoxBorder.SetActive(false);
        canQuest = true;
        inDialogue = false;
        mariachiErrand2 = false;
        flamencoDialogue = 0;
        mariachiDialogue = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if(inDialogue == true && Input.GetKeyDown(KeyCode.E))
        {
            playerLive.GetComponent<PlayerLiveControl>().canMove = false;
            playerDead.GetComponent<PlayerDeadControl>().canMove = false;
            mariachiDialogue++;
            textBox.SetActive(true);
            textBoxBorder.SetActive(true);

            Dialogue();

        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if (canQuest == true || canQuestP2 == true && other.tag == "Quest 1")
        {
            inDialogue = true;
        }
    }

    private void Dialogue() 
    { 
    
        if(mariachiDialogue == 1)
        {
            textElement.text = mLine1;
        }
        if (mariachiDialogue == 2)
        {
            textElement.text = mLine2;
        }
        if (mariachiDialogue == 3)
        {
            textElement.text = mLine3;
        }
        if (mariachiDialogue == 4)
        {
            textElement.text = mLine4;
        }
        if (mariachiDialogue == 5)
        {
            textElement.text = mLine5;
        }
        if (mariachiDialogue == 6)
        {
            textElement.text = mLine6;
        }
        if (mariachiDialogue == 7)
        {
            //add multi choice ability, simply 2 buttons which go to different numbers or activate booleans and put if bool is true && int == 8
            textElement.text = mLine7;
        }
        if (mariachiDialogue == 8)
        {
            textElement.text = mLine8;
        }
        if (mariachiDialogue == 9)
        {
            textElement.text = mLine9;
        }
        if (mariachiDialogue == 10)
        {
            textElement.text = mLine10;
        }
        if (mariachiDialogue == 11)
        {
            playerLive.GetComponent<PlayerLiveControl>().canMove = true;
            playerDead.GetComponent<PlayerDeadControl>().canMove = true;
            textBox.SetActive(false);
            textBoxBorder.SetActive(false);
            inDialogue = false;
            canQuest = false;
           
        }
        //add part 2 of dialogue code, which is simply the lines of text, add multiple choice ability

    }

}
