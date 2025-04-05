using System.Collections.Generic;
using System;
using UnityEngine;

public class SceneSequenceManager : MonoBehaviour
{

    // Access to camera control
    public GameObject cameraManagerGO;
    CameraManager cameraManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cameraManager = cameraManagerGO.GetComponent<CameraManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void StartIntroductionScene()
    {

    }

    void StartCookingScene()
    {

    }
    void StartCouchScene()
    {

    }


}
