using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [Header("UI References")]
    public Button drivingGameButton;
    public Button flyingGameButton;
    public Button sumoGameButton;
    public Button exitButton;
    
    [Header("Game Scenes")]
    [SerializeField] private string drivingGameScene = "DrivingGame";
    [SerializeField] private string flyingGameScene = "FlyingGame";
    [SerializeField] private string sumoGameScene = "SumoGame";
    
    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip buttonClickSound;
    public AudioClip backgroundMusic;
    
    void Start()
    {
        // Debug scene names
        Debug.Log($"Driving Game Scene: {drivingGameScene}");
        Debug.Log($"Flying Game Scene: {flyingGameScene}");
        Debug.Log($"Sumo Game Scene: {sumoGameScene}");
        
        // Set up button listeners
        if (drivingGameButton != null)
            drivingGameButton.onClick.AddListener(LoadDrivingGame);
            
        if (flyingGameButton != null)
            flyingGameButton.onClick.AddListener(LoadFlyingGame);
            
        if (sumoGameButton != null)
            sumoGameButton.onClick.AddListener(LoadSumoGame);
            
        if (exitButton != null)
            exitButton.onClick.AddListener(ExitGame);
        
        // Play background music if available
        if (audioSource != null && backgroundMusic != null)
        {
            audioSource.clip = backgroundMusic;
            audioSource.loop = true;
            audioSource.Play();
        }
    }
    
    public void LoadDrivingGame()
    {
        PlayButtonSound();
        LoadScene(drivingGameScene);
    }
    
    public void LoadFlyingGame()
    {
        PlayButtonSound();
        LoadScene(flyingGameScene);
    }
    
    public void LoadSumoGame()
    {
        PlayButtonSound();
        LoadScene(sumoGameScene);
    }
    
    public void ExitGame()
    {
        PlayButtonSound();
        
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
    
    private void LoadScene(string sceneName)
    {
        if (!string.IsNullOrEmpty(sceneName))
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogWarning($"Scene name '{sceneName}' is not set!");
        }
    }
    
    private void PlayButtonSound()
    {
        if (audioSource != null && buttonClickSound != null)
        {
            audioSource.PlayOneShot(buttonClickSound);
        }
    }
    
    // Method to handle keyboard input
    void Update()
    {
        // Allow ESC key to exit the game from main menu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ExitGame();
        }
    }
}
