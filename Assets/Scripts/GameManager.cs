using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public bool GamePaused { get; private set; }

    [SerializeField] private UIManager _uiManager;
    private void Awake()
    {
        if(Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private int currentPoints;
    void Start()
    {
        currentPoints = 0;
        GamePaused = false;
    }

    public void AddPoints(int deltaPoints)
    {
        currentPoints += deltaPoints;
        _uiManager.UpdatePoints(currentPoints);
    }

    public void PauseGame()
    {
        GamePaused = true;
    }

    public void ResumeGame()
    {
        GamePaused = false;
    }
}
