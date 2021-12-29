using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float defaultSpeed = 1f;

    [HideInInspector] // Don't need variable to be modified in unityEditor, but still be public
    public float currentSpeed;

    private Transform target;  // A current waypoint for enemy to follow
    private int waypointIndex = 0;

    void Start()
    {
        target = WaypointHandling.waypoints[waypointIndex];
        currentSpeed = defaultSpeed;
    }

    void Update()
    {
        Vector3 Vdir = target.position - transform.position;

        transform.Translate(Vdir.normalized * currentSpeed * Time.deltaTime, Space.World);

        if(Vector3.Distance(transform.position, target.position) <= 0.1f)
        {
            ChangeWaypoint();
        }

        currentSpeed = defaultSpeed;
    }

    public void SlowEffect(float _slowValue)
    {
        currentSpeed = _slowValue;
    }
    void EndPath()
    {
        // Once the enemy reaches the end of their path, it would reduce from the player's lives and the gameobject is "destroyed"
        PlayerStats.Lives--;
        Destroy(gameObject);
    }

    void ChangeWaypoint()
    {
        if (waypointIndex >= WaypointHandling.waypoints.Length - 1) // If reached the last object - then destroy itself
        {
            EndPath();
        }
        else // If not procced to the next waypoint in the array
        {
            waypointIndex++;
            target = WaypointHandling.waypoints[waypointIndex];
        }
    }
}
