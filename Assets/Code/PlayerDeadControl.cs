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
    public Animator myAnim;
    public GameObject FollowingNPC;

    public float maxSpeed = 1f;
    public float rotationSpeed = 1f;

    public bool isDead;
    public bool canMove;
    
    

    // Start is called before the first frame update
    void Start()
    {
        deadPlayer.tag = "DeadPlayer";
        canMove = true;
    }
 

    // Update is called once per frame
    void Update()
    {
        if (isDead == true && canMove == true)
        {
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
            myAnim.SetFloat("Speed", deadRigidbody.velocity.magnitude);
        }

    }
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "StartFollow")
        {
            FollowingNPC.GetComponent<FollowPlayerLiving>().followPlayer = true;
        }
         if(other.tag == "Quest 1")
        {
            Debug.Log ("quest start");
        }
    }
}
