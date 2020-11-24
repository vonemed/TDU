using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class MoneyUI : MonoBehaviour
{
    public Text moneyText;

    void Update()
    {
        // Updates the displayed player's money in the game's UI
        moneyText.text = "$" + PlayerStats.Money.ToString();
    }
}
