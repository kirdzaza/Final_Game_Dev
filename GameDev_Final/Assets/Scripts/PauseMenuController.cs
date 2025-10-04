using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuController : MonoBehaviour
{
    [Header("UI References")]
    public GameObject pauseMenuPanel;
    public Button resumeButton;
    public Button restartButton;
    public Button backToMainMenuButton;
    
    [Header("Game Objects to Hide")]
    public GameObject[] gameObjectsToHide; // Assign all game objects you want to hide
    
    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip buttonClickSound;
    
    private bool isPaused = false;
    private bool[] originalObjectStates; // Store original active states
    
    void Start()
    {
        // Set up button listeners
        if (resumeButton != null)
            resumeButton.onClick.AddListener(ResumeGame);
            
        if (restartButton != null)
            restartButton.onClick.AddListener(RestartGame);
            
        if (backToMainMenuButton != null)
            backToMainMenuButton.onClick.AddListener(BackToMainMenu);
        
        // Initially hide the pause menu
        if (pauseMenuPanel != null)
            pauseMenuPanel.SetActive(false);
            
        // Store original states of game objects
        if (gameObjectsToHide != null && gameObjectsToHide.Length > 0)
        {
            originalObjectStates = new bool[gameObjectsToHide.Length];
            for (int i = 0; i < gameObjectsToHide.Length; i++)
            {
                if (gameObjectsToHide[i] != null)
                    originalObjectStates[i] = gameObjectsToHide[i].activeInHierarchy;
            }
        }
    }
    
    void Update()
    {
        // Toggle pause with ESC key
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }
    
    public void TogglePause()
    {
        if (isPaused)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }
    
    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f;
        
        // Hide all game objects
        if (gameObjectsToHide != null)
        {
            for (int i = 0; i < gameObjectsToHide.Length; i++)
            {
                if (gameObjectsToHide[i] != null)
                    gameObjectsToHide[i].SetActive(false);
            }
        }
        
        if (pauseMenuPanel != null)
            pauseMenuPanel.SetActive(true);
    }
    
    public void ResumeGame()
    {
        PlayButtonSound();
        
        isPaused = false;
        Time.timeScale = 1f;
        
        // Show all game objects back
        if (gameObjectsToHide != null && originalObjectStates != null)
        {
            for (int i = 0; i < gameObjectsToHide.Length; i++)
            {
                if (gameObjectsToHide[i] != null && i < originalObjectStates.Length)
                    gameObjectsToHide[i].SetActive(originalObjectStates[i]);
            }
        }
        
        if (pauseMenuPanel != null)
            pauseMenuPanel.SetActive(false);
    }
    
    public void RestartGame()
    {
        PlayButtonSound();
        
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    public void BackToMainMenu()
    {
        PlayButtonSound();
        
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
    
    private void PlayButtonSound()
    {
        if (audioSource != null && buttonClickSound != null)
        {
            audioSource.PlayOneShot(buttonClickSound);
        }
    }
}
