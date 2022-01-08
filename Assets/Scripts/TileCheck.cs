using System;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.EventSystems;

public class TileCheck : MonoBehaviour
{
    public Color hoverColor;
    public Color RedColor;
    public Vector3 positionOffset;

    [Header("Optional")]
    public GameObject tower;

    private Renderer rend;
    private Color startColor;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }
    
    void OnMouseDown()
    {
        rend.material.color = RedColor;

        if (tower != null)
        {
            Debug.Log("Can't build there!");
            BuildManager.Instance.SelectTile(this);
            return;
        }

        // If there's already a tower on a given tile, do not build a tower otherwise continue 
        if (!BuildManager.Instance.CanBuild)
            return;

        //To prevent from multiple building by oneClick and errors when clicking on empty tile
        if (BuildManager.Instance.towerToBuild.prefab != null && tower == null)
        {
            BuildManager.Instance.BuildTowerOn(this);
            //Reset the current selected tower after its construction
            BuildManager.Instance.SelectTowerToBuild(null);
        } 
    }

    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!BuildManager.Instance.CanBuild)
            return;

        rend.material.color = hoverColor;
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
