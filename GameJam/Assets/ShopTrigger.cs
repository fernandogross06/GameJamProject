using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using static UnityEngine.GraphicsBuffer;

public class ShopTrigger : MonoBehaviour
{
    public GameObject citySequenceManagerObject;
    CitySequenceManager citySequenceManager;

    public TextMeshProUGUI _textMeshPro;
    private bool playerInRange;
    public GameObject[] sceneProps;

    int dialogos = 0;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        //_textMeshPro.gameObject.SetActive(false);
        citySequenceManager = citySequenceManagerObject.GetComponent<CitySequenceManager>();

        //DeactivateSequenceProps();
    }

    // Update is called once per frame
    void Update()
    {

        // CUANDO PRESIONE LA E, ESTÉ ACTIVO EL EVENTO DE COCINAR Y EL JUGADOR ESTÉ EN RANGO
        // SE ACTIVA LA ESCENA

        //&& sceneSequenceManager.cookingSequence
        if (Input.GetKeyDown(KeyCode.E) && playerInRange )
        {
            //sceneSequenceManager.cookingSequence = false;
           
            if(dialogos == 0)
            {
                citySequenceManager.ShoppingSequence(0);
            }
            if (dialogos == 1)
            {
                citySequenceManager.ShoppingSequence(1);
            }
            if (dialogos == 2)
            {
                citySequenceManager.ShoppingSequence(2);
            }
            if (dialogos == 3)
            {
                citySequenceManager.ShoppingSequence(3);
            }
            dialogos++;
            //ActivateSequenceProps();
        }
        //if (Input.GetKeyDown(KeyCode.X) && !playerInRange)
        //{
        //    DeactivateSequenceProps();
        //}
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
    //public void ActivateSequenceProps()
    //{
    //    for (int i = 0; i < sceneProps.Length; i++) {
    //       sceneProps[i].gameObject.SetActive(true);
    //    }

    //}
    // Desactiva los objetos relacionados a la escena
    //public void DeactivateSequenceProps()
    //{
    //    for (int i = 0; i < sceneProps.Length; i++)
    //    {
    //        sceneProps[i].gameObject.SetActive(false);
    //    }

    //}

}
