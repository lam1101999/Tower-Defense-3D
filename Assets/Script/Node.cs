
using UnityEngine;

public class Node : MonoBehaviour
{
    public Color hoverColor;

    private Renderer render;
    private Color startColor;

    private GameObject turret;
    private Vector3 positionOffSet;
    private BuildManager buildManager;

    private void Start()
    {
        render = GetComponent<Renderer>();
        startColor = render.material.color;
        positionOffSet = new Vector3(0, 0.5f, 0);
        buildManager = BuildManager.GetInstance();
    }

    void OnMouseDown()
    {
        if (turret != null)
        {
            Debug.Log("Cannot build on this node");
            return;
        }
        buildManager.buildTurretOn(this);

    }

    void OnMouseEnter()
    {
        if (buildManager.GetCurrentTurret()!= null && buildManager.IsEnoughMoney())
            render.material.color = hoverColor;
        else render.material.color = Color.red;
    }

    void OnMouseExit()
    {
        render.material.color = startColor;
    }
    public void SetTurret(GameObject _turret)
    {
        turret = _turret;
    }
    public Vector3 GetPositionToBuild()
    {
        return transform.position + positionOffSet;
    }

}
