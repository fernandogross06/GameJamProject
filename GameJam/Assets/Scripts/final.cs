using UnityEngine;
using UnityEngine.SceneManagement;

public class final : MonoBehaviour
{
    private void Start()
    {
        Invoke("WaitToEnd", 10);
    }

    public void WaitToEnd()
    {
        SceneManager.LoadScene("escenaCreditos");
    }
}
