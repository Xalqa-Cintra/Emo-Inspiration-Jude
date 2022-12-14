using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class PlayerDeadControl : MonoBehaviour
{
    public GameObject deadPlayer;
    public GameObject livingPlayer;
    public GameObject deadCam;
    public Rigidbody deadRigidbody;

    public float maxSpeed = 1f;

    public bool isDead;

    
    

    // Start is called before the first frame update
    void Start()
    {
        deadPlayer.tag = "DeadPlayer";
    }
 

    // Update is called once per frame
    void Update()
    {
        if (isDead == true)
        {
            Vector3 newVelocity = (transform.forward * Input.GetAxis("Vertical") * maxSpeed) + (transform.right * Input.GetAxis("Horizontal") * maxSpeed);
            deadRigidbody.velocity = new Vector3(newVelocity.x, deadRigidbody.velocity.y, newVelocity.z);
        }

    }
}
