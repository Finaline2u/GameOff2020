using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterOrExitPlace : MonoBehaviour {

    public int sceneBuildIndex;
    private LevelLoader levelLoader;

    void Start() {
        levelLoader = FindObjectOfType<LevelLoader>(); 
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") 
            StartCoroutine(levelLoader.LoadLevel(sceneBuildIndex));
    }

}
