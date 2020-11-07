using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovementByGoal : MonoBehaviour, IUnit
{
    private enum State
    {
        Idle,
        Moving,
        Animating,
    }

    private State state = State.Idle;
    public bool IsIdle()
    {
        return state == State.Idle;
    }

    void IUnit.MoveTo(Vector3 position, float stopDistance, Action onArrivedAtPosition)
    {

        Debug.Log("Movendo personagem para posição = " + position);
        if(Vector3.Distance(gameObject.transform.position, position) > stopDistance) {
            Vector3 moveDir = (position - transform.position).normalized;
            /*Debug.Log("Distancia = " + Vector3.Distance(transform.position, position));*/
            GetComponent<CharacterMovementVelocity>().MoveTowards(moveDir);
        }
            
        else {
            Debug.Log("Chegou");
            onArrivedAtPosition.Invoke();
            state = State.Idle;
        }
            
        /*Vector3 distanceVector = transform.position - position;
        Vector3 distanceVectorNormalized = distanceVector.normalized;
        Vector3 targetPosition = (distanceVectorNormalized * stopDistance);

        Debug.Log("targetPosition = " + targetPosition);
        if (transform.position == targetPosition)
        {
            onArrivedAtPosition.Invoke();
        }*/

    }

    void IUnit.PlayAnimation(Vector3 lookAtPosition, Action onAnimationCompleted)
    {
        Debug.Log("Animação braba");
        onAnimationCompleted.Invoke();
    }
}
