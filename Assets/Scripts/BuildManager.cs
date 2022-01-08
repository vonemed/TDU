using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    private static BuildManager instance;
    public static BuildManager Instance => instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one BuildManager in scene");
            return;
        }

        instance = this;
    }

    public GameObject plasmaTower;
    public GameObject laserTower;
    public GameObject flameTower;

    [HideInInspector] public TowerBluePrint towerToBuild;
    [HideInInspector] public TileCheck selectedTile;

    public TurretUpgrade _turretUpgrade;

    // Find whether it's possible to build a tower on a given node/tile (false/true)
    public bool CanBuild { get { return towerToBuild != null; } }
    // Find whether the player has money to build the tower (false/true)
    public bool HasMoney { get { return PlayerStats.Instance.GetMoney() >= towerToBuild.cost; } }

    public void BuildTowerOn (TileCheck tile)
    {
        if (PlayerStats.Instance.GetMoney() < towerToBuild.cost)
        {
            Debug.Log("Need more gold!");
            return; 
        }
        // Builds the tower on the given tile(s) to where it "instantiates" the tower alongside deducting from the player's money
        PlayerStats.Instance.DeductMoney(towerToBuild.cost);
        GameObject tower = (GameObject)Instantiate(towerToBuild.prefab, tile.GetBuildPosition(), Quaternion.identity);
        tile.tower = tower;
    }

    public void SelectTowerToBuild (TowerBluePrint tower)
    {
        _turretUpgrade.Hide();
        towerToBuild = tower;
        selectedTile = null;
    }

    public void SelectTile (TileCheck _tile)
    {
        selectedTile = _tile;
        towerToBuild = null;
        _turretUpgrade.SetTarget(_tile);
    }
}
