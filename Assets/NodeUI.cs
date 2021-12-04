using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class NodeUI : MonoBehaviour
{
    public GameObject ui;

    public BuildManager buildManager;

    public Node node;

    public static NodeUI instance;

    private Node target;

    private void Awake()
    {   
        buildManager = BuildManager.GetInstance();
        instance = this;
    }
    public static NodeUI GetInstance()
    {
        return instance;
    }

    public void SetTarget (Node _target) 
    {
        target = _target;

        transform.position = target.GetPositionToBuild();

        ui.SetActive(true);
    }

    public void Hide ()
    {
        ui.SetActive(false);
    }

    public void Upgrade ()
    {    
        buildManager.UpgradeTurret(target);
        Hide();
    }

    public void Sell ()
    {   
        buildManager.SellTurret(target);
        Hide();
    }
}
