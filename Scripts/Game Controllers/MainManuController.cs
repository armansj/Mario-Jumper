using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainManuController : MonoBehaviour
{


    [SerializeField]
    private Button musicButton;

    [SerializeField]
    private Sprite[] musicIcons;


    // Start is called before the first frame update
    void Start()
    {
        CheckPlayMusic();
    }

    void CheckPlayMusic()
    {
        if (GamePreferences.GetMusicState() == 1)
        {
            MusicController.instance.PlayMusic(true);
            musicButton.image.sprite = musicIcons[1];
        }
        else
        {
            MusicController.instance.PlayMusic(false);
            musicButton.image.sprite = musicIcons[0];

        }
    }


    public void StartGame()
    {
        
        SceneManager.LoadScene("GamePlay");
        GameManager.instace.gameStartedFromMainMenu = true;

    }

    public void HighScoreManu()
    {
        SceneManager.LoadScene("HighScoreScene");

    }

    public void OptionScoreManu()
    {
        SceneManager.LoadScene("OptionsMenu");

    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void MusicButton()
    {

        if (GamePreferences.GetMusicState() == 0)
        {
            GamePreferences.SetMusicState(1);
            MusicController.instance.PlayMusic(true);
            musicButton.image.sprite = musicIcons[1];
        }
        else if(GamePreferences.GetMusicState() == 1)
        {
            GamePreferences.SetMusicState(0);
            MusicController.instance.PlayMusic(false);
            musicButton.image.sprite = musicIcons[0];
        }
    }



    private void Awake()
    {

        int i = 1;

        while (i < 10)
        {
            print("arman");
            i++;
        }





        do
        {
            Console.WriteLine("i = {0}", i);
            i++;

        } while (i < 10);




    }



}//class
