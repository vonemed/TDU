using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int Money;
    public int startingMoney = 20;
    // static due to the same reasons as the aforementioned "Money"
    public static int Lives;
    public int startingLives = 20;
    // to store the specific wave/round the player is on
    public static int Rounds;

    void Start()
    {
        Money = startingMoney;
        Lives = startingLives;

        Rounds = 0;
    }

    void Update() // Just to check the amount that player earns. هههههههههههههههههههههههههههههه
    {
        Debug.Log("Money:" + " " + Money);
    } 
}
