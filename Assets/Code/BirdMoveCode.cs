using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMoveCode : MonoBehaviour
{
   
    public Transform bird;
    public Transform birdSpawn;
    public Transform birdDescent;
    public Transform birdTarget;
    public Transform mission1;
    public Transform mission2;
    public Transform mariachiEnd;

    public GameObject player;
   

    public float birdMoveSpeed = 5f;
    public float birdDespawnTimer;
    public float birdSpawnDelay;

    public bool descended;
    public bool atTarget;
    bool setTimer;


    // Start is called before the first frame update
    void Start()
    {
        bird.position = birdSpawn.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player.GetComponent<PlayerLiveControl>().sitting == true)
        {
           
            if(setTimer == false)
            {
                birdSpawnDelay = 5f;
                setTimer = true;
            }

            birdSpawnDelay = birdSpawnDelay-Time.deltaTime;


            if (birdSpawnDelay < 0 && descended == false)
            {
                bird.position = Vector3.MoveTowards(bird.position, birdDescent.position, birdMoveSpeed);
            }
            if (birdSpawnDelay < 0 && descended == true)
            {
                bird.position = Vector3.MoveTowards(bird.position, birdTarget.position, birdMoveSpeed);
            }
        }

        if (player.GetComponent<DialogueCode>().doneFlamenco == false);
        {
            birdTarget.position = mission1.position;
        }
        if (player.GetComponent<DialogueCode>().doneFlamenco == true);
        {
            birdTarget.position = mission2.position;
        }

        if(player.GetComponent<PlayerLiveControl>().sitting == false)
        {
            bird.position = birdSpawn.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Descent")
        {
            descended = true;
        }

        if(other.tag == "Quest 1" || other.tag == "Quest 2")
        {   
            atTarget = true;
            bird.position = birdSpawn.position;
            setTimer = false;
            descended = false;
            
        }
    }


}
