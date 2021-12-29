using UnityEngine;
using UnityEngine.UI;

public class EnemyBoss : MonoBehaviour
{
    [Header("Boss type")]
    public bool kingSphere;
    public bool lordCube;
    public bool eternalCyllinder;

    [Header("Unity Stuff")]
    public Image healthBar;

    public float startHealth;
    private float health;
    private bool invincible = false;
    private int defaultNumber = 100;

    void Start()
    {
        //Get component and change its speed depending on the type of boss
    }

    void Update()
    {
        //if invincible false
        //add a 20% chance to activate defence ability
        //generate a random number from 100
        //if this number is less or equal 20 then activate the ability
    }

    //add a defence ability function
    //add a countdown for 2 seconds
    //invincible = true;
    //after 2 seconds
    //invincible = false

    public void TakeDamage(float _damage)
    {
        if(invincible == false)
            health -= _damage;

        healthBar.fillAmount = health / startHealth;

        if (health <= 0)
        {
            if (kingSphere == true)
                PlayerStats.Money += 50;

            if (lordCube == true)
                PlayerStats.Money += 100;

            if (eternalCyllinder == true)
                PlayerStats.Money += 999;
            
            Destroy(gameObject);
        }
    }

    void DefensiveBuff()
    {
        if(kingSphere == true)
        {
            invincible = true;
        }
    }
}
