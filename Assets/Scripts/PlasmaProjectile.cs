using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlasmaProjectile : MonoBehaviour
{
    [Header("Attributes")]
    public float speed = 10f;
    public float damage;
    public float explosionRadius = 0f;

    [SerializeField] private float timeBeforeDissapear;

    [SerializeField] private ParticleSystem explosionEffect;
    private ParticleSystem explosionRef;

    private Transform target;


    public void findTarget(Transform _target)
    {
        target = _target;
    }

    void Update()
    {
        if(target == null)
        {
            gameObject.SetActive(false);
            return;

        } else
        {
            gameObject.SetActive(true);
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
        if(explosionEffect != null) 
        {
            explosionRef = Instantiate(explosionEffect, target.position, target.rotation);
            explosionRef.Play();
            StartCoroutine(StopEffectsAfterTime(timeBeforeDissapear));
        }
        
        if (explosionRadius > 0f) // Flames
        {
            explosion();
        }
        else // regular plasma projectile
        {
            Damage(target);
        }
        
        gameObject.SetActive(false);
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

    IEnumerator StopEffectsAfterTime(float _time)
    {
        Debug.Log("stoppins");
        yield return new WaitForSeconds(_time);
        explosionRef.Stop();
    }
}
