using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerLiving : MonoBehaviour
{
    public float moveSpeed = 0.1f;
    public Transform myNPC;
    public Transform myFollowPoint;

    public bool followPlayer = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(followPlayer == true)
        {
            myNPC.position = Vector3.MoveTowards(myNPC.position, myFollowPoint.position, moveSpeed);
        }
    }
}
