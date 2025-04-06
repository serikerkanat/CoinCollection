using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public AudioSource backgroundMusic; 
    public AudioClip gameMusic; 

    public void StartGame()
    {
        Debug.Log("Start Game Clicked!");

        
        if (backgroundMusic != null && gameMusic != null)
        {
            backgroundMusic.clip = gameMusic; 
            backgroundMusic.Play(); 
        }

        SceneManager.LoadScene("SampleScene"); 
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game Clicked!");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; 
#else
        Application.Quit();
#endif
    }
}
