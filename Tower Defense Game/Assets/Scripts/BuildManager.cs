using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    public TurretBlueprint turretToBuild; 
    public GameObject buildEffectPrefab;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("More than 1 BuildManager!");
            return;
        }
        instance = this ;
    }
    
    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
    }
    public void BuildTurretOn(Node node)
    {   
        if (PlayerStats.Money < turretToBuild.cost)
        {
            Debug.Log("Not Enough Money!");
            return;
        }
        PlayerStats.Money -= turretToBuild.cost;
        GameObject turret = (GameObject) Instantiate(turretToBuild.Prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;
        GameObject buildEffect = (GameObject) Instantiate(buildEffectPrefab, node.GetBuildPosition(), Quaternion.identity);
        Destroy(buildEffect, 5f);
        Debug.Log("Turret Built! Money: " + PlayerStats.Money);
    }
}
