using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [Header("Unity Setup")]
    public GameObject standardTurret;
    public GameObject rocketTurret;
    
    public void PurchaseStandardTurret(){
        BuildManager buildManager = BuildManager.GetInstance();
        buildManager.SetCurrentTurret(standardTurret);
    }
     public void PurchaseRocketTurret(){
        BuildManager buildManager = BuildManager.GetInstance();
        buildManager.SetCurrentTurret(rocketTurret);
    }
}
