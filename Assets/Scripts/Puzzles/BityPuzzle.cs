using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BityPuzzle : MonoBehaviour {

    public BrokenBity brokenBityScript;

    private bool canRotate = true;

    public GameObject puzzleParent;
    private GameObject[] puzzleBlocks = new GameObject[9];

    private float[] correctValues = {
        0,
        270,
        0,
        0,
        0,
        180,
        180,
        180,
        180
    };

    void Start() {
        for (int i = 0; i < puzzleParent.transform.childCount; i++) {
            puzzleBlocks[i] = puzzleParent.transform.GetChild(i).gameObject;
        }
    }

    public void RotateBlock() {
        GameObject block = EventSystem.current.currentSelectedGameObject.gameObject;
        
        if (canRotate) {
            block.transform.eulerAngles += new Vector3(0, 0, -90);
            Check();
        }
    }

    void Check() {
        float[] rotations = new float[9];

        for (int i = 0; i < puzzleBlocks.Length; i++) 
        {
            if (i == 3 && puzzleBlocks[i].transform.eulerAngles.z == 180)
                rotations[i] = 0;
            else if (Mathf.Abs(puzzleBlocks[i].transform.eulerAngles.z) == 180)
                rotations[i] = 180f;
            else
                rotations[i] = puzzleBlocks[i].transform.eulerAngles.z;
        }

        if (rotations.SequenceEqual(correctValues)) {
            FixBity();
        }

        // string texto = "";
        // foreach (float value in rotations) {
        //     texto += value.ToString() + ", ";
        // }
        // Debug.Log(texto);
    }

    void FixBity() {
        canRotate = false;
        StartCoroutine(brokenBityScript.DeactivatePuzzleScreen(true));
    }

    void DeactivatePuzzleScreen() {
        
    }

}
