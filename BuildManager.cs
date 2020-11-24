using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

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

    private TowerBluePrint towerToBuild;

    // Find whether it's possible to build a tower on a given node/tile (false/true)
    public bool CanBuild { get { return towerToBuild != null; } }
    // Find whether the player has money to build the tower (false/true)
    public bool HasMoney { get { return PlayerStats.Money >= towerToBuild.cost; } }

    public void BuildTowerOn (TileCheck tile)
    {
        if (PlayerStats.Money < towerToBuild.cost)
        {
            Debug.Log("Need more gold!");
            return; 
        }
        // Builds the tower on the given tile(s) to where it "instantiates" the tower alongside deducting from the player's money
        PlayerStats.Money -= towerToBuild.cost;
        GameObject tower = (GameObject)Instantiate(towerToBuild.prefab, tile.GetBuildPosition(), Quaternion.identity);
        tile.tower = tower;
    }

    public void SelectTowerToBuild (TowerBluePrint tower)
    {
        towerToBuild = tower;
    }

}
