using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text pointsText;
    [SerializeField] private GameObject PauseMenu;
    
    public void UpdatePoints(int currentPoints)
    {
        pointsText.text = "Points: " + currentPoints;
    }

    public void PauseGame()
    {
        PauseMenu.SetActive(true);
        GameManager.Instance.PauseGame();
    }
    public void ResumeGame()
    {
        PauseMenu.SetActive(false);
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
}
