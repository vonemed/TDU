using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;

    private Transform target;  // A current waypoint for enemy to follow
    private int waypointIndex = 0;

    void Start()
    {
        target = WaypointHandling.waypoints[waypointIndex];
    }

    void Update()
    {
        Vector3 Vdir = target.position - transform.position;

        transform.Translate(Vdir.normalized * speed * Time.deltaTime, Space.World);

        if(Vector3.Distance(transform.position, target.position) <= 0.1f)
        {
            ChangeWaypoint();
        }
        ////////////////
        // 1) Moving the object to targetted waypoint
        // 2) Check if it reached it (collision?, coordinates?)
        // 3) Increase the value of waypointIndex
        // 4) Update target
        ////////////////
        void ChangeWaypoint()
        {
            if (waypointIndex >= WaypointHandling.waypoints.Length - 1) // If reached the last object - then destroy itself
            {
                Destroy(gameObject);
            }
            else // If not procced to the next waypoint in the array
            {
                waypointIndex++;
                target = WaypointHandling.waypoints[waypointIndex];
            }
        }
    }
}
