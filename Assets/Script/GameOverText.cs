
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverText : MonoBehaviour
{
    public Text roundText;

    private void OnEnable()
    {
        roundText.text = PlayerStat.GetInstance().getRounds().ToString();
    }

}
