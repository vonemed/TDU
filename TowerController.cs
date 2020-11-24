using System.Collections;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    [Header("General Attributes")]
    public float range = 2f;

    [Header("Plasma Tower")]
    public bool PlasmaTower;
    public float fireRate =1f;
    public GameObject projectiilePrefab;

    [Header("Laser Tower")]
    public bool LaserTower;
    public LineRenderer lineRenderer;
    private int damageOverTime = 30;

    [Header("Flame Tower")]
    public bool FlameTower;
    public ParticleSystem flames;
    public GameObject flameMissilePrefab;


    private float turretRotationSpeed = 10f;
    private float restBetweenShots = 0f;

    [Header("Other")]
    [SerializeField]
    private Transform target;
    private Enemy targetEnemy; // The enemy component of the target, so that we don't need to find the component of the target every frame
    public string enemyTag = "enemy";
    public Transform shootingPoint;
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
            targetEnemy = nearestEnemy.GetComponent<Enemy>();

        } else
        {
            target = null;
        }
    }

    void Update()
    {
        if (target == null)
        {
            if (LaserTower == true)
            {
                lineRenderer.enabled = false;

            } else if (FlameTower == true)
            {
                flames.Pause();
                flames.Clear(flames);
            }
            return;
        }

        LockToTarget();

        if (PlasmaTower == true)
        {
            if (restBetweenShots <= 0f)
            {
                Shooting();
                restBetweenShots = 1f / fireRate;
            }

            restBetweenShots -= Time.deltaTime;

        } else if (LaserTower == true)
        {
            Laser();

        } else if (FlameTower == true)
        {
            fireRate = 3f;
            Flame();
            if (restBetweenShots <= 0f)
            {
                Shooting();
                restBetweenShots = 1f / fireRate;
            }

            restBetweenShots -= Time.deltaTime;
        }
    }

    void LockToTarget()
    {
        Vector3 dir = target.position - transform.position; // Find the direction vector to target   
        Quaternion lookRotation = Quaternion.LookRotation(dir); // Creates a rotation with the specified forward and upwards directions. (doc)
        Vector3 rot = Quaternion.Lerp(pivot.rotation, lookRotation, Time.deltaTime * turretRotationSpeed).eulerAngles; // Set rotation to Euler angles , using Lerp to smooth the transition
        pivot.rotation = Quaternion.Euler(0f, rot.y, 0f);
    }

    void Shooting()
    {
        GameObject projectileInst = (GameObject)Instantiate(projectiilePrefab, shootingPoint.position, shootingPoint.rotation); // Instantiate a projectile based on prefab
        PlasmaProjectile projectile = projectileInst.GetComponent<PlasmaProjectile>(); // Give the projectile plasma attributes

        if (projectile != null)
        {
            projectile.findTarget(target); // If the projectile is instantiated it needs to search for the target immediately
        }
    }

    void Laser()
    {
        lineRenderer.enabled = true;
        lineRenderer.SetPosition(0, shootingPoint.position);
        lineRenderer.SetPosition(1, target.position);

        targetEnemy.TakeDamage(damageOverTime * Time.deltaTime); //So now the speed of which enemy receives the damage is not depending on computer speed. Also the damage is inflicted per second NOT per frame 
        target.GetComponent<EnemyMovement>().SlowEffect(0.5f);
    }

    void Flame()
    {
        flames.Play();
    }

    void OnDrawGizmosSelected() // To draw gizmos representing the range of the turret
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
