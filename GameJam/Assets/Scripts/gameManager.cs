using UnityEngine;

public class gameManager : MonoBehaviour
{
    public inkTestingScript inkTest;
    public PlayerMovementTutorial movement;
    public PlayerCam  cameraMovement;
    void Start()
    {
       // inkTest = GetComponent<inkTestingScript>();
        inkTest.enabled = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            print("enabled");
           
            movement.enabled = false;
            inkTest.enabled = true;
            inkTest.Reset();
            cameraMovement.enabled = false;

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

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
