using UnityEngine;
using UnityEngine.UI;

public class CameraManager : MonoBehaviour
{
    public bool freeCamera;
    public GameObject currentTarget;
    public GameObject currentCamera;
    public GameObject[] cameraArray;
    int index_camera;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        index_camera =  0;
        currentCamera = cameraArray[index_camera];
    }

    // Update is called once per frame
    void Update()
    {

        
    }
    public int SwitchCamera(int new_index)
    {
        if(new_index >=0 && new_index < cameraArray.Length) { 
            index_camera = new_index;
            currentCamera = cameraArray[index_camera];

            // SI LA CAMARA ESTA EN 0, EL JUGADOR SE PUEDE MOVER
            freeCamera = (index_camera == 0); 
        }
        return index_camera;
    }

    public int NextCamera()
    {

        if (Input.GetKeyDown(KeyCode.C))
        {

    
        index_camera++;
        if (index_camera == cameraArray.Length) index_camera = 0;

        //freeCamera = !freeCamera;
        }
        // if current camera == playerCam: freeCamera
        return index_camera;

    }
}
