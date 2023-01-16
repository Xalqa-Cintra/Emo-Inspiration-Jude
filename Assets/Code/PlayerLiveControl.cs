using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLiveControl : MonoBehaviour
{
    
    public GameObject livingPlayer;
    public GameObject deadPlayer;
    public GameObject livingCam;
    public GameObject deadCam;
    public Rigidbody livingRigidbody;

    public GameObject FollowingNPC;

    public float maxSpeed = 1f;
    public float rotationSpeed = 1f;
    float camTimer;

    public bool isAlive = false;
    public bool canMove;


    // Start is called before the first frame update
    void Start()
    {   
        isAlive = true;
        livingPlayer.tag = "LivePlayer";
        canMove = true;
      
    }

    // Update is called once per frame
    void Update()
    {
        camTimer = camTimer - Time.deltaTime;   

        if (isAlive == true && canMove == true)
        {
            //cam switch code (switch to dead)
            livingCam.SetActive(true);
            deadCam.SetActive(false);
            if (camTimer < 0 && Input.GetKey(KeyCode.Space))
            {
                isAlive = false;

                camTimer = 5;

                deadPlayer.GetComponent<PlayerDeadControl>().isDead = true;
            }

            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
            movementDirection.Normalize();

            transform.Translate(movementDirection * maxSpeed * Time.deltaTime, Space.World);

            if(movementDirection != Vector3.zero)
            {
                Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
            }

        }

        if (isAlive == false && canMove == true)
        { 
            //cam switch code (switch to living)
            livingCam.SetActive(false);
            deadCam.SetActive(true);
            if (camTimer < 0 && Input.GetKey(KeyCode.Space))
            {
                isAlive = true;

                camTimer = 5;

                deadPlayer.GetComponent<PlayerDeadControl>().isDead = false;
            }
            

           

        }

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "StartFollow")
        {
            FollowingNPC.GetComponent<FollowPlayerLiving>().followPlayer = true;
        }
        
        if(other.tag == "DVD")
        {
            GetComponent<DialogueCode>().canQuestP2 = true;
        }
    }

   
    


    // enter hitbox, if bool is true, setactive idle cutscene, set timer for idle cutscene slides, then start  a timer which is shown, then enter hitbox and press key, enter new cutscene
}
