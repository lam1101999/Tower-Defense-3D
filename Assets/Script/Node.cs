
using UnityEngine;

public class Node : MonoBehaviour
{
    public Color hoverColor;

    private Renderer render;
    private Color startColor;

    private GameObject turret;
    private Vector3 positionOffSet;

    private void Start()
    {
        render = GetComponent<Renderer>();
        startColor = render.material.color;
        positionOffSet = new Vector3(0, 0.5f, 0);
    }

    void OnMouseDown()
    {
        if (turret != null)
        {
            Debug.Log("Cannot build on this node");
            return;
        }

        GameObject currentTurret = BuildManager.GetInstance().GetCurrentTurret();
        turret = (GameObject)Instantiate(currentTurret, transform.position + positionOffSet, transform.rotation);
    }

    void OnMouseEnter()
    {
        render.material.color = hoverColor;
    }

    void OnMouseExit()
    {
        render.material.color = startColor;
    }

}
