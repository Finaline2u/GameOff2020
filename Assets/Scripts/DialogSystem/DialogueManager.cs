using LitJson;
using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    private const string DIALOGUE_FOLDER = "Dialogues/";

    private event EventHandler OnDialogueFinished;

    [SerializeField] private TextMeshProUGUI textDisplay = default;
    [SerializeField] private TextMeshProUGUI charNameDisplay = default; 
    [SerializeField] private GameObject dialogueContainer = default;
    [Range(0f, .2f)] [SerializeField] private float textDelay = .1f;
    private JsonData dialogue;
    private int index;

    private bool inDialogue = false;
    private bool sentenceFinished = true;

    public bool SentenceFinished { get => sentenceFinished; }

    public bool LoadDialogue(string path)
    {
        Debug.Log("LoadDialogue():\ninDialogue = " + inDialogue);
        if (!inDialogue)
        {
            Debug.Log("Diálogo ativo.");
            index = 0;
            var jsonTextFile = Resources.Load<TextAsset>(DIALOGUE_FOLDER + path);
            dialogue = JsonMapper.ToObject(jsonTextFile.text);
            inDialogue = true;
            dialogueContainer.SetActive(true);
            
            return true;
        }
        return false;
    }

    public bool PrintLine()
    {
        if (inDialogue)
        {
            string speaker = "";
            JsonData line = dialogue[index];
            string dialogueText = line[0].ToString();
            Debug.Log("dialogueText = " + dialogueText);

            if (dialogueText == "EOD")
            {
                inDialogue = false;
                textDisplay.text = "";
                charNameDisplay.text = "";
                dialogueContainer.SetActive(false);
                //sentenceFinished = true;
                //index = dialogue.Count - 2; //Return to last dialogue
                return false;
            }

            foreach(JsonData key in line.Keys)
            {
                speaker = key.ToString();
            }
            /*if(!dialogueContainer.activeSelf)
                dialogueContainer.SetActive(true);*/
            charNameDisplay.text = speaker;
            textDisplay.text = "";
            sentenceFinished = false;
            StartCoroutine(PrintLine(dialogueText));
        }

        return true;
    }

    public void FastPrintLine()
    {
        if (!SentenceFinished) {
            JsonData line = dialogue[index];
            string dialogueText = line[0].ToString();
            textDisplay.text = dialogueText;
            index++;
            sentenceFinished = true;
            StopAllCoroutines();
        }
        
    }

    private IEnumerator PrintLine(string text)
    {
        for(int i = 0; i < text.Length; i++)
        {
            textDisplay.text += text[i];
            yield return new WaitForSeconds(textDelay);
        }
        sentenceFinished = true;
        index++;
    }

    public void ResetDialogue()
    {
        index = 0;
    }

    public void ShowLastDialogue()
    {
        index = dialogue.Count - 2;
        //inDialogue = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        //LoadDialogue("Conversation1");
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.C))
            PrintLine();*/
    }
}
