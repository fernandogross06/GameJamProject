using TMPro;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CookingTrigger : MonoBehaviour
{
    public TextMeshProUGUI _textMeshPro;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _textMeshPro.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Debug.Log("Toqué al player");
            _textMeshPro.gameObject.SetActive(true);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Debug.Log("Salió al player");
            _textMeshPro.gameObject.SetActive( false);
        }
    }
}
