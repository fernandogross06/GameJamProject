using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using static UnityEngine.GraphicsBuffer;

public class CookingTrigger : MonoBehaviour
{
    public GameObject sequenceManagerObject;
    SceneSequenceManager sceneSequenceManager;

    public TextMeshProUGUI _textMeshPro;
    private bool playerInRange;
    public GameObject[] sceneProps;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        _textMeshPro.gameObject.SetActive(false);
        sceneSequenceManager = sequenceManagerObject.GetComponent<SceneSequenceManager>();

        DeactivateSequenceProps();
    }

    // Update is called once per frame
    void Update()
    {
        //if(EventoActive y playerInRange){

        //}
        if (Input.GetKeyDown(KeyCode.Z) && playerInRange)
        {
            sceneSequenceManager.StartCookingSequence();
            //ActivateSequenceProps();
        }
        if (Input.GetKeyDown(KeyCode.X) && !playerInRange)
        {
            DeactivateSequenceProps();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //Debug.Log("Toqué al player");
            _textMeshPro.gameObject.SetActive(true);
            playerInRange = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //Debug.Log("Salió al player");
            _textMeshPro.gameObject.SetActive( false);
            playerInRange = false;
        }
    }

    // Activar los objetos relacionados a la escena
    public void ActivateSequenceProps()
    {
        for (int i = 0; i < sceneProps.Length; i++) {
            sceneProps[i].gameObject.SetActive(true);
        }

    }
    // Desactiva los objetos relacionados a la escena
    public void DeactivateSequenceProps()
    {
        for (int i = 0; i < sceneProps.Length; i++)
        {
            sceneProps[i].gameObject.SetActive(false);
        }

    }

}
