using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeSellUI : MonoBehaviour
{

    public GameObject ui;
    public static UpgradeSellUI instance;

    private Node target;


    void Awake()
    {
        instance = this;
    }
    public void SetTarget(Node _target)
    {
        target = _target;

        transform.position = target.GetPositionToBuild();

        ui.SetActive(true);
    }

    public void Hide()
    {
        ui.SetActive(false);
    }
    public void Wakeup(Transform positionToWakeup)
    {
        ui.SetActive(true);
        ui.transform.position = positionToWakeup.position;
    }

}


