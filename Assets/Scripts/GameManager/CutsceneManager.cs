using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CutsceneManager : MonoBehaviour
{
    private bool cutsceneStop = false;
    
    public Animator animator = default;
    public RuntimeAnimatorController playerAnimator = default;
    public PlayableDirector director = default;

    // Start is called before the first frame update
    void OnEnable()
    {
        playerAnimator = animator.runtimeAnimatorController;
        animator.runtimeAnimatorController = null;
    }

    // Update is called once per frame
    void Update()
    {
        if(director.state != PlayState.Playing && !cutsceneStop)
        {
            cutsceneStop = true;
            //animator.
        }
    }
}
