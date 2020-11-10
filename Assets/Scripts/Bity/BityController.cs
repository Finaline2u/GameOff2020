using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BityController : MonoBehaviour
{

    private Transform bityFollowPoint;
    private Vector3 playerMovement;

    private float followSpeed = 2.2f;

    void Start() {
        // [!] Substituir pelo prefab depois
        bityFollowPoint = GameObject.Find("Terry PlaceHolder").transform.Find("Bity Follow Point");
    }

    void FixedUpdate() {
        transform.position = Vector2.Lerp(transform.position, bityFollowPoint.position, followSpeed * Time.deltaTime);
    }

}
