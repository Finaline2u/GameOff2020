using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskSystem : MonoBehaviour
{
    public static event EventHandler OnWorkerClicked;

    [SerializeField] private SpriteRenderer selector = default;
    private bool isSelected = false;

    private enum State
    {
        Idle,
        MovingToObjective,
        DoingTask,
    }

    private IUnit unit;
    private State state;
    private Transform resourceNodeTransform;
    [SerializeField] private GameObject brokenShipObj = default;
    private BrokenShip brokenShip;
    private Task currentTask;
    

    // Start is called before the first frame update
    void Awake()
    {
        brokenShip = brokenShipObj.GetComponent<BrokenShip>();
        unit = gameObject.GetComponent<IUnit>();

        state = State.Idle;
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case State.Idle:
                /*resourceNodeTransform = GameHandler.GetResourceNode_Static();*/
                GetComponent<CharacterMovementVelocity>().Stop();
                /*state = State.MovingToObjective;*/
                break;
            case State.MovingToObjective:
                if (unit.IsIdle())
                {
                    unit.MoveTo(currentTask.transform.position, 4.7f, () =>
                    {
                        state = State.DoingTask;
                    });
                }
                break;
            case State.DoingTask:
                if (unit.IsIdle())
                {
                    if (!brokenShip.HasChangeFix)
                    {
                        brokenShip.DoTask(GetComponent<CharacterStats>());
                    }
                }
                break;
        }
    }

    private void OnMouseDown()
    {
        isSelected = !isSelected;
        Debug.Log("Personagem clicado.");
        selector.enabled = isSelected;
        OnWorkerClicked?.Invoke(this, EventArgs.Empty);
    }

    public void SetTask(Task task)
    {
        this.currentTask = task;
        state = State.MovingToObjective;
    }
}
