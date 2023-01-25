using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamAreaCode : MonoBehaviour
{
    public Transform docks;
    public Transform bridge;
    public Transform lowerJaw;
    public Transform camera;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "DockCam")
        {
            camera.position = docks.position;
            //rotate camera in these to face the subject
        }
        if(other.tag == "BridgeCam")
        {
            camera.position = bridge.position;

        }
        if(other.tag == "LowerJawCam")
        {
            camera.position = lowerJaw.position;

        }
    }
}
