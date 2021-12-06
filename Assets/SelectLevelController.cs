using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class SelectLevelController : MonoBehaviour
{
    public Button[] levelButtons;

    void Start()
    {
        int levelReached = PlayerPrefs.GetInt("levelReached", 1);
        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i + 1 > levelReached)
            {
                levelButtons[i].image.color = Color.black;
                levelButtons[i].interactable = false;
              
            }

        }
    }
    public void LoadMap(string mapName)
    {
        SceneManager.LoadScene(mapName);
    }
}
