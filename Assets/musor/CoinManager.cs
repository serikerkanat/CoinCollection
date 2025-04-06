using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance;
    public int totalCoins = 10; 
    private int collectedCoins = 0;
    public Text coinText;
    public GameObject winText; 

    public AudioSource backgroundMusic; 
    public string nextSceneName = "menu"; 

    private void Awake()
    {
        instance = this;
        UpdateUI();
        winText.SetActive(false); 
    }

    public void CollectCoin()
    {
        collectedCoins++;
        UpdateUI();

        if (collectedCoins >= totalCoins)
        {
            WinGame();
        }
    }

    void WinGame()
    {
        winText.SetActive(true); 
        Debug.Log("YOU WIN!");
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        
        if (backgroundMusic != null)
        {
            backgroundMusic.Stop();
        }

        
        Invoke("LoadNextScene", 3f);
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }

    private void UpdateUI()
    {
        coinText.text = $"{collectedCoins}/{totalCoins}";
    }
}
