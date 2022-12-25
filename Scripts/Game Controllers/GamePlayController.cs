using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GamePlayController : MonoBehaviour
{


    [SerializeField]
    private Text scoreText,coinText,lifeText,gameOverScoreText,gameOverCoinText;

    [SerializeField]
    private GameObject pausePanel,gameOverPanel;

    public static GamePlayController instance;

    [SerializeField]
    private GameObject readyButton;


    private void Awake()
    {
        MakeInstance();
    }


     void Start()
    {
        Time.timeScale = 0;
    }



    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }


    }



    public void GameOverShowPanel(int finalScore,int finalCoinScore)
    {

        gameOverPanel.SetActive(true);
        gameOverScoreText.text = finalScore.ToString();
        gameOverCoinText.text = finalCoinScore.ToString();
        StartCoroutine(GameOverLoadMainMenu());

    }




    IEnumerator GameOverLoadMainMenu()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Menu");
    }


   

    public void PlayerDiedRestartGame()
    {
        StartCoroutine(PlayerDiedRestart());
    }

    IEnumerator PlayerDiedRestart()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("GamePlay");
    }


    public void SetScore(int score)
    {

        scoreText.text = "x" + score;
    }

    public void SetCoinScore(int coinScore)
    {
        coinText.text = "x" + coinScore;
    }


    public void SetLifeScore(int lifeScore)
    {
        lifeText.text = "x" + lifeScore;

    }

    public void PauseTheGame()
    {
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pausePanel.SetActive(false);

    }

    public void QuitGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");

    }


    public void StartGame()
    {
        Time.timeScale = 1;
        readyButton.SetActive(false);
    }
     





}
