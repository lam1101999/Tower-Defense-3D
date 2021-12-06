using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public string level = "SelectLevel";

    public void Play(){
        SceneManager.LoadScene(level);
    }
    public void Quit(){
        Application.Quit();
    }
}
