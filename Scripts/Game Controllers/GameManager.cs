using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instace;

    [HideInInspector]
    public bool gameStartedFromMainMenu, gameRestartedAfterPlayerDied;

    [HideInInspector]
    public int score, coinScore, lifeScore;


    // Start is called before the first frame update
    void Start()
    {
        InitializeVariables();
    }

    private void Awake()
    {
        MakeSingleton();
    }

    private void OnLevelWasLoaded()
    {
        if (SceneManager.sceneCount==1)
        {
            if (gameRestartedAfterPlayerDied)
            {
                GamePlayController.instance.SetScore(score);
                GamePlayController.instance.SetCoinScore(coinScore);
                GamePlayController.instance.SetLifeScore(lifeScore);

                PlayerScore.scoreCount = score;
                PlayerScore.coinCount = coinScore;
                PlayerScore.lifeCount = lifeScore;

            }
            else if(gameStartedFromMainMenu)
            {
                PlayerScore.scoreCount = 0;
                PlayerScore.coinCount = 0;
                PlayerScore.lifeCount = 2;

                GamePlayController.instance.SetScore(0);
                GamePlayController.instance.SetCoinScore(0);
                GamePlayController.instance.SetLifeScore(2);
            }
        }
    }



    void InitializeVariables()
    {

        if (!PlayerPrefs.HasKey("Game Initialized"))
        {
            GamePreferences.SetEasyDifficultyState(0);
            GamePreferences.SetEasyDifficultyCoinScore(0);
            GamePreferences.SetEasyDifficultyHighScore(0);


            GamePreferences.SetMediumDifficultyState(1);
            GamePreferences.SetMediumDifficultyCoinScore(0);
            GamePreferences.SetMediumDifficultyHighScore(0);

            GamePreferences.SetHardDifficultyState(0);
            GamePreferences.SetHardDifficultyCoinScore(0);
            GamePreferences.SetHardDifficultyHighScore(0);

            GamePreferences.SetMusicState(0);

            PlayerPrefs.SetInt("Game Initialized", 123);


        }


    }



    void MakeSingleton()
    {
        if (instace != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instace = this;
            DontDestroyOnLoad(gameObject);


        }



    }



    public void CheckGameStatus(int score,int coinScore,int lifeScore)
    {
        if (lifeScore < 0)
        {
            if (GamePreferences.GetEasyDifficultyState() == 1)
            {
                int highScore = GamePreferences.GetEasyDifficultyHighScore();
                int coinHighScore = GamePreferences.GetEasyDifficultyCoinScore();
                if (highScore < score)
                {
                    GamePreferences.SetEasyDifficultyHighScore(score);
                }
                if (coinHighScore < coinScore)
                {
                    GamePreferences.SetEasyDifficultyCoinScore(coinScore);
                    
                }

            }

            if (GamePreferences.GetMediumDifficultyState() == 1)
            {
                int highScore = GamePreferences.GetMediumDifficultyHighScore();
                int coinHighScore = GamePreferences.GetMediumDifficultyCoinScore();
                if (highScore < score)
                {
                    GamePreferences.SetMediumDifficultyHighScore(score);
                }
                if (coinHighScore < coinScore)
                {
                    GamePreferences.SetMediumDifficultyCoinScore(coinScore);

                }

            }



            if (GamePreferences.GetHardDifficultyState() == 1)
            {
                int highScore = GamePreferences.GetHardDifficultyHighScore();
                int coinHighScore = GamePreferences.GetHardDifficultyCoinScore();
                if (highScore < score)
                {
                    GamePreferences.SetHardDifficultyHighScore(score);
                }
                if (coinHighScore < coinScore)
                {
                    GamePreferences.SetHardDifficultyCoinScore(coinScore);

                }

            }




            gameStartedFromMainMenu = false;
            gameRestartedAfterPlayerDied = false;
            //gamePlay Controller

            GamePlayController.instance.GameOverShowPanel(score,coinScore);

        }

        else
        {

            this.score = score;
            this.coinScore = coinScore;
            this.lifeScore = lifeScore;

            GamePlayController.instance.SetScore(score);
            GamePlayController.instance.SetCoinScore(coinScore);
            GamePlayController.instance.SetLifeScore(lifeScore);



            gameStartedFromMainMenu = false;


            gameRestartedAfterPlayerDied = true;

            GamePlayController.instance.PlayerDiedRestartGame();
            

        }
    }



}//class