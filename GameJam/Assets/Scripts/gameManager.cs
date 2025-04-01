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
    TextMeshProUGUI interactText;
    bool interacting;

    void Start()
    {
       // inkTest = GetComponent<inkTestingScript>();
        inkTest.enabled = false;
        interactText = Instantiate(textPrefab) as TextMeshProUGUI;
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); 

        RaycastHit hit;
        

        if (Physics.Raycast(ray, out hit, raycastDistance)) //Actively creates a ray using the above set perameters at the predeterminded distance
        {
            interactText.text = "hola";
            interactText.transform.SetParent(canvasTransform, false);
            //Item Raycast Detection
            if (hit.collider.CompareTag("interact"))//Checking if the Raycast has hit a collider with the tag of note
            {
                interactText.text = "Presiona [I] para interactuar."; //Setting the Interaction Text to let the player know they are now hovering an interactable object
                if (interacting)
                {
                    interactText.text = "";
                }
                    
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
            /*else if (hit.collider.CompareTag(""))
            {
                //Add a different object here if you choose to want more objects to be able to be detected by the Raycast such as doors etc
            }*/

            else //If nothing at all with an above tag was hit with the Raycast within the specified distance then run this
            {
                if (interactText.text != "")//If the interactText is not already set as nothing then set it to nothing - this is to help optimise and save from constantly spamming this request
                {
                    interactText.text = ""; //Removing the text as nothing was detected by the raycast
                }
                interacting = false;
            }
        }


        if (Input.GetKeyDown(KeyCode.T))
        {
            movement.enabled = true;
            inkTest.enabled = false;
            cameraMovement.enabled = true;

            

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
