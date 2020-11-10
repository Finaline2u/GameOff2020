using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D rig;
    private Animator anim;
    private BoxCollider2D col;

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

        // Animations
        if (anim != null)
        {
            if (movement.x != 0 || movement.y != 0) {
                anim.SetBool("Walking", true);
            } else {
                anim.SetBool("Walking", false);
            }
        }

        if (movement.x < 0)
            transform.eulerAngles = new Vector3(0, -180f, 0);
        else if (movement.x > 0)
            transform.eulerAngles = new Vector3(0, 0, 0);

        /*
        // Diagonal
        if (movement.x < 0 && movement.y > 0)
            transform.eulerAngles = new Vector3(0, 0, 40f);
        else if (movement.x > 0 && movement.y > 0)
            transform.eulerAngles = new Vector3(0, 0, -40f);
        else if (movement.x < 0 && movement.y < 0) 
            transform.eulerAngles = new Vector3(0, 0, 135f);
        else if (movement.x > 0 && movement.y < 0)
            transform.eulerAngles = new Vector3(0, 0, -135f);
        */

        rig.velocity = new Vector2(movement.x, movement.y).normalized * speed;
    }

}
