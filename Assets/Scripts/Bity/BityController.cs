using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BityController : MonoBehaviour
{

    [SerializeField] Transform bityFollowPoint;

    private float followSpeed = 1.8f;

    void FixedUpdate() {
        transform.position = Vector2.Lerp(transform.position, bityFollowPoint.position, followSpeed * Time.deltaTime);
    }

}
