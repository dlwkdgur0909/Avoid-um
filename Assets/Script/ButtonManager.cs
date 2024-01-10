using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public static ButtonManager Instance;
    public GameObject howToPlay;
    public GameObject exit;


    void Awake()
    {
        Instance = this;
    }

    public void Title()
    {
        SceneManager.LoadScene(0);
    }

    public void InGame()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1.0f;
    }

    public void HowToPlay()
    {
        howToPlay.SetActive(true);
    }

    public void HowToPlayExit()
    {
        howToPlay.SetActive(false);
    }


}
