using LitJson;
using System;
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
    private JsonData dialogue;
    private int index;

    private bool inDialogue = false;

    public bool LoadDialogue(string path)
    {
        Debug.Log("LoadDialogue()");
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
                /*OnDialogueFinished?.Invoke(this, )
                Invoke();*/
                return false;
            }

            foreach(JsonData key in line.Keys)
            {
                speaker = key.ToString();
            }
            charNameDisplay.text = speaker;
            textDisplay.text = dialogueText;
            index++;
        }

        return true;
    }

    public void ResetDialogue()
    {
        index = 0;
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
