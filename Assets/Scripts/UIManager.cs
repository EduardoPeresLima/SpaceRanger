using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text pointsText;
    [SerializeField] private GameObject PauseMenuPanel;
    [SerializeField] private GameObject GameOverPanel;
    [SerializeField] private Text gameOverText;
    
    
    public void UpdatePoints(int currentPoints)
    {
        pointsText.text = "Points: " + currentPoints;
    }
    

    public void PauseGame()
    {
        PauseMenuPanel.SetActive(true);
        GameManager.Instance.PauseGame();
    }
    public void ResumeGame()
    {
        PauseMenuPanel.SetActive(false);
        GameManager.Instance.ResumeGame();
    }
    public void RestartGame()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void GameOver(int totalPoints)
    {
        GameOverPanel.SetActive(true);
        gameOverText.text = string.Format("GAME OVER\n\nYOU GAINED {0} POINTS",totalPoints);
        GameManager.Instance.PauseGame();
    }
}
