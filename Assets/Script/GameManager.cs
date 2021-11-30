
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    private bool isEndGame;
    [Header("Unity setup")]
    public GameObject gameOverUI;
    // Update is called once per frame
    private void Awake() {
        
        instance = this;
    }
    public static GameManager GetInstance(){
        return instance;
    }
    private void Start() {
        isEndGame = false;
    }
    void Update()
    {
        if (isEndGame)
            return;
        CheckEndGame();
    }
    void CheckEndGame()
    {
        if ((PlayerStat.GetInstance().GetHealthPoint() <= 0) || Input.GetKeyDown("e"))
        {
            isEndGame = true;
            CameraController.GetInstance().setIsMove(false);
            gameOverUI.SetActive(true);
            Debug.Log("Game Over");
        }
    }
    public bool isEnd(){
        return isEndGame;
    }
}
