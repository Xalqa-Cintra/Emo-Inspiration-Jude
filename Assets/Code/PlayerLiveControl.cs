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

    public float maxSpeed = 1f;
    float camTimer;

    public bool isAlive = false;

    // Start is called before the first frame update
    void Start()
    {   
        isAlive = true;
        livingPlayer.tag = "LivePlayer";
      
    }

    // Update is called once per frame
    void Update()
    {
        camTimer = camTimer - Time.deltaTime;   

        if (isAlive == true)
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

            Vector3 newVelocity = (transform.forward * Input.GetAxis("Vertical") * maxSpeed) + (transform.right * Input.GetAxis("Horizontal") * maxSpeed);
            livingRigidbody.velocity = new Vector3(newVelocity.x, livingRigidbody.velocity.y, newVelocity.z);



        }

        if (isAlive == false)
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
        Debug.Log(camTimer);
    }
}
