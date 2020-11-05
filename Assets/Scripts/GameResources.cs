using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameResources
{
    private static int scrapAmount;
    private static int foodAmount;
    private static float fixShipPercentage;

    public static event EventHandler OnFixShipPercentageChanged;

    public static int ScrapAmount { get => scrapAmount;}

    public static void AddScrapAmount(int amount)
    {
        scrapAmount += amount;
    }

    public static void ChangeFixShipPercentage(float upgradeNumber)
    {
        fixShipPercentage += 1 * upgradeNumber;
        Debug.Log("[GameResources] fixShipPercentage = " + fixShipPercentage);
        OnFixShipPercentageChanged?.Invoke(fixShipPercentage, EventArgs.Empty);
    }
}
