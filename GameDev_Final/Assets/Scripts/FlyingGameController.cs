using UnityEngine;
using UnityEngine.SceneManagement;

public class FlyingGameController : MonoBehaviour
{
    [Header("Game Settings")]
    public float gameTime = 60f;
    public int score = 0;
    
    [Header("UI References")]
    public UnityEngine.UI.Text scoreText;
    public UnityEngine.UI.Text timeText;
    public GameObject gameOverPanel;
    
    private float currentTime;
    private bool gameActive = true;
    
    void Start()
    {
        currentTime = gameTime;
        UpdateUI();
    }
    
    void Update()
    {
        if (gameActive)
        {
            currentTime -= Time.deltaTime;
            UpdateUI();
            
            if (currentTime <= 0)
            {
                EndGame();
            }
        }
        
        // ESC key to pause
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }
    
    public void AddScore(int points)
    {
        score += points;
        UpdateUI();
    }
    
    private void UpdateUI()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + score;
            
        if (timeText != null)
            timeText.text = "Time: " + Mathf.Ceil(currentTime);
    }
    
    private void EndGame()
    {
        gameActive = false;
        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);
    }
    
    public void TogglePause()
    {
        Time.timeScale = Time.timeScale == 0 ? 1 : 0;
    }
    
    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    public void BackToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
}
