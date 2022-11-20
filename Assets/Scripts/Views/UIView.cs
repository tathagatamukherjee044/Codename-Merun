using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIView : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject pauseMenuPanel;
    [SerializeField] private GameObject deathPanel;
    public int metres = 15;
    private int coins = 0;
    public float DelayAmount = 0.1f; // Second count
    public GameObject metre;
    public GameObject coin;
    [SerializeField] private TMP_Text metreText;
    [SerializeField] private TMP_Text coinText;
    private float timer;

    private void Start()
    {
        metreText = metre.GetComponent<TMP_Text>();
        metreText.text = "" + metres;
        coinText = coin.GetComponent<TMP_Text>();
        coinText.text = "" + coins;
        //Time.timeScale = 0;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= DelayAmount)
        {
            timer = 0f;
            metres++; // For every DelayAmount or "second" it will add one to the GoldValue
            metreText.text = "" + metres;
            //PowerText.text = "Power: " + Power;
        }
    }

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


    public void Setting()
    {
        SceneManager.LoadScene("ConfigScene");
    }

    public void pointsIncrement()
    {
        coins++;
        coinText.text = "" + coins;
    }
}
