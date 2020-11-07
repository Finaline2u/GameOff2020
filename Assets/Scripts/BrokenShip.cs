using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenShip : Task, ITaskObject
{
    private float shipFixPercentage = 0;
    private bool hasChangeFix = false;

    public float ShipFixPercentage { get => shipFixPercentage; }
    public bool HasChangeFix { get => hasChangeFix; }

    public void DoTask(CharacterStats characterStats)
    {
        hasChangeFix = true;
        float fixEfficience = 1 + (characterStats.Intelligence / 10);
        shipFixPercentage += 1 * fixEfficience;
        GameResources.ChangeFixShipPercentage(shipFixPercentage);

        GetComponent<Timer>().AwaitForSeconds(2, () => {
            hasChangeFix = false;
        });
    }

    public void OnTaskFinished()
    {
        throw new System.NotImplementedException();
    }
}
