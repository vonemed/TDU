using UnityEngine;

public class Shop : MonoBehaviour
{
    public TowerBluePrint plasmaTower;
    public TowerBluePrint laserTower;
    public TowerBluePrint flameTower;

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
