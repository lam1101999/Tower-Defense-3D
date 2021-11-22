
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    private static BuildManager instance;
    private GameObject currentTurret;

    [Header("Unity setup")]
    public GameObject standardTurret;

    private void Awake()
    {
        instance = this;
        currentTurret = standardTurret;
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
}
