using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HighScoreController : MonoBehaviour
{

    [SerializeField]
    private Text scoreText, coinText;


    // Start is called before the first frame update
    void Start()
    {
        SetScoreWithDifficulty();   
    }

    void SetScore(int score,int coinScore)
    {

        scoreText.text = score.ToString();
        coinText.text = coinScore.ToString();

    }


    void SetScoreWithDifficulty()
    {
        if (GamePreferences.GetEasyDifficultyState() == 1)
        {
            SetScore(GamePreferences.GetEasyDifficultyHighScore(), GamePreferences.GetEasyDifficultyCoinScore());

        }

        if (GamePreferences.GetMediumDifficultyState() == 1)
        {
            SetScore(GamePreferences.GetMediumDifficultyHighScore(), GamePreferences.GetMediumDifficultyCoinScore());

        }
        if (GamePreferences.GetHardDifficultyState() == 1)
        {
            SetScore(GamePreferences.GetHardDifficultyHighScore(), GamePreferences.GetHardDifficultyCoinScore());

        }

    }

    public void BackButton()
    {
        SceneManager.LoadScene("Menu");
    }

}
