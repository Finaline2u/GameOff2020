using LitJson;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    private const string DIALOGUE_FOLDER = "Dialogues/";

    [SerializeField] private TextMeshProUGUI textDisplay = default;
    [SerializeField] private TextMeshProUGUI charNameDisplay = default; 
    private JsonData dialogue;
    private int index;

    private void LoadDialogue(string path)
    {
        index = 0;
        var jsonTextFile = Resources.Load<TextAsset>(DIALOGUE_FOLDER + path);
        dialogue = JsonMapper.ToObject(jsonTextFile.text);
    }

    private void printLine()
    {
        string speaker = "";
        JsonData line = dialogue[index];
        foreach(JsonData key in line.Keys)
        {
            speaker = key.ToString();
        }
        charNameDisplay.text = speaker;
        textDisplay.text = line[0].ToString();
        index++;
    }

    // Start is called before the first frame update
    void Start()
    {
        LoadDialogue("Conversation1");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
            printLine();
    }
}
