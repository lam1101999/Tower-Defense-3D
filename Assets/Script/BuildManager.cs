
using UnityEngine;
using UnityEngine.UI;

public class BuildManager : MonoBehaviour
{
    private static BuildManager instance;
    private GameObject currentTurret;
    private PlayerStat playerStat;

    [Header("Unity setup")]

    public GameObject standardTurret;

    private void Awake()
    {
        instance = this;
        playerStat = PlayerStat.GetInstance();
    }

    private void Update()
    {

       


    }
    public static BuildManager GetInstance()
    {
        if (instance == null)
        {
            instance = new BuildManager();
        }
        return instance;
    }


    public GameObject GetCurrentTurret()
    {
        return currentTurret;
    }
    public void SetCurrentTurret(GameObject _currentTurret)
    {
        currentTurret = _currentTurret;
    }
    public bool IsEnoughMoney()
    {  
        if (playerStat.GetCurrency() < currentTurret.GetComponent<Turret>().cost)
            return false;
        else
            return true;

    }
    public void buildTurretOn(Node node)
    {
        //check if currentTurret null
        if (currentTurret == null)
            return;
        //check conccurency
        if (!IsEnoughMoney())
            return;

        playerStat.DeCredit(currentTurret.GetComponent<Turret>().cost);
        node.SetTurret((GameObject)Instantiate(currentTurret, node.GetPositionToBuild(), node.transform.rotation));

    }
}
