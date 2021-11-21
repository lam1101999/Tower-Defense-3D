using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    private static BuildManager instance;
    private currentTurret;
    
    [Header("Unity setup")]
    public GameObject standardTurret;
    
    private void Awake(){
    instance = new BuildManager();
    currentTurret = standardTurret
    }
    
    public static void GetInstance(){
      if(instance == null){
      instance = new BuildManager();
      }
      return instance;
    }
    public void GetCurrentTurret(){
    return currentTurret;}
}
