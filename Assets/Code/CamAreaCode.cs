using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamAreaCode : MonoBehaviour
{
    public Transform docks;
    public Transform bridge;
    public Transform lowerJaw;
    public Transform camera;

    public bool inDock;
    public bool inBridge;
    public bool inLowerJaw; 
    //public new Vector3(0, 0, 0);

    //make 2nd vector3 saving start rotation
    // need diff vector3's for diff areas

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(inDock == true)
        {
            camera.position = docks.position;
        }
        if(inBridge == true)
        {
            camera.position = bridge.position;
        }
        if(inLowerJaw == true)
        {
            camera.position = lowerJaw.position;
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "Dockcam")
        {
            inDock = true;
            //rotate camera in these to face the subject
        }
        if(other.tag == "BridgeCam")
        {
            inBridge = true;

        }
        if(other.tag == "LowerJawCam")
        {
            inLowerJaw = true;

        }
    }
    private void OnTriggerExit(Collider other) 
    {
        if(other.tag == "DockCam")
        {
            inDock = false;
            //rotate camera in these to face the subject
        }
        if(other.tag == "BridgeCam")
        {
            inBridge = false;

        }
        if(other.tag == "LowerJawCam")
        {
            inLowerJaw = false;
            //camera.transformation.rotation = Vector3
        }
    }
}
