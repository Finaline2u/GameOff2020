using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenBity : MonoBehaviour {

    public PlayerController player;

    public GameObject pressButton;
    public GameObject puzzleScreen;
    
    public BoxCollider2D fixArea;

    private Animator anim;

    void Start() {
        anim = puzzleScreen.GetComponent<Animator>();
    }

    private bool isNear = false;
    private bool notOpened = true;
    private bool calledThisFrame = false;

    void Update() {
        HandleActivation();
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
           pressButton.SetActive(true);
           isNear = true;
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
           pressButton.SetActive(false);
           isNear = false;
        }
    }

    void HandleActivation() {
        if (isNear && Input.GetKeyDown(KeyCode.E) && notOpened && !calledThisFrame)
            StartCoroutine(ActivatePuzzleScreen());
        
        else if (isNear && Input.GetKeyDown(KeyCode.E) && !notOpened && !calledThisFrame)
            StartCoroutine(DeactivatePuzzleScreen(false));
    }

    public IEnumerator ActivatePuzzleScreen() {
        calledThisFrame = true;
        player.canMove = false;

        pressButton.SetActive(false);
        puzzleScreen.SetActive(true);

        yield return new WaitForSeconds(1f);
        calledThisFrame = false;
        notOpened = false;
    }

    public IEnumerator DeactivatePuzzleScreen(bool isFinished) {
        calledThisFrame = true;
        player.canMove = true;

        anim.SetTrigger("Close");

        yield return new WaitForSeconds(0.5f);

        if (!isFinished)
            pressButton.SetActive(true);
        else
            pressButton.SetActive(false);

        calledThisFrame = false;
        notOpened = true;

        if (isFinished)
            fixArea.enabled = false;

        yield return new WaitForSeconds(0.5f);

        puzzleScreen.SetActive(false);
    }

}
