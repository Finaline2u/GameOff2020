using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovementVelocity : MonoBehaviour
{
    [SerializeField] private int moveSpeed = 5;

    private Vector3 velocityVector;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void SetVelocity(Vector3 velocityVector)
    {
        this.velocityVector = velocityVector;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = velocityVector * moveSpeed;
    }
}
