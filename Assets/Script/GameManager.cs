using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    private bool isEndGame;
    private bool isPause;
    [Header("Unity setup")]
    public GameObject gameOverUI;
    public GameObject pauseUI;
    // Update is called once per frame
    private void Awake()
    {

        instance = this;
    }
    public static GameManager GetInstance()
    {
        return instance;
    }
    private void Start()
    {
        isEndGame = false;
        isPause = false;
    }
    void Update()
    {
        if (isEndGame)
            return;
        CheckEndGame();
        CheckPauseGame();
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
    public bool isEnd()
    {
        return isEndGame;
    }
    public void CheckPauseGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            isPause = !isPause;
            pauseUI.GetComponent<PauseText>().Toggle();
        }

        if (isPause)
        {
            Time.timeScale = 0f;
        }
        else
            Time.timeScale = 1f;
    }

    public void Retry()
    {
        Continue();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void Continue()
    {
        pauseUI.SetActive(false);
        isPause =false;
    }
    

}
