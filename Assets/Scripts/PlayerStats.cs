using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private static PlayerStats instance;
    public static PlayerStats Instance => instance;

    [SerializeField] private int startingMoney;
    private int currentMoney;
    
    // static due to the same reasons as the aforementioned "Money"
    public static int Lives;
    public int startingLives = 20;
    // to store the specific wave/round the player is on
    public static int Rounds;

    void Start()
    {
        instance = this;

        currentMoney = startingMoney;
        Lives = startingLives;

        Rounds = 0;
    }

    public void AddMoney(int _amount)
    {
        currentMoney += _amount;
    }

    public void DeductMoney(int _amount)
    {
        currentMoney -= _amount;
    }

    public int GetMoney()
    {
        return currentMoney;
    }
}
