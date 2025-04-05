using System.Collections.Generic;
using System;
using UnityEngine;
using System.Collections;

public class SceneSequenceManager : MonoBehaviour
{
    
    // Access to camera control
    public GameObject cameraManagerGO;
    CameraManager cameraManager;

    public GameObject femaleCharacter;
    public GameObject kitchenFocus;


    public GameObject cookingTriggerGO;
    CookingTrigger cookingTrigger;
    // Scenes Event Triggers


    public bool cookingSequence;

    public bool exitSequence;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        cameraManager = cameraManagerGO.GetComponent<CameraManager>();
        cookingTrigger = cookingTriggerGO.GetComponent<CookingTrigger>();

        cookingSequence = false;
        exitSequence = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void StartIntroductionSequence()
    {
        // cameraManager.setCamera(1)
        // Start SceneDialog
        // cameraManager.setCamera(0)
        // ActivateEventFlag
        cookingSequence = true;
    }

    public void StartCookingSequence()
    {
        // Cambiar la camara
        // Desactivar el control del jugador
        // kitchenTrigger.ActivateSequenceProbs
        // wait 5 seconds
        // kitchenTrigger.DeactivateSequenceProbs
        if(cameraManager == null)
        {
            Debug.Log("Could not find camera");
        }
        cameraManager.currentTarget = kitchenFocus;
        cameraManager.SwitchCamera(1); // Kitchen camera. Also disables player movement.
        cookingTrigger.ActivateSequenceProps();


        // wait
        //cookingTrigger.DeactivateSequenceProps();
        

        Invoke("StartFirstCouchSequence", 2);
    }


    void StartFirstCouchSequence()
    {
        cookingTrigger.DeactivateSequenceProps();
        cookingSequence = false;
        // Fadein

        // Cambiar Camara
        cameraManager.SwitchCamera(2); // Kitchen camera. Also disables player movement.

        // Desactivar el control del jugador
        // Dialogo de desayuno

        // transform a modelo waifu
        cameraManager.currentTarget = femaleCharacter;
        // Fade-out
        // sonido de comer
        //cameraManager.currentTarget = femaleCharacter;
        Debug.Log("cameraManager.currentTarget = femaleCharacter;");
        StartLastCoachSequence();
    }

    void StartLastCoachSequence()
    {
        // Fadein
        // Cambiar Camara // Para que sea más dinámico
        // Desactivar el control del jugador
        // Dialogo de decoración
        // fade-out
        // darle control al jugador (change camera to 0)
        exitSequence = true;
    }


}
