using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject GameOverScreen;
    public TextMeshProUGUI highscoreText;
    private int highScore;

    public PlayerScript player;
    public CanvasManager canvas;
    public EnemySpawner enemySpawner;
    private void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        UpdateScoreText();
        //PlayerPrefs.DeleteAll();

    }
    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void gameOver()
    {
        GameOverScreen.SetActive(true);
        player.enabled = false;

        enemySpawner.StopSpawning();

        if (player.Score > highScore)
        {
            highScore = player.Score;
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
        }

        if (highscoreText != null)
        {
            highscoreText.text = "High Score: " + highScore;
        }
    }
    private void UpdateScoreText()
    {
        if (highscoreText != null)
            highscoreText.text = "High Score: " + highScore;
    }

    
}
