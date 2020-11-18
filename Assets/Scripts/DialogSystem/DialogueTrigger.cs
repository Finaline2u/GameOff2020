using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] DialogueManager dialogueManager;
    [SerializeField] GameObject player = default;
    [SerializeField] GameObject inputTip = default;
    [SerializeField] Task taskAfterDialogue = default;
    //[SerializeField] string path = "";
    [SerializeField] List<string> conversationList = new List<string>();

    private int currentConvesation = 0;
    private bool inTrigger = false;
    private bool dialogueLoaded = false;
    private bool inDialogue = false;

    // Start is called before the first frame update
    void Start()
    {
        if (dialogueManager == null)
            dialogueManager = GameObject.Find("DialogueManager").GetComponent<DialogueManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*Debug.Log(collision.name + " colidiu com " + gameObject.name);*/
        inputTip.SetActive(true);
        //inputTip.GetComponent<InputTip>().inputText.text = "C";
        if (collision.gameObject == player)
            gameObject.GetComponent<DialogueTrigger>().inTrigger = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        inputTip.SetActive(false);
        if (collision.gameObject == player)
            gameObject.GetComponent<DialogueTrigger>().inTrigger = false;
    }

    public void RunDialogue(bool keyTrigger)
    {
        if (keyTrigger && inTrigger)
        {
            /*Debug.Log("Tecla pressionada.");*/
            Debug.Log("path = " + conversationList[0] + ", inTrigger = " + inTrigger + ", dialogueLoaded = " + dialogueLoaded + "," +
                "\ncurrentPath = " + currentConvesation + ", inDialogue = " + inDialogue + ", dialogManager.SentenceFinished = " + dialogueManager.SentenceFinished);
            
            inputTip.SetActive(false);

            if (!dialogueManager.SentenceFinished)
                dialogueManager.FastPrintLine();
            else
            {
                if (!dialogueLoaded)
                    dialogueLoaded = dialogueManager.LoadDialogue(conversationList[currentConvesation]) ;

                Debug.Log("dialogueLoaded = " + dialogueLoaded);

                if (dialogueLoaded)
                    dialogueLoaded = dialogueManager.PrintLine();
                if (!dialogueLoaded && taskAfterDialogue != null)
                {
                    Debug.Log("Começando a task");
                    taskAfterDialogue.DoTask(player, null);
                }
                    

            }
        }
    }

    public void ChangeConversation()
    {
        if(currentConvesation < conversationList.Count)
            currentConvesation++;
    }

    // Update is called once per frame
    void Update()
    {
        RunDialogue(Input.GetKeyDown(KeyCode.E));
    }
}
