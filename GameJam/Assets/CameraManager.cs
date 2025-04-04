using UnityEngine;
using UnityEngine.UI;

public class CameraManager : MonoBehaviour
{
    public bool freeCamera;
    public GameObject currentTarget;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            freeCamera = !freeCamera;
        }
    }
}
