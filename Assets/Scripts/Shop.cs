using UnityEngine;

public class Shop : MonoBehaviour
{
    private TowerBluePrint plasmaTower;
    private TowerBluePrint laserTower;
    private TowerBluePrint flameTower;

    //Add cost value from buildermanager

    void Awake()
    {
        plasmaTower = BuildManager.Instance.plasmaTower;
        laserTower = BuildManager.Instance.laserTower;
        flameTower = BuildManager.Instance.flameTower;
    }
    public void SelectPlasmaTower()
    {
        Debug.Log("Plasma Tower Selected!");
        BuildManager.Instance.SelectTowerToBuild(plasmaTower);
    }

    public void SelectLaserTower()
    {
        Debug.Log("Laser Tower Selected!");
        BuildManager.Instance.SelectTowerToBuild(laserTower);
    }

    public void SelectFlameTower()
    {
        Debug.Log("Flame Tower Selected!");
        BuildManager.Instance.SelectTowerToBuild(flameTower);
    }
}
