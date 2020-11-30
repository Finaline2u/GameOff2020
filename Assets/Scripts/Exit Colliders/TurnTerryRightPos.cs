using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnTerryRightPos : MonoBehaviour {

    public GameObject terry;

    void Start() {
        terry.transform.eulerAngles = new Vector2(0, 180f);
    }

}
