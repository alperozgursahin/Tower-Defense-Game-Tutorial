using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }
    public void purchaseStandartTurret()
    {
        Debug.Log("Purchased Standart");
        buildManager.setTurretToBuild(buildManager.standartTurretPrefab);
    }

    public void purchaseMissileTurret()
    {
        Debug.Log("Purchased Missile");
        buildManager.setTurretToBuild(buildManager.missileTurretPrefab);
    }

    public void purchaseLaserTurret()
    {
        Debug.Log("Purchased Laser");
        buildManager.setTurretToBuild(buildManager.laserTurretPrefab);
    }
}
