using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Turret))]

public class TurretShooting : MonoBehaviour
{
    //Refs
    private bool Plasma; //1
    private bool Laser; //2
    private bool Flame; //3

    private int damage;

    //A reference to Turret component
    private Turret turretRef;

    //Shooting test
    private string currentTurret;

    void Start()
    {
        turretRef = GetComponent<Turret>();

        Plasma = turretRef.Plasma;
        if (Plasma) currentTurret = "Plasma";
        Laser = turretRef.Laser;
        if (Laser) currentTurret = "Laser"; 
        Flame = turretRef.Flame;
        if (Flame) currentTurret = "Flame";
    }

    void Update()
    {
        if(turretRef.GetTarget() != null)
        {
            Shooting(currentTurret);
        }
    }

    void Shooting(string _turret)
    {
        switch(_turret)
        {
            case "Plasma":
                break;
            case "Laser":
                break;
            case "Flame":
                break;
        }
    }
}
