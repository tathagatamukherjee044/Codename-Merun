using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIView : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject pauseMenuPanel;
    [SerializeField] private GameObject deathPanel;
    
    public void Pause()
    {
        pauseMenuPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        pauseMenuPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainScene");
    }

    public void deathScreenOn()
    {
        deathPanel.SetActive(true);
    }
}
