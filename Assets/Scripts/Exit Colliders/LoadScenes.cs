using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScenes : MonoBehaviour {

    public int sceneIndexToLoad;

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.CompareTag("Player")) {

            // Bunker
            if (SceneManager.GetActiveScene().buildIndex == 4) {
                TPCorrectPlace.noMoreCutscene = true;
            }
            
            LevelLoader.instance.LoadLevel(sceneIndexToLoad);
        }
    }

}
