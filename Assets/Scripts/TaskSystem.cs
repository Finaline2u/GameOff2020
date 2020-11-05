using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskSystem : MonoBehaviour
{
    private enum State
    {
        Idle,
        MovingToObjective,
        FixingShip,
    }

    private IUnit unit;
    private State state;
    private Transform resourceNodeTransform;
    //private int shipPercentage = 0;
    [SerializeField] private GameObject brokenShipObj = default;
    private BrokenShip brokenShip;

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
                resourceNodeTransform = GameHandler.GetResourceNode_Static();
                state = State.MovingToObjective;
                break;
            case State.MovingToObjective:
                if (unit.IsIdle())
                {
                    unit.MoveTo(resourceNodeTransform.transform.position, 4.7f, () =>
                    {
                        state = State.FixingShip;
                    });
                }
                break;
            case State.FixingShip:
                if (unit.IsIdle())
                {
                    if (!brokenShip.HasChangeFix)
                    {
                        brokenShip.DoTask(GetComponent<CharacterStats>());
                    }
                    
                    /*if (shipPercentage > 5)
                    {
                        Debug.Log("Finished");
                    } else
                    {
                        Debug.Log("Fixing ship...");

                        unit.PlayAnimation(resourceNodeTransform.transform.position, () =>
                        {
                            shipPercentage++;
                        });
                    }*/
                }
                break;
        }
    }
}
