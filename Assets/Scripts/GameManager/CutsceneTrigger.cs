using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Playables;

public class CutsceneTrigger : MonoBehaviour
{
    public PlayableDirector cutscene;
    public bool playOnTrigger;
    public UnityEvent OnPlay;
    public UnityEvent OnStop;

    private bool playerIsTrigger;
    private bool alreadyPlayed;

    private void Update()
    {
        if (playerIsTrigger)
        {
            if(Input.GetKeyDown(KeyCode.E)){
                PlayCutscene();
            }
        }
    }

    public void PlayCutscene()
    {
        if (alreadyPlayed)
            return;
        OnPlay?.Invoke();
        alreadyPlayed = true;
        cutscene.Play();
        Invoke("FinishCutscene", (float)cutscene.duration);
    }

    void FinishCutscene()
    {
        OnStop?.Invoke();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerIsTrigger = true;
            if (playOnTrigger)
            {
                PlayCutscene();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerIsTrigger = false;
        }
    }
}
