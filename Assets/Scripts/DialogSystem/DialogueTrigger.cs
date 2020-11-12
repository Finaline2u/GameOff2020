﻿using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] DialogueManager dialogueManager;
    [SerializeField] GameObject player = default;
    [SerializeField] GameObject inputTip = default;
    [SerializeField] private bool resetConversation = false;
    //[SerializeField] string path = "";
    [SerializeField] List<string> pathList = new List<string>();

    private int currentPath = 0;
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
        Debug.Log(collision.name + " colidiu com " + gameObject.name);
        inputTip.SetActive(true);
        inputTip.GetComponent<InputTip>().inputText.text = "C";
        if (collision.gameObject == player)
            gameObject.GetComponent<DialogueTrigger>().inTrigger = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        inputTip.SetActive(false);
        if (collision.gameObject == player)
            gameObject.GetComponent<DialogueTrigger>().inTrigger = false;
    }

    private void RunDialogue(bool keyTrigger)
    {
        if (keyTrigger && inTrigger)
        {
            Debug.Log("Tecla pressionada.");
            Debug.Log("path = " + pathList[0] + ", inTrigger = " + inTrigger + ", dialogueLoaded = " + dialogueLoaded + ",\ncurrentPath = " + currentPath + ", inDialogue = " + inDialogue + ", dialogManager.SentenceFinished = " + dialogueManager.SentenceFinished);
            
            inputTip.SetActive(false);

            if (!dialogueManager.SentenceFinished)
                dialogueManager.FastPrintLine();
            else
            {
                if (!dialogueLoaded)
                    dialogueLoaded = dialogueManager.LoadDialogue(pathList[currentPath]);

                if (dialogueLoaded)
                    dialogueLoaded = dialogueManager.PrintLine();

                /*Debug.Log("inDialogue = " + inDialogue);

                if (!inDialogue)
                {
                    if (resetConversation)
                        dialogueManager.ResetDialogue();
                    else
                        dialogueManager.ShowLastDialogue();
                    inDialogue = dialogueManager.PrintLine();
                }*/
            }
        }
    }

    public void ChangeConversation()
    {
        if(currentPath < pathList.Count)
            currentPath++;
    }

    // Update is called once per frame
    void Update()
    {
        RunDialogue(Input.GetKeyDown(KeyCode.C));
    }
}
