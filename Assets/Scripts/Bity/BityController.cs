using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BityController : MonoBehaviour {

    [SerializeField] Transform bityFollowPoint;

    [SerializeField] GameObject circleLight;
    [SerializeField] GameObject shortFlashlight;
    [SerializeField] GameObject longFlashlight;

    private bool shortFlashlightOn = false;
    private bool longFlashlightOn = false;

    private float followSpeed = 1.8f;

    void Update() {
        HandleInputs();
    }

    void FixedUpdate() {
        HandleMovement();
    }

    void HandleMovement() {
        transform.position = Vector2.Lerp(transform.position, bityFollowPoint.position, followSpeed * Time.deltaTime);
    }

    void HandleInputs() 
    {
        if (Input.GetKeyDown(KeyCode.F)) 
        {
            if (!shortFlashlightOn && !longFlashlightOn) 
            {
                circleLight.SetActive(true);
                shortFlashlight.SetActive(true);
                shortFlashlightOn = true;
            }
            else if (shortFlashlightOn) {
                shortFlashlight.SetActive(false);
                shortFlashlightOn = false;

                longFlashlight.SetActive(true);
                longFlashlightOn = true;
            }
            else 
            {
                circleLight.SetActive(false);
                longFlashlight.SetActive(false);
                longFlashlightOn = false;
            }
        }
    }

}
