using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class gameManager : MonoBehaviour
{
    public inkTestingScript inkTest;
    public PlayerMovementTutorial movement;
    public GameObject cameraManagerGO;
    CameraManager cameraManager;
    public PlayerCam  cameraMovement;
    float raycastDistance = 5; //Adjust to suit your use case
    public TextMeshProUGUI textPrefab;
    public Transform canvasTransform;
    public Transform textureCanvas;
    TextMeshProUGUI interactText;
   
    public RawImage imagePrefab;
 //   RawImage rawImage;
    [SerializeField] private List<AudioClip> BGM;


    private bool active = true;

    int parteHistoria = 0;

  

    void Start()
    {
       // inkTest = GetComponent<inkTestingScript>();
        inkTest.enabled = false;
        interactText = Instantiate(textPrefab) as TextMeshProUGUI;
       // rawImage = Instantiate(imagePrefab) as RawImage;
        cameraManager = cameraManagerGO.GetComponent<CameraManager>();
        SFXScript.instance.loopClip(BGM[0], transform, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {



        if (Input.GetKeyDown(KeyCode.V))
        {
         

            SFXScript.instance.loopClip(BGM[1], transform, 0.2f);  
        }





    }

    public void returnToGame()
    {
       
        //movement.enabled = true;
        inkTest.enabled = false;
        //cameraMovement.enabled = true;

        //interacting = false;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        cameraManager.SwitchCamera(0);
    }
}
