using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamara : MonoBehaviour
{
    //public Transform camaraPosition;
    //public Transform currentCameraMan;
    public GameObject cameraManagerGO;
    CameraManager cameraManager;
    // Start is called before the first frame update
    void Start()
    {
        //playerCam = true;
        cameraManager = cameraManagerGO.GetComponent<CameraManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cameraManager.freeCamera)
        {
            // REFACTOR LATER

            // transform.position = camaraPosition.position;
            transform.position = cameraManager.currentCamera.transform.position;
        }
        else
        {
            //transform.position = currentCameraMan.position;
            transform.position = cameraManager.currentCamera.transform.position;
        }
    }
}
