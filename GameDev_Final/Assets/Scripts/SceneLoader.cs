using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneLoader : MonoBehaviour
{
    [Header("Loading Settings")]
    public float minimumLoadTime = 1f;
    public GameObject loadingScreen;
    public UnityEngine.UI.Slider progressBar;
    public UnityEngine.UI.Text loadingText;
    
    public static SceneLoader Instance { get; private set; }
    
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadSceneAsync(sceneName));
    }
    
    private IEnumerator LoadSceneAsync(string sceneName)
    {
        // Show loading screen
        if (loadingScreen != null)
            loadingScreen.SetActive(true);
        
        float startTime = Time.time;
        
        // Start loading the scene
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
        asyncLoad.allowSceneActivation = false;
        
        // Wait for minimum load time and update progress
        while (!asyncLoad.isDone)
        {
            float progress = Mathf.Clamp01(asyncLoad.progress / 0.9f);
            
            if (progressBar != null)
                progressBar.value = progress;
                
            if (loadingText != null)
                loadingText.text = $"Loading... {(progress * 100):F0}%";
            
            // Wait for minimum load time
            if (Time.time - startTime >= minimumLoadTime && asyncLoad.progress >= 0.9f)
            {
                asyncLoad.allowSceneActivation = true;
            }
            
            yield return null;
        }
        
        // Hide loading screen
        if (loadingScreen != null)
            loadingScreen.SetActive(false);
    }
    
    public void LoadMainMenu()
    {
        LoadScene("MainMenu");
    }
    
    public void ReloadCurrentScene()
    {
        LoadScene(SceneManager.GetActiveScene().name);
    }
}
