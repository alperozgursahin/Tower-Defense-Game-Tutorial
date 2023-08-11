using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    private GameObject turretToBuild;
    [Header("Prefabs")]
    public GameObject standartTurretPrefab;
    public GameObject missileTurretPrefab;
    public GameObject laserTurretPrefab;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("More than 1 BuildManager!");
            return;
        }
        instance = this ; 
    }

    public void setTurretToBuild(GameObject turret)
    {
        turretToBuild = turret;
    }
    public GameObject getTurretToBuild()
    {
        return turretToBuild;
    }
}
