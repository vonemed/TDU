using UnityEngine;

public class Shop : MonoBehaviour
{
    public TowerBluePrint plasmaTower;
    public TowerBluePrint laserTower;
    public TowerBluePrint flameTower;

    BuildManager b_m;

    void Start()
    {
        b_m = BuildManager.instance;
    }

    public void SelectPlasmaTower()
    {
        Debug.Log("Plasma Tower Selected!");
        b_m.SelectTowerToBuild(plasmaTower);
    }

    public void SelectLaserTower()
    {
        Debug.Log("Laser Tower Selected!");
        b_m.SelectTowerToBuild(laserTower);
    }

    public void SelectFlameTower()
    {
        Debug.Log("Flame Tower Selected!");
        b_m.SelectTowerToBuild(flameTower);
    }
}
