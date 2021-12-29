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

    BuildManager buildManager;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManager = BuildManager.instance;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }
    
    void OnMouseDown()
    {
        // If there's already a tower on a given tile, do not build a tower otherwise continue 
        if (!buildManager.CanBuild)
            return;
        // If player has money, do normal highlighted color, otherwise make it red which indicates that they can't build due to no money
        if (buildManager.HasMoney)
        {
            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = RedColor;
        }

        if (tower != null)
        {
            Debug.Log("Can't build there!");
            return;
        }

        buildManager.BuildTowerOn(this);
    }

    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!buildManager.CanBuild)
            return;

        rend.material.color = hoverColor;
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
