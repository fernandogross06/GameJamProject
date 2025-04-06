using TMPro;
using UnityEngine;

public class ExitTrigger : MonoBehaviour
{

    public TextMeshProUGUI doorText;
    private bool playerInRange;
    public SceneController sceneController;
    [SerializeField] string sceneName;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //text.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerInRange)
        {
           
            sceneController.loadScene(sceneName);
            //ActivateSequenceProps();
        }
        
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //Debug.Log("Toqué al player");
            doorText.gameObject.SetActive(true);
            doorText.text = "Presione E para salir";
            playerInRange = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //Debug.Log("Salió al player");
            doorText.gameObject.SetActive(false);
            playerInRange = false;
        }
    }
}
