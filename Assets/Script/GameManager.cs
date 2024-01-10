using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text curscoreText;
    [SerializeField] private TMP_Text maxScoreText;

    public TMP_Text playerHpText;
    public GameObject scorePanel;
    public Player player;
    public int score;
    private int maxScore;


    void Awake()
    {
        if (!Instance)
        {
            Instance = this;
        }
    }

    void Start()
    {
        maxScore = PlayerPrefs.GetInt("score");
    }

    public void Update()
    {
        Score();
    }

    private void Score()
    {
        //���� ���� �� ���ھ�
        scoreText.text = "Score:" + score.ToString();
        if (player != null)
        {
            playerHpText.text = "Life: " + player.Hp.ToString();
        }

        //���� ������ �ǳ� ���ھ�
        curscoreText.text = "current score: " + score.ToString();
        if (score > maxScore)
        {
            maxScore = score;
            PlayerPrefs.SetInt("score", maxScore);
        }
        maxScoreText.text = "max score: " + maxScore.ToString();
    }

    public void ScorePlus()
    {
        score++;
    }

    public void Die()
    {
        scorePanel.SetActive(true);
    }
}
