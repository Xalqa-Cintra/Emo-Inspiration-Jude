using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdSpawn : MonoBehaviour
{
    public GameObject birdObject;
    public GameObject playerLive;
    public GameObject playerDead;
    public bool spawnbird;
    public bool spawnedBird;
    public float spawntimer;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(spawnTimer < 0)
        {
             Instantiate(birdObject, transform.position, Quaternion.identity);
        }
    }



    // when in bench tag, set bool true, sets bool true in animator, plays sit animation, after certain amt of time, play sitting animation, start timer for bird spawn, when timer < 0, spawn in bird and start timer for destroy on bird, start timer for cooldown on spawner
    // spawn in, set bool true to stop multiple copies.
}
