using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // public and static so other scripts/objects can access the variable
    public static bool gameEnded;

    public GameObject gameoverUI;

    void Start()
    {
        // initalizing boolean (as false) at the start of each game 
        gameEnded = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Break out of loop if game has ended
        if (gameEnded)
            return;

        if (PlayerStats.Lives <= 0)
        {
            EndGame();
        }

    }

    void EndGame()
    {
        gameEnded = true;

        gameoverUI.SetActive(true);
        
    }
}
