using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    private GameObject turretToBuild;
    public GameObject standartTurretPrefab;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("More than 1 BuildManager!");
            return;
        }
        instance = this ; 
    }

    private void Start()
    {
        turretToBuild = standartTurretPrefab;
    }


    public GameObject getTurretToBuild()
    {
        return turretToBuild;
    }
}
