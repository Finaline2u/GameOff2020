using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectWithLock : MonoBehaviour {

    private PlayerController player;

    public GameObject pressButton;
    public GameObject codeLock;
    private Animator codeLockAnim;
    private BoxCollider2D useArea;
    
    private bool isNear = false;
    private bool notOpened = true;
    private bool calledThisFrame = false;

    void Start() {
        player = FindObjectOfType<PlayerController>();
        codeLockAnim = codeLock.GetComponent<Animator>();
        useArea = GetComponent<BoxCollider2D>();
    }

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
            StartCoroutine(ActivateLockScreen());
        
        else if (isNear && Input.GetKeyDown(KeyCode.E) && !notOpened && !calledThisFrame)
            StartCoroutine(DeactivateLockScreen(false));
    }

    public IEnumerator ActivateLockScreen() {
        calledThisFrame = true;
        player.canMove = false;

        pressButton.SetActive(false);
        codeLock.SetActive(true);

        yield return new WaitForSeconds(1f);
        calledThisFrame = false;
        notOpened = false;
    }

    public IEnumerator DeactivateLockScreen(bool isFinished) {
        calledThisFrame = true;
        player.canMove = true;

        codeLockAnim.SetTrigger("Close");

        yield return new WaitForSeconds(0.5f);

        if (!isFinished)
            pressButton.SetActive(true);
        else
            pressButton.SetActive(false);

        calledThisFrame = false;
        notOpened = true;

        if (isFinished)
            useArea.enabled = false;

        yield return new WaitForSeconds(0.5f);

        codeLock.SetActive(false);
    }

}
