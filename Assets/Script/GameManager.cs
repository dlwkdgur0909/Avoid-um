using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public TMP_Text ScoreText;
    public TMP_Text PlayerHpText;
    public Player player;
    public int score;


    void Awake()
    {
        if (!Instance)
        {
            Instance = this;
        }
    }

    public void Update()
    {
        ScoreText.text = "Score:" + score.ToString();
        if (player != null)
        {
            PlayerHpText.text = "Life: " + player.Hp.ToString();
        }
    }

    public void ScorePlus()
    {
        score++;
    }
}
