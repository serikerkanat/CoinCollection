using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerLife : MonoBehaviour
{
    public int lives = 3; 
    public float fallThreshold = -10f; 
    public TextMeshProUGUI livesText; 
    public TextMeshProUGUI timerText; 
    public GameObject gameOverScreen;
    public Transform respawnPoint; 

    public float levelTime = 120f; 

    private bool isGameOver = false;
    private bool isRespawning = false; 

    public AudioSource soundEffectsSource; 
    public AudioClip gameOverSound; 

    private void Start()
    {
        UpdateLivesUI();
        UpdateTimerUI();
        gameOverScreen.SetActive(false); 
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        if (transform.position.y < fallThreshold && !isRespawning && !isGameOver)
        {
            LoseLife();
        }

        if (!isGameOver)
        {
            levelTime -= Time.deltaTime;
            UpdateTimerUI();

            if (levelTime <= 0)
            {
                GameOver();
            }
        }
    }

    void LoseLife()
    {
        if (isRespawning || isGameOver) return;

        lives--;
        UpdateLivesUI();

        if (lives <= 0)
        {
            GameOver();
        }
        else
        {
            StartCoroutine(RespawnDelay());
        }
    }

    System.Collections.IEnumerator RespawnDelay()
    {
        isRespawning = true;

        yield return new WaitForSeconds(1f); 

        if (respawnPoint != null)
        {
            transform.position = respawnPoint.position;
        }
        else
        {
            Debug.LogWarning("Respawn Point");
            transform.position = new Vector3(0, 2, 0);
        }

        yield return new WaitForSeconds(1f); 

        isRespawning = false;
    }

    void GameOver()
    {
        isGameOver = true;
        gameOverScreen.SetActive(true); 
        Debug.Log("Game Over!");

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        
        if (soundEffectsSource != null && gameOverSound != null)
        {
            soundEffectsSource.PlayOneShot(gameOverSound); 
        }

        Invoke("LoadMenuScene", 3f); 
    }

    void LoadMenuScene()
    {
        SceneManager.LoadScene("menu"); 
    }

    void UpdateLivesUI()
    {
        if (livesText != null)
        {
            livesText.text = "Lives: " + lives;
        }
    }

    void UpdateTimerUI()
    {
        if (timerText != null)
        {
            int minutes = Mathf.FloorToInt(levelTime / 60);
            int seconds = Mathf.FloorToInt(levelTime % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
}
