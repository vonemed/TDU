using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlasmaProjectile : MonoBehaviour
{
    [Header("Attributes")]
    public float speed = 10f;
    public float damage;

    private Transform target;
    public float explosionRadius = 0f;

    public void findTarget(Transform _target)
    {
        target = _target;
    }

    void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distThisFrame)
        {
            hitTarget();
            return;
        }

        transform.Translate(dir.normalized * distThisFrame, Space.World);
    }

    public void hitTarget()
    {
        if (explosionRadius > 0f) // Flames
        {
            explosion();
        }
        else // regular plasma projectile
        {
            Damage(target);
        }

        Destroy(gameObject);
    }

    public void explosion()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.tag == "enemy")
            {
                Damage(collider.transform);
            }
        }
    }

    void Damage(Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();

        if (e != null)
        {
            e.TakeDamage(damage);

        } else // If its can't find enemy component then it is a boss;
        {
            EnemyBoss eb = enemy.GetComponent<EnemyBoss>();
            eb.TakeDamage(damage);
        }
    }

    void OnDrawGizmosSelected() // Draw collision sphere of projectiles
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
