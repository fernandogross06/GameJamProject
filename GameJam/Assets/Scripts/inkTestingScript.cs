using Ink.Runtime;
using NUnit.Framework.Interfaces;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class inkTestingScript : MonoBehaviour
{

    public TextAsset inkJson;
    private Story story;
    public TextMeshProUGUI textPrefab;
    public RectTransform panelPrefab;
    public RectTransform cajaBotonesPrefab;
    public RectTransform nameTagPrefab;
   
    public Button buttonPrefab;
    public Transform canvasTransform;
    public Image imagePrefab;
    public List<Sprite> sprites;
    public gameManager gameManager;

    //public PlayerMovementTutorial movement { get; private set; }
    

    void Start()
    {
        story = new Story(inkJson.text);
        
        refreshUI();
        
        
        


    }

    public void Reset(string parte = "PrimeraParte")
    {
        story = new Story(inkJson.text);
        story.ChoosePathString(parte);
        refreshUI();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            LoadNextStoryChunk();  // Cargar la siguiente línea cuando se presiona la tecla N
        }
    }


    void LoadNextStoryChunk()
    {
        // Solo cargar un nuevo fragmento si la historia puede continuar
        if (story.canContinue)
        {
            string text = story.Continue();  // Continuar la historia
            refreshUI(text);  // Actualizar la UI con el nuevo texto
        }

    }

    public void refreshUI(string text = "")
    {
        eraseUI();
        
        RectTransform panel = Instantiate(panelPrefab);
        RectTransform cajaBotones = Instantiate(cajaBotonesPrefab);
        RectTransform nameTag = Instantiate(nameTagPrefab);
        Image nameTagImage = nameTag.GetComponent<Image>();
        TextMeshProUGUI textComponent = nameTag.GetComponentInChildren<TextMeshProUGUI>();


        panel.SetParent(canvasTransform, false);
        cajaBotones.SetParent(canvasTransform, false);
        nameTag.SetParent(canvasTransform, false);
    

        TextMeshProUGUI storyText = Instantiate(textPrefab) as TextMeshProUGUI;
        

        if (string.IsNullOrEmpty(text))
        {
            text = loadStoryChunk();
            text = text.Replace("/", "\n"); // Si quieres separar ciertas palabras o secciones
        }

        



        List<string> tags = story.currentTags;

        if(tags.Count > 0)
        {
            Image talkingHead = Instantiate(imagePrefab) as Image;
            talkingHead.transform.SetParent(canvasTransform, false);

            if (tags[0] == "A")
            {
                talkingHead.sprite = sprites[0];
                nameTagImage.color = new Color(203, 163, 0);
                textComponent.text = tags[0];
            }


            if (tags[0] == "final")
            {
                gameManager.returnToGame();
            }



        }
        else
        {
            nameTagImage.color = new Color(0, 0, 0);
            textComponent.text = "Tú";
        }

        

        storyText.text = text;
        storyText.transform.SetParent(panel, false);



        foreach (Choice choice in story.currentChoices)
        {
            Button choiceButton = Instantiate(buttonPrefab) as Button;
            choiceButton.transform.SetParent(cajaBotones, false);
            TextMeshProUGUI choiceText = choiceButton.GetComponentInChildren<TextMeshProUGUI>();
            choiceText.text = choice.text;
            

            choiceButton.onClick.AddListener(delegate
            {
                choseStoryChoice(choice);

            });
        }

    }

    void eraseUI()
    {
        for(int i = 0; i<this.transform.childCount; i++)
        {
            Destroy(this.transform.GetChild(i).gameObject);
        }
    }

    void choseStoryChoice(Choice choice)
    {
        story.ChooseChoiceIndex(choice.index);
        refreshUI();
    }



    string loadStoryChunk()
    {
        string text = "";
        if (story.canContinue)
        {
            text = story.Continue();
        }
        return text;
    }



    private void OnDisable()
    {
        eraseUI();
    }
}
