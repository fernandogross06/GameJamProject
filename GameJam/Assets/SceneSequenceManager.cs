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

        cookingSequence = true; // CAMBIAR LUEGO
        exitSequence = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void StartIntroductionSequence()
    {
        // cameraManager.setCamera(1)

        // Camera aiming at Female Character. Also disables player movement.
        cameraManager.SwitchCamera(2);
        cameraManager.currentTarget = femaleCharacter;

        // Start SceneDialog #1

        // ACÁ SE AGREGA EL DIALOGO



        // Cuando termine, permitir cocinar

        cookingSequence = true;

        // Camara en 0 para darle libertad al jugador y que vaya a la cocina.
        cameraManager.SwitchCamera(0);

    }

    public void StartCookingSequence()
    {

        if(cameraManager == null)
        {
            Debug.Log("Could not find camera");
        }

        // Cambiar la camara
        // Desactivar el control del jugador
        cameraManager.currentTarget = kitchenFocus;
        cameraManager.SwitchCamera(1); // Kitchen camera. Also disables player movement.

        // Activa los Props
        cookingTrigger.ActivateSequenceProps();


        // wait
        //cookingTrigger.DeactivateSequenceProps();

        // Espera 5 seconds mientras "cocina"
        Invoke("StartFirstCouchSequence", 2);
    }


    void StartFirstCouchSequence()
    {
        cookingTrigger.DeactivateSequenceProps();
        // Fadein

        // Cambiar Camara
        // Con cambiar la camara se desactiva el control del jugador
        cameraManager.SwitchCamera(2); // Kitchen camera. Also disables player movement.
        cameraManager.currentTarget = femaleCharacter; // fijar en personaje femenino

        // Acá va el Dialogo de desayuno




        // FIN


        // Fade-out y sonido de comer

        
        Debug.Log("cameraManager.currentTarget = femaleCharacter;");
        StartLastCoachSequence();
    }

    void StartLastCoachSequence()
    {
        // Fadein

        // Cambiar Camara // Para que sea más dinámico
        // Desactivar el control del jugador
        cameraManager.SwitchCamera(2); // Kitchen camera. Also disables player movement.
        cameraManager.currentTarget = femaleCharacter; // fijar en personaje femenino


        // Dialogo sobre decoración




        // fade-out
        // darle control al jugador (change camera to 0)
        cameraManager.SwitchCamera(0);
        exitSequence = true;
    }


}
