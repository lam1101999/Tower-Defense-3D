
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private bool isEndGame = false;
    // Update is called once per frame
    void Update()
    {
        if (isEndGame)
            return;
        CheckEndGame();
    }
    void CheckEndGame()
    {
        if (PlayerStat.GetInstance().GetHealthPoint() <= 0)
        {
            isEndGame = true;
            Debug.Log("Game Over");
        }
    }
}
