using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*public void EscenaJuego()
    {
        SceneManager.LoadScene("escenaApartamentoDecorada"); //Cambiar eso por la primera escena del juego
    }*/

    public void Salir()
    {
        Application.Quit();
    }
}
