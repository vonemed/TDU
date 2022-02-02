using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerShooting : MonoBehaviour
{
    private bool plasma;
    private bool laser;
    private bool flame;

    private bool upgraded;

    // Start is called before the first frame update
    void Start()
    {
        plasma = GetComponent<TowerController>().PlasmaTower;
        laser = GetComponent<TowerController>().LaserTower;
        flame = GetComponent<TowerController>().FlameTower;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
