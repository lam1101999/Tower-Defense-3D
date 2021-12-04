using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public string level = "Map 1";

    public void Play(){
        SceneManager.LoadScene(level);
    }
    public void Quit(){
        Application.Quit();
    }
}
