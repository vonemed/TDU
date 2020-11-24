using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy type")]
    public bool SphereLackey;
    public bool CubeKnight;
    public bool CylinderCommander;

    public float health;

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
