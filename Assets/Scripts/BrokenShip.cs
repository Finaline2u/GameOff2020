using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenShip : Task
{
    private float shipFixPercentage = 0;
    private bool hasChangeFix = false;

    public float ShipFixPercentage { get => shipFixPercentage; }


    public override void DoTask(CharacterStats characterStats, Action onTaskFinished)
    {
        if (shipFixPercentage >= 100)
        {
            onTaskFinished.Invoke();
            return;
        }

        isCooldown = true;
        float fixEfficience = 1 + (characterStats.Intelligence / 10);
        shipFixPercentage += 1 * fixEfficience;
        GameResources.ChangeFixShipPercentage(shipFixPercentage);

        GetComponent<Timer>().AwaitForSeconds(2, () => {
            isCooldown = false;
        });
    }
}
