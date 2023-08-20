using UnityEngine;


[System.Serializable]
public class TurretBlueprint
{
    public GameObject Prefab;
    public int cost;

    public GameObject upgradedPrefab;
    public int upgradeCost;

    public int GetSellAmount()
    {
        return cost / 2;
    }
}
