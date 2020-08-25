using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void TakeDamage(float _damage)
    {
        health -= _damage;

        Debug.Log(health);

        if (health <= 0)
        {
            Destroy(gameObject);
            Debug.Log("Dead");
        }
    }
}
