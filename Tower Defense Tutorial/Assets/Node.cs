using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Vector3 positionOffset;
    private GameObject turret;
    private Renderer rend;
    private Color startColor;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        
    }
    void OnMouseEnter()
    {
        rend.material.color = hoverColor;   
    }

    void OnMouseExit()
    {   
        rend.material.color = startColor;
    }

    void OnMouseDown()
    {
        if (turret != null)
        {
            return;
        }

        GameObject turretToBuild = BuildManager.instance.getTurretToBuild();
        turret = (GameObject) Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);

    }
}
