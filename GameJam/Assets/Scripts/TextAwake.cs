using System.Collections;
using TMPro;
using UnityEngine;

public class TextAwake : MonoBehaviour
{
    public TextMeshProUGUI text;
    public float tiempo;
    public int duracionTexto;
    private void Awake()
    {

        StartCoroutine(waitText());
       

        

    }
    

    public IEnumerator waitText()
    {

        //float elapsedTime = 0f;

        Color textStartColor = new Color(text.color.r, text.color.g, text.color.b, 1);
        Color textTargetColor = new Color(text.color.r, text.color.g, text.color.b, 0);

        float elapsedTime = 0;
        while (elapsedTime < duracionTexto)
        {
          
            //print(elapsedTime);

            elapsedTime += Time.deltaTime;


            yield return null;  // Esperar hasta el siguiente frame
        }

        elapsedTime = 0;
        float elapsedPercentage = 0;
        while (elapsedPercentage < 1)
        {
            elapsedPercentage = elapsedTime / tiempo;


            text.color = Color.Lerp(textStartColor, textTargetColor, elapsedPercentage);



            yield return null;
            elapsedTime += Time.deltaTime;
        }

        text.gameObject.SetActive(false);



    }
}
