using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollowCode : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

public Transform player;

    // Update is called once per frame
    void Update () {
        transform.position = player.transform.position + new Vector3(0, 18, -7);
    }
    
    
    
    // when in certain hitboxes, set rotations
     


}
