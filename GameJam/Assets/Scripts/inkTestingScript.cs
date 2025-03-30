using Ink.Runtime;
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
    public Button buttonPrefab;
    public Transform canvasTransform;

    //public PlayerMovementTutorial movement { get; private set; }
    

    void Start()
    {
        story = new Story(inkJson.text);

        refreshUI();
        
        
        


    }

    public void Reset()
    {
        story = new Story(inkJson.text);

        refreshUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   

    public void refreshUI()
    {
        eraseUI();
        RectTransform panel = Instantiate(panelPrefab);
        panel.SetParent(canvasTransform, false);
        TextMeshProUGUI storyText = Instantiate(textPrefab) as TextMeshProUGUI;

        string text = loadStoryChunk();

        List<string> tags = story.currentTags;

        if(tags.Count > 0)
        {
            text = "<b>" + tags[0] + "</b> - " + text;
        }

        

        storyText.text = text;
        storyText.transform.SetParent(panel, false);



        foreach (Choice choice in story.currentChoices)
        {
            Button choiceButton = Instantiate(buttonPrefab) as Button;
            choiceButton.transform.SetParent(panel, false);
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
           text = story.ContinueMaximally();
        }

        return text;
        
    }
    
   
    
    private void OnDisable()
    {
        eraseUI();
    }
}
