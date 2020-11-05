using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdateTextChecker : MonoBehaviour
{
    [SerializeField] Resources resouce = Resources.Scrap;
    private enum Resources
    {
        Scrap,
        Food,
        ShipFixPercentage,
    }

    //event EventHandler eventAttribute;
    // Start is called before the first frame update
    void Awake()
    {
        //TODO: Melhorar isso
        switch (resouce)
        {
            case Resources.ShipFixPercentage:
                GameResources.OnFixShipPercentageChanged += delegate (object sender, EventArgs e)
                {
                    UpdateText(sender.ToString() + "%");
                }; 
                break;
        }

        /*eventAttribute += delegate (object sender, EventArgs e)
        {
            UpdateText(sender as string);
        };*/
    }

    private void UpdateText(string text)
    {
        GetComponent<TextMeshProUGUI>().text = text;
    }
}
