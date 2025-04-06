using System.Collections.Generic;
using System;
using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.UI;

public class CitySequenceManager : MonoBehaviour
{
    
    // Access to camera control
    public GameObject cameraManagerGO;
    CameraManager cameraManager;

    public GameObject femaleCharacter;
    public GameObject kitchenFocus;


    public GameObject shoppingTriggerGO;
    ShopTrigger shopTrigger;
    // Scenes Event Triggers


    public bool shopReady;

    public bool exitSequence;

    //Acceso al scripts de dialogo y movimiento
    public inkTestingScript inkTest;
    public PlayerCam cameraMovement;

    public PlayerMovementTutorial movement;

    bool cargado1 = false;

    //Fade pantalla negra
    public Image pantallaNegra;
    public float tiempo;
    public int duracionPantalla;


    void Awake()
    {
        cameraManager = cameraManagerGO.GetComponent<CameraManager>();
        shopTrigger = shoppingTriggerGO.GetComponent<ShopTrigger>();
        cameraManager.SwitchCamera(0);

        shopReady = false; // CAMBIAR LUEGO
        exitSequence = false;
    }

    // Update is called once per frame
    void Update()
    {
        /*if (!cargado1)//Por alguna razon el primer dialogo no carga sino se llama por lo menos una vez mas asi que hice una condicional
        {
            //inkTest.enabled = true;
            //inkTest.Reset("PrimeraParte");
            StartIntroductionSequence();
            cargado1 = true;
        }
        */
    }

    private void Start()
    {

        

    }
    public void StartShoppingSequence()
    {
        // cameraManager.setCamera(1)

        // Camera aiming at Female Character. Also disables player movement.
        cameraManager.SwitchCamera(1);
        cameraManager.currentTarget = femaleCharacter;

        // Start SceneDialog #1

        // ACÁ SE AGREGA EL DIALOGO

       

        //Modificar a preferencia
        //movement.enabled = false;  //desactiva el movimiento
        //cameraMovement.enabled = false; // desactiva el movimiento de la camara
        Cursor.lockState = CursorLockMode.None; //activa el cursor
        Cursor.visible = true; //hace visible al cursor


        inkTest.enabled = true; // activa el script de dialogo
        inkTest.Reset("PrimeraParte"); //llama al dialogo correspondiente


        // Cuando termine, permitir cocinar

        shopReady = true;

        // Camara en 0 para darle libertad al jugador y que vaya a la cocina.

    }

   
    void FadeInLastCoachSequencee()
    {
        StartCoroutine(fadeScreen());
        float tiempoEspera = duracionPantalla + tiempo;
        Invoke("StartLastCoachSequence", tiempoEspera);
    }

    // Usar plantilla para cambios de escenas 
    IEnumerator esperarFirstCouchSequence()
    {
        while (inkTest.enabled == true)
        {
            yield return null;
        }
        Debug.Log("cameraManager.currentTarget = femaleCharacter;");
        FadeInLastCoachSequencee();
    }

    void StartLastCoachSequence()
    {
        // Fadein

        // Cambiar Camara // Para que sea más dinámico
        // Desactivar el control del jugador
        cameraManager.SwitchCamera(2); // Kitchen camera. Also disables player movement.
        cameraManager.currentTarget = femaleCharacter; // fijar en personaje femenino


        // Dialogo sobre decoración


        print("sirve StartLastCoachSequence");

        //Modificar a preferencia
        Cursor.lockState = CursorLockMode.None; //activa el cursor
        Cursor.visible = true; //hace visible al cursor


        inkTest.enabled = true; // activa el script de dialogo
        inkTest.Reset("TerceraParte"); //llama al dialogo correspondiente

        // fade-out
        // darle control al jugador (change camera to 0)
        exitSequence = true;
    }


    public IEnumerator fadeScreen()
    {
        // Pasar tiempo por parámetro
        //float elapsedTime = 0f;

        Color StartColor = new Color(pantallaNegra.color.r, pantallaNegra.color.g, pantallaNegra.color.b, 0);
        Color TargetColor = new Color(pantallaNegra.color.r, pantallaNegra.color.g, pantallaNegra.color.b, 1);

        pantallaNegra.gameObject.SetActive(true);

        float elapsedTime = 0;

        float elapsedPercentage = 0;
        while (elapsedPercentage < 1)
        {
            elapsedPercentage = elapsedTime / tiempo;


            pantallaNegra.color = Color.Lerp(StartColor, TargetColor, elapsedPercentage);



            yield return null;
            elapsedTime += Time.deltaTime;
        }

        StartColor = new Color(pantallaNegra.color.r, pantallaNegra.color.g, pantallaNegra.color.b, 1);
        TargetColor = new Color(pantallaNegra.color.r, pantallaNegra.color.g, pantallaNegra.color.b, 0);

        elapsedTime = 0;
        while (elapsedTime < duracionPantalla)
        {

            //print(elapsedTime);

            elapsedTime += Time.deltaTime;


            yield return null;  // Esperar hasta el siguiente frame
        }

        elapsedTime = 0;
        elapsedPercentage = 0;
        while (elapsedPercentage < 1)
        {
            elapsedPercentage = elapsedTime / tiempo;


            pantallaNegra.color = Color.Lerp(StartColor, TargetColor, elapsedPercentage);



            yield return null;
            elapsedTime += Time.deltaTime;
        }

        pantallaNegra.gameObject.SetActive(false);



    }

  


}
