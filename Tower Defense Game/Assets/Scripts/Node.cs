using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Vector3 positionOffset;
    [HideInInspector]
    public GameObject turret;

    [HideInInspector]
    public TurretBlueprint turretBlueprint;

    [HideInInspector]
    public bool isUpgraded = false;

    private Renderer rend;
    private Color startColor;
    BuildManager buildManager;
    public Color notEnoughMoneyColor;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = BuildManager.instance;
        buildManager.SelectTurretToBuild(null);
    }
    void OnMouseEnter()
    {
        if (turret != null)
            return;

        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!buildManager.CanBuild)
            return; 

        if (buildManager.HasMoney)
        {
            rend.material.color = hoverColor;
        } else
        {
            rend.material.color = notEnoughMoneyColor;
        }
        
        
    }

    void OnMouseExit()
    {   
        rend.material.color = startColor;
    }

    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (turret != null)
        {
            buildManager.SelectNode(this);
            return;
        }
            
        if (!buildManager.CanBuild)
            return;

        BuildTurret(buildManager.GetTurretToBuild());

    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    void BuildTurret(TurretBlueprint blueprint)
    {
        if (blueprint.Prefab == null) return;

        if (PlayerStats.Money < blueprint.cost)
        {
            Debug.Log("Not Enough Money!");
            return;
        }
        
        PlayerStats.Money -= blueprint.cost;

        GameObject _turret = (GameObject)Instantiate(blueprint.Prefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        turretBlueprint = blueprint;

        GameObject buildEffect = (GameObject)Instantiate(buildManager.buildEffectPrefab, GetBuildPosition(), Quaternion.identity);
        Destroy(buildEffect, 5f);

        Debug.Log("Turret Built!");
    }

    public void UpgradeTurret()
    {


        if (PlayerStats.Money < turretBlueprint.upgradeCost)
        {
            Debug.Log("Not Enough Money!");
            return;
        }
        PlayerStats.Money -= turretBlueprint.upgradeCost;

        Destroy(turret);
        
        GameObject _turret = (GameObject) Instantiate(turretBlueprint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        GameObject buildEffect = (GameObject) Instantiate(buildManager.buildEffectPrefab, GetBuildPosition(), Quaternion.identity);
        Destroy(buildEffect, 5f);

        isUpgraded = true;
        Debug.Log("Turret Upgraded!");

       
    }

    public void SellTurret()
    {
        PlayerStats.Money += turretBlueprint.GetSellAmount();

        GameObject sellEffect = (GameObject)Instantiate(buildManager.sellEffectPrefab, GetBuildPosition(), Quaternion.identity);
        Destroy(sellEffect, 5f);

        Destroy(turret);
        turretBlueprint = null;
    }
}

