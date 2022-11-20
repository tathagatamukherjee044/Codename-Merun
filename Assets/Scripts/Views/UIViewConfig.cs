using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIViewConfig : MonoBehaviour
{

    public void TrainSizeSelect(int length)
    {
        Debug.Log("clicked");
        Time.timeScale = 1f;
        StateMangerController.trainLength = length;
        SceneManager.LoadScene("MainScene");
    }
}

