using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlasmaProjectile : MonoBehaviour
{
    [Header("Attributes")]
    public float speed = 10f;
    private float damage = 50f;

    private Transform target;

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
        target.GetComponent<Enemy>().TakeDamage(damage);
        Destroy(gameObject);
        Debug.Log("HIT!");
    }
}
