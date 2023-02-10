using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.XR;

public class DialogueCode : MonoBehaviour
{
    [Header("Variables")]
    public int musicianDialogue;
    public int flamencoDialogue;
    public bool flamencoErrand2;
    public bool canQuest;
    public bool canQuestP2Flamenco;
    public bool canQuestP2Mariachi;
    public bool yes;
    public bool no;
    public bool inChoice;
    public bool inDialogue;
    public bool inDialogueFlamenco;
    public bool inDialogueMariachi;
    public bool doneFlamenco;
    public bool doneMariachi;
    public float timerTime;
    public bool timerStart;
    public bool timerCountDownStart;

    [Header("GameObjects")]
    public GameObject playerLive;
    public GameObject playerDead;
    public GameObject bird;
    public GameObject textBox;
    public GameObject textBoxBorder;
    public GameObject yesButton;
    public GameObject noButton;
    public GameObject Canvas;
    public GameObject dvdObject;
    public GameObject End;
    public GameObject timerBox;
    public GameObject mariachiQuestBox;
    public AudioClip notif; 
    public AudioSource phoneIcon;

    [Header("Flamenco Text")] // got mixed up while codin
    public string[] mLines;

    [Header("Mariachi Text")] // got mixed up while codin
    public string[] fLines;

    [Header("Yes/No text options")]
    public string yesFlamenco;
    public string noFlamenco;
    public string yesMusician;
    public string noMusician;

    public Text yesoption;
    public Text nooption;

    public Text textElement;
    public Text timerText;

    // Start is called before the first frame update
    void Start()
    {
        dvdObject.SetActive(false);
        textBox.SetActive(false);
        textBoxBorder.SetActive(false);
        canQuest = true;
        inDialogue = false;
        flamencoErrand2 = false;
        yes = false;
        no = false;
        musicianDialogue = 0;
        flamencoDialogue = 0;
        yesButton.SetActive(false);
        noButton.SetActive(false);
        inChoice = false;
        End.SetActive(false);
        timerBox.SetActive(false);
        mariachiQuestBox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (inDialogue == true)
        {
            EnterDialogue();
            
            if (inDialogueFlamenco == true)
            {

                if (inChoice == false && Input.GetKeyDown(KeyCode.Return))
                {
                    flamencoDialogue++;
                }
                DialogueFlamenco();

            }
            if (inDialogueMariachi == true)
            {

                if (inChoice == false && Input.GetKeyDown(KeyCode.Return))
                {
                    musicianDialogue++;
                }
                DialogueMariachi();

            }
        }

        if(doneFlamenco == true)
        {
            bird.GetComponent<BirdMoveCode>().moveToMari = true;
            bird.GetComponent<BirdMoveCode>().moveToFlam = false;
        }

         if(timerStart == true)
        {
            if(timerCountDownStart == false)
            {
                timerTime = 60f;
                timerCountDownStart = true;
            } 
            timerBox.SetActive(true);
            timerText.text = "Time:" + timerTime.ToString("0.00");
            timerTime = timerTime - Time.deltaTime;

            if(timerTime < 0)
            {
                timerBox.SetActive(false);
                timerStart = false;
                
            }
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if ((canQuest == true || canQuestP2Flamenco == true) && other.tag == "Quest 1" && doneFlamenco == false)
        {
            inDialogue = true;
            inDialogueFlamenco = true;
        }
        if((canQuest == true || canQuestP2Mariachi == true) && (other.tag == "Quest 2" || other.tag == "MariachiEnd") && doneMariachi == false)
        {
            inDialogue = true;
            inDialogueMariachi = true;
        }
    }

    private void DialogueFlamenco() 
    { 
        switch (flamencoDialogue)
        {
            case 0:
                textElement.text = mLines[0];
                break;
            case 1:
                textElement.text = mLines[1];
                break;
            case 2:
                textElement.text = mLines[2];
                break;
            case 3:
                textElement.text = mLines[3];
                break;
            case 4:
                textElement.text = mLines[4];
                break;
            case 5:
                textElement.text = mLines[5];
                break;
            case 6:
                textElement.text = mLines[6];
                yesoption.text = yesFlamenco;
                nooption.text = noFlamenco;
                yesButton.SetActive(true);
                noButton.SetActive(true);
                inChoice = true;
                break;
            case 7 when yes:
                textElement.text = mLines[7];
                break;
            case 7 when no:
                textElement.text = mLines[8];
                break;
            case 8 when yes:
                textElement.text = mLines[9];
                break;
            case 8 when no:
                ExitDialogue();
                flamencoDialogue = 0;
                canQuest = true;
                break;
            case 9:
                flamencoDialogue++;
                Canvas.GetComponent<MissionScreen>().flamencoPart2 = true;
                canQuest = false;
                dvdObject.SetActive(true);
                ExitDialogue();
                break;
            case 10:
                textElement.text = mLines[10];
                break;
            case 11:
                textElement.text = mLines[11];
                break;
            case 12:
                textElement.text = mLines[12];
                break;
            case 13:
                textElement.text = mLines[13];
                doneFlamenco = true;
                Canvas.GetComponent<MissionScreen>().flamencoPart3 = true;
                break;
            case 14:  
                canQuest = true;
                canQuestP2Flamenco = false;
                inDialogueFlamenco = false;
                doneFlamenco = true;
                mariachiQuestBox.SetActive(true);
                bird.GetComponent<BirdMoveCode>().forcedTravel = true;
                ExitDialogue();
                break;
            default:
                break;
        }
    }

    private void DialogueMariachi()
    {
        switch (musicianDialogue)
        {
            case 0:
                textElement.text = fLines[0];
                break;
            case 1:
                textElement.text = fLines[1];
                break;
            case 2:
                textElement.text = fLines[2];
                break;
            case 3:
                textElement.text = fLines[3];
                break;
            case 4:
                textElement.text = fLines[4];
                break;
            case 5:
                textElement.text = fLines[5];
                yesoption.text = yesMusician;
                nooption.text = noMusician;
                yesButton.SetActive(true);
                noButton.SetActive(true);
                inChoice = true;
                break;
            case 6 when yes:
                textElement.text = fLines[6];
                break;
            case 6 when no:
                textElement.text = fLines[7];
                break;
            case 7 when yes:
                textElement.text = fLines[8];
                break;
            case 7 when no:
                textElement.text = fLines[9];
                break;
            case 8:
                textElement.text = fLines[10];
                break;
            case 9:
                musicianDialogue++;
                Canvas.GetComponent<MissionScreen>().mariachiPart2 = true;
                canQuest = false;
                End.SetActive(true);
                timerStart = true;
                ExitDialogue();
                break;
            case 10:
                textElement.text = fLines[11];
                break;
            case 11:
                textElement.text = fLines[12];
                break;
            case 12:
                textElement.text = fLines[13];
                break;
            case 13:
                textElement.text = fLines[14];
                doneMariachi = true;
                Canvas.GetComponent<MissionScreen>().mariachiPart3 = true;
                break;
            case 14:
                ExitDialogue();
                break;
        }
    }
    private void EnterDialogue()
    {
        playerLive.GetComponent<PlayerLiveControl>().canMove = false;
        playerDead.GetComponent<PlayerDeadControl>().canMove = false;
        textBox.SetActive(true);
        textBoxBorder.SetActive(true);
    }

    private void ExitDialogue()
    {
        playerLive.GetComponent<PlayerLiveControl>().canMove = true;
        playerDead.GetComponent<PlayerDeadControl>().canMove = true;
        textBox.SetActive(false);
        textBoxBorder.SetActive(false);
        inDialogue = false;
        yes = false;
        no = false;
        phoneIcon.PlayOneShot(notif);
    }

    public void ButtonYesFlamenco()
    {
        if(inDialogueFlamenco == true)
        {
        yes = true;
        flamencoDialogue++;
        yesButton.SetActive(false);
        noButton.SetActive(false);
        inChoice = false;
        }

        if(inDialogueMariachi == true)
        {
            yes = true;
            musicianDialogue++;
            yesButton.SetActive(false);
            noButton.SetActive(false);
            inChoice = false;
        }
       
        
    }

    public void ButtonNoFlamenco()
    {
        if(inDialogueFlamenco)
        {
        no = true;
        flamencoDialogue++;
        yesButton.SetActive(false);
        noButton.SetActive(false);
        inChoice = false;
        }

        if(inDialogueMariachi)
        {
            no = true;
            musicianDialogue++;
            yesButton.SetActive(false);
            noButton.SetActive(false);
            inChoice = false;
        }
     
    }

}
