using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdSpawn : MonoBehaviour
{
    public GameObject birdObject;
    public GameObject playerLive;
    public GameObject playerDead;
    public bool spawnedBird;
    public bool atDescent;
    public float spawnTimer;

    public Transform birdPos;
    public Transform spawnPoint;
    public Transform descentPoint;
    public GameObject mission1;
    public GameObject mission2;
    public float birdTimer;
    public float flySpeed = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //setting gameobjects at runtime
        //birdPos = GameObject.FindWithTag("Bird").transform;
       


        spawnTimer = spawnTimer - Time.deltaTime;

        if(spawnTimer <= 0f && spawnedBird == false && playerLive.GetComponent<PlayerLiveControl>().sitting == true)
        {
            Instantiate(birdObject, transform.position, Quaternion.identity);
         
            spawnedBird = true;
        }



        if (spawnedBird == true)
            birdPos.position = Vector3.MoveTowards(spawnPoint.position, descentPoint.position, flySpeed);
        Debug.Log(spawnTimer);
    }



    // when in bench tag, set bool true, sets bool true in animator, plays sit animation, after certain amt of time, play sitting animation, start timer for bird spawn, when timer < 0, spawn in bird and start timer for destroy on bird, start timer for cooldown on spawner
    // spawn in, set bool true to stop multiple copies.
}
