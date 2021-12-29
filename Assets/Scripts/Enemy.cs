using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [Header("Enemy type")]
    public bool SphereLackey;
    public bool CubeKnight;
    public bool CylinderCommander;

    // having startHealth will help with enemies with any HP without the need to add a fixed number (e.g. 100f, 200f, etc)
    public float startHealth;
    private float health;

    [Header("Unity Stuff")]
    public Image healthBar;

    private void Start()
    {
        health = startHealth;
    }
    // Checks if game is over where if it is, it would check which type of enemy(s) are in the scene and destroy them
    void Update()
    {
        if (GameManager.gameEnded)
        {
            if (SphereLackey || CubeKnight || CylinderCommander)
            {
                Destroy(gameObject);
            }
        }
    }

    public void TakeDamage(float _damage)
    {
        health -= _damage;

        // reduces health bar based on enemy's health dividing by their starting health
        healthBar.fillAmount = health / startHealth;
            
        if (health <= 0)
        {
            if (SphereLackey == true)
                PlayerStats.Money += 1;

            if (CubeKnight == true)
                PlayerStats.Money += 5;

            if (CylinderCommander == true)
                PlayerStats.Money += 10;

            Destroy(gameObject);
        }
    }
}
