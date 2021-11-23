using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Shop : MonoBehaviour
{
    [Header("Unity Setup")]
    public GameObject standardTurret;
    public Text standardTurretMoneyText;
    public GameObject rocketTurret;
    public Text rocketTurretMoneyText;
    private void Awake()
    {
        standardTurretMoneyText.text = standardTurret.GetComponent<Turret>().cost.ToString();
        rocketTurretMoneyText.text = rocketTurret.GetComponent<Turret>().cost.ToString();
    }
    public void SelectStandardTurret()
    {
        BuildManager buildManager = BuildManager.GetInstance();
        buildManager.SetCurrentTurret(standardTurret);
    }
    public void SelectRocketTurret()
    {
        BuildManager buildManager = BuildManager.GetInstance();
        buildManager.SetCurrentTurret(rocketTurret);
    }
}
