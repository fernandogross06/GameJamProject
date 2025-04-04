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
        if (Input.GetKeyDown(KeyCode.C))
        {
            index_camera++;
            if (index_camera == cameraArray.Length) index_camera = 0;
            currentCamera = cameraArray[index_camera];
            freeCamera = (index_camera == 0);
            //freeCamera = !freeCamera;

            // if current camera == playerCam: freeCamera
        }
    }
}
