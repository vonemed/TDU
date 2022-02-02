using UnityEngine;

//Add shooting script by default
[RequireComponent(typeof(TurretShooting))]

public class Turret : MonoBehaviour
{
    //General
    public bool Plasma;
    public bool Laser;
    public bool Flame;

    public Transform shootingPoint;

    [SerializeField] private float range;
    [SerializeField] private int damage;
    [SerializeField] private float turretRotationSpeed = 10f;

    //Target finding
    private Transform target;
    private Enemy targetEnemy; // The enemy component of the target, so that we don't need to find the component of the target every frame
    private string enemyTag = "enemy";

    //Shooting test
    private string currentTurret;
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f); // To repeat the function every half a second
        if (Plasma) currentTurret = "Plasma";
        if (Laser) currentTurret = "Laser";
        if (Flame) currentTurret = "Flame";

        SelectedTurret(currentTurret);
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

        }
        else
        {
            target = null;
        }
    }

    void Update()
    {

    }
    public Transform GetTarget()
    {
        return target;
    }

    void SelectedTurret(string _turret)
    {
        switch (_turret)
        {
            case "Plasma":
                gameObject.AddComponent<PlasmaTurret>().TurretSetUp(range, damage, shootingPoint);
                break;
            case "Laser":
                gameObject.AddComponent<LaserTurret>();
                break;
            case "Flame":
                gameObject.AddComponent<FlameTurret>();
                break;
        }
    }
}
