using UnityEngine;

public class WaypointHandling : MonoBehaviour
{
    // Creating an array of position of waypoints
    // Static - so it can be accessed from anywhere
    public static Transform[] waypoints;

    public void Awake()
    {
        waypoints = new Transform[transform.childCount]; // This will decide the size of the array based on how many children does this object has

        for (int i = 0; i < waypoints.Length; i++)
        {
            waypoints[i] = transform.GetChild(i); // Getting children of the object into an array
        }
    }

    public void Update()
    {
        
    }
}
