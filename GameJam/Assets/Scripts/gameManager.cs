using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{
    public inkTestingScript inkTest;
    public PlayerMovementTutorial movement;
    public PlayerCam  cameraMovement;
    float raycastDistance = 5; //Adjust to suit your use case
    public TextMeshProUGUI textPrefab;
    public Transform canvasTransform;
    public Transform textureCanvas;
    TextMeshProUGUI interactText;
    bool interacting = false;
    public RawImage imagePrefab;
    RawImage rawImage;

    private bool active = true;

    public SceneController sceneController;

    void Start()
    {
       // inkTest = GetComponent<inkTestingScript>();
        inkTest.enabled = false;
        interactText = Instantiate(textPrefab) as TextMeshProUGUI;
        rawImage = Instantiate(imagePrefab) as RawImage;
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); 

        RaycastHit hit;
        rawImage.transform.SetParent(textureCanvas, false);

        if (Input.GetKeyDown(KeyCode.M))
        {
            if (active)
            {
                rawImage.gameObject.SetActive(false);
                active = false;
            }
            else
            {
                rawImage.gameObject.SetActive(true);
                active = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            sceneController.loadScene("escenaPrueba");
        }

        //rawImage.transform.SetAsFirstSibling();

        if (Physics.Raycast(ray, out hit, raycastDistance)) //Actively creates a ray using the above set perameters at the predeterminded distance
        {
           
            interactText.transform.SetParent(canvasTransform, false);
            //Item Raycast Detection
            if (interacting == false)
            {
                
                if (hit.collider.CompareTag("interact"))//Checking if the Raycast has hit a collider with the tag of note
                {
                    print("sirve");
                    print(interacting);

                    interactText.text = "Presiona [I] para interactuar."; //Setting the Interaction Text to let the player know they are now hovering an interactable object
                    print(interactText.text);
                    if (Input.GetKeyDown(KeyCode.I))//Check if the player has pressed the Interaction button
                    {
                        interacting = true;
                        Debug.Log("[I] Was Pressed while looking at a note, lets open the note.");
                        interactText.text = "";

                        //Add your Note Method/UI here - for example (if the note has a script attached to it)
                        movement.enabled = false;
                        inkTest.enabled = true;
                        inkTest.Reset();
                        cameraMovement.enabled = false;

                        Cursor.lockState = CursorLockMode.None;
                        Cursor.visible = true;

                    }
                }

                else //If nothing at all with an above tag was hit with the Raycast within the specified distance then run this
                {
                    if (interactText.text != "")//If the interactText is not already set as nothing then set it to nothing - this is to help optimise and save from constantly spamming this request
                    {
                        interactText.text = ""; //Removing the text as nothing was detected by the raycast
                    }
                    interacting = false;
                }
            }

            print(interacting);
            //interactText.text = "";



        }


        if (Input.GetKeyDown(KeyCode.T))
        {
            returnToGame();
        }
    }

    public void returnToGame()
    {
        movement.enabled = true;
        inkTest.enabled = false;
        cameraMovement.enabled = true;

        interacting = false;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
