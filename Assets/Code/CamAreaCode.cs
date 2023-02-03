using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamAreaCode : MonoBehaviour
{
    public Transform plaza;
    public Transform theatre;
    public Transform docks;
    public Transform bridge;
    public Transform lowerJaw;
    public Transform grave;
    public Transform camera;

    public bool inPlaza;
    public bool inDock;
    public bool inBridge;
    public bool inLowerJaw; 
    public bool inGrave;
    public bool inTheatre;

    Vector3 camBridge = new Vector3(42f, 90f, 0f);
    Vector3 camDock = new Vector3(42f, 0f, 0f);
    Vector3 camLower = new Vector3(42f, 180f, 0f);


    //make 2nd vector3 saving start rotation
    // need diff vector3's for diff areas

    // Start is called before the first frame update
    void Start()
    {
        inPlaza = false;
        inDock = false;
        inBridge = false;
        inLowerJaw = false;
        inGrave = false;
        inTheatre = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(inDock == true)
        {
            camera.position = docks.position;
            camera.transform.rotation = Quaternion.Euler(camDock);
        }
        if(inBridge == true)
        {
            camera.position = bridge.position;
            camera.transform.rotation = Quaternion.Euler(camBridge);
            
        }
        if(inLowerJaw == true)
        {
            camera.position = lowerJaw.position;
            camera.transform.rotation = Quaternion.Euler(camLower);
        }
        if(inGrave == true)
        {
            camera.position = grave.position;
            camera.transform.rotation = Quaternion.Euler(camLower);
        }
        if(inPlaza == true)
        {
            camera.position = plaza.position;
            camera.transform.rotation = Quaternion.Euler(camDock);
        }
        if(inTheatre == true)
        {
            camera.position = theatre.position;
            camera.transform.rotation = Quaternion.Euler(camDock);
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "Dockcam")
        {
            inDock = true;
            
        }
        if(other.tag == "BridgeCam")
        {
            inBridge = true;

        }
        if(other.tag == "LowerJawCam")
        {
            inLowerJaw = true;

        }
        if(other.tag == "GraveCam")
        {
            inGrave = true;
        }
        if(other.tag == "PlazaCam")
        {
            inPlaza = true;
        }
        if(other.tag == "TheatreCam")
        {
            inTheatre = true;
        }
    }
    private void OnTriggerExit(Collider other) 
    {
        if(other.tag == "Dockcam")
        {
            inDock = false;
            
        }
        if(other.tag == "BridgeCam")
        {
            inBridge = false;

        }
        if(other.tag == "LowerJawCam")
        {
            inLowerJaw = false;
            
        }
        if(other.tag == "GraveCam")
        {
            inGrave = false;
        }
        if(other.tag == "PlazaCam")
        {
            inPlaza = false;
        }
        if(other.tag == "TheatreCam")
        {
            inTheatre = false;
        }
    }
}
