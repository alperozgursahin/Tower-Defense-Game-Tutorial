using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;
    public TurretBlueprint standartTurretPrefab;
    public TurretBlueprint missileLauncherPrefab;
    public TurretBlueprint laserBeamerPrefab;

    void Start()
    {
        buildManager = BuildManager.instance;
        
    }
    public void selectStandartTurret()
    {
        Debug.Log("Selected Standart Turret");
        buildManager.SelectTurretToBuild(standartTurretPrefab);
    }

    public void selectMissileTurret()
    {
        Debug.Log("Selected Missile Launcher");
        buildManager.SelectTurretToBuild(missileLauncherPrefab);
    }

    public void selectLaserTurret()
    {
        Debug.Log("Selected Laser Beamer");
        buildManager.SelectTurretToBuild(laserBeamerPrefab);
    }
}
