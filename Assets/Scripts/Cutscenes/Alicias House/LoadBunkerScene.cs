using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadBunkerScene : MonoBehaviour {

    public void LoadBunker() {
        StartCoroutine(LevelLoader.instance.LoadLevel(3));
    }

}
