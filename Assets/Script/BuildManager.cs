
using UnityEngine;
using UnityEngine.UI;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    private GameObject currentTurret;

    private Node selectedNode;
    private UpgradeSellUI upgradeSellUI;
    private PlayerStat playerStat;

    [Header("Unity setup")]

    public GameObject standardTurret;

    private void Awake()
    {
        instance = this;
        playerStat = PlayerStat.GetInstance();
        upgradeSellUI = UpgradeSellUI.instance;
    }

    private void Update()
    {



    }
    public static BuildManager GetInstance()
    {
        // if (instance == null)
        // {
        //     instance = new BuildManager();
        // }
        return instance;
    }


    public GameObject GetCurrentTurret()
    {
        return currentTurret;
    }
    public void SetCurrentTurret(GameObject _currentTurret)
    {
        currentTurret = _currentTurret;
        DeselectNode();
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

    public void UpgradeTurret()
    {
        if (selectedNode == null && selectedNode.getTurret() == null)
            return;
        if (!IsEnoughUpgradeMoney())
            return;
        if (!IsUpgraded())
            return;
        playerStat.DeCredit(selectedNode.getTurret().GetComponent<Turret>().upgradeCost);
        Destroy(selectedNode.getTurret());
        selectedNode.SetTurret((GameObject)Instantiate(selectedNode.getTurret().GetComponent<Turret>().upgradedTurret, selectedNode.GetPositionToBuild(), selectedNode.transform.rotation));
        upgradeSellUI.Hide();
    }

    public void SellTurret()
    {
        if (selectedNode == null && selectedNode.getTurret() == null)
            return;

        playerStat.AddCredit(selectedNode.getTurret().GetComponent<Turret>().cost / 2);
        //Destroy
        Destroy(selectedNode.getTurret());
        selectedNode = null;
        upgradeSellUI.Hide();
    }

    public bool IsEnoughMoney()
    {
        if (playerStat.GetCurrency() < currentTurret.GetComponent<Turret>().cost)
            return false;
        else
            return true;

    }
    public bool IsEnoughUpgradeMoney()
    {
        if (playerStat.GetCurrency() < selectedNode.getTurret().GetComponent<Turret>().upgradeCost)
            return false;
        else
            return true;

    }

    public bool IsUpgraded()
    {
        if (selectedNode.getTurret().GetComponent<Turret>().upgradeCost == 0)
            return false;
        else
            return true;
    }

    public void setNode(Node _selectedNode)
    {
        if (selectedNode == _selectedNode)
        {
            DeselectNode();
            return;
        }

        selectedNode = _selectedNode;
        currentTurret = null;
        upgradeSellUI = UpgradeSellUI.instance;
        upgradeSellUI.Wakeup(selectedNode.transform);
    }

    public void DeselectNode()
    {
        selectedNode = null;
        UpgradeSellUI.instance.Hide();
    }
}
