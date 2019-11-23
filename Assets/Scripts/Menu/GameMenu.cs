using UnityEngine;
using UnityEngine.SceneManagement;
using UnityNightPool;

public class GameMenu : MonoBehaviour
{
    public bool isPaused = false;

    public void PauseGame()
    {
        if (isPaused)
        {
            Time.timeScale = 1;
            isPaused = false;
        }
        else
        {
            Time.timeScale = 0;
            isPaused = true;
        }
    }

    public void BackToMainMenu()
    {
        PoolManager.ReturnPool();
        SceneManager.LoadScene(0);
    }
 }