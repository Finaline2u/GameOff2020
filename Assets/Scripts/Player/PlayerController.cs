using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Rigidbody2D rig;
    private Animator anim;
    private BoxCollider2D col;

    public bool canMove = true;

    private bool usingGun = false;

    private const string WALKING_UP = "WalkingUP", 
    WALKING_DOWN = "WalkingDOWN", 
    WALKING_LR = "WalkingLR";

    [HideInInspector] public Vector2 movement;
    private float speed = 5f;

    void Start() {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate() {
        HandleMovement();
    }

    void HandleMovement() {
        movement.x = Input.GetAxisRaw("Horizontal"); 
        movement.y = Input.GetAxisRaw("Vertical");

        if (anim != null)
        {
            // UP & DOWN MOVEMENT
            if (movement.y > 0) 
            {
                anim.SetBool(WALKING_UP, true);
                anim.SetBool(WALKING_LR, false);
            }

            if (movement.y < 0) 
            {
                anim.SetBool(WALKING_DOWN, true);
                anim.SetBool(WALKING_LR, false);
            }

            if (movement.y == 0) 
            {
                if (anim.GetBool(WALKING_UP))
                    anim.SetBool(WALKING_UP, false);
                    
                if (anim.GetBool(WALKING_DOWN))
                    anim.SetBool(WALKING_DOWN, false);
            }

            // LEFT & RIGHT MOVEMENT
            if (movement.x > 0 || movement.x < 0) 
            {
                if (!anim.GetBool(WALKING_UP) && !anim.GetBool(WALKING_DOWN))
                    anim.SetBool(WALKING_LR, true);
            }

            if (movement.x == 0)
            {
                if (!anim.GetBool(WALKING_UP) && !anim.GetBool(WALKING_DOWN))
                    anim.SetBool(WALKING_LR, false);
            }
        }

        if (!usingGun) {
            if (movement.x < 0)
                transform.eulerAngles = new Vector3(0, -180f, 0);
            else if (movement.x > 0)
                transform.eulerAngles = new Vector3(0, 0, 0);
        }

        if (canMove)
            rig.velocity = new Vector2(movement.x, movement.y).normalized * speed;
    }

}
