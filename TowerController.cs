using System.Collections;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    [Header("Attributes")]
    public float fireRate = 1f;
    public float range = 2f;
    private float turretRotationSpeed = 10f;
    public float restBetweenShots = 0f;

    [Header("Other")]
    [SerializeField]
    private Transform target;
    public string enemyTag = "enemy";
    public GameObject projectiilePrefab;
    public Transform pivot;

    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f); // To repeat the function every half a second
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag); // An array of GameObjects with the tag "enemy"

        float shortestDistance = Mathf.Infinity; // By default, shortest distance to enemy is infinity
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position); // Turret will have a knowledge of distance to all enemies

            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range) 
        {
            target = nearestEnemy.transform;
        }
    }

    void Update()
    {
        if (target == null)
            return;

        Vector3 dir = target.position - transform.position; // Find the direction vector to target   
        Quaternion lookRotation = Quaternion.LookRotation(dir); // Creates a rotation with the specified forward and upwards directions. (doc)
        Vector3 rot = Quaternion.Lerp(pivot.rotation, lookRotation, Time.deltaTime * turretRotationSpeed).eulerAngles; // Set rotation to Euler angles , using Lerp to smooth the transition
        pivot.rotation = Quaternion.Euler(0f, rot.y, 0f);

        if (restBetweenShots <= 0f)
        {
            Shooting();
            restBetweenShots = 1f / fireRate;
        }

        restBetweenShots -= Time.deltaTime;
    }

    void Shooting()
    {
        Debug.Log("SHOOT");
    }

    void OnDrawGizmosSelected() // To draw gizmos representing the range of the turret
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
