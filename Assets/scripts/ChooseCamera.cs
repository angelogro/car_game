using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseCamera : MonoBehaviour
{
    public Camera followCam;
    public Camera overviewCam;
    // Start is called before the first frame update
    void Start()
    {
        followCam.GetComponent<Camera>().enabled = false;
        overviewCam.GetComponent<Camera>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("CameraSwitch"))
        {
            followCam.GetComponent<Camera>().enabled = !followCam.GetComponent<Camera>().enabled ;
            overviewCam.GetComponent<Camera>().enabled = !overviewCam.GetComponent<Camera>().enabled ;
        }
    }
}
