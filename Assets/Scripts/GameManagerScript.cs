using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    // Multipliers for player stats
    public int playerHealth = 0; //Health
    public int PlayerSpeed = 0; //Move Speed
    public int PlayerHaste = 0; //Attack Speed
    public int PlayerMight = 0; //Damage
    public int PlayerJumps = 0; //Double Jump Count
    public string currentLevelName = "";

    private void Awake()
    {
        // Singleton pattern to keep one instance of GameManager
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Persist between scenes
        }
        else
        {
            Destroy(gameObject); // Destroy duplicates
        }
    }

    // Call this to load the Main Menu scene
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    // Call this when the player dies to load Game Over scene
    public void LoadGameOver()
    {
        SceneManager.LoadScene("Game Over");
    }

    // Optional: Call to load a specific level (useful for expansion)
    public void LoadLevel(string levelName)
    {
        currentLevelName = levelName;
        SceneManager.LoadScene(levelName);
    }

    // Reset any game state if needed
    public void ResetGameData()
    {
        playerHealth = 0;
        currentLevelName = "";
    }
}