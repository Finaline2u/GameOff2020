﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Tooltip : MonoBehaviour
{
    public TextMeshProUGUI name;
    public TextMeshProUGUI life;
    public TextMeshProUGUI strength;

    public void ShowCharacterStats(string name, int life, int strength)
    {
        this.name.text = name;
        this.life.text = life.ToString();
        this.strength.text = strength.ToString();
    }
}
