﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class OptionController : MonoBehaviour
{
    [SerializeField]
    private GameObject easySign,mediumSign,hardSign;




    // Start is called before the first frame update
    void Start()
    {

        SetDifficulty();
    }


    void SetInitialDifficulty(string difficulty)
    {

        switch (difficulty)
        {

            case "easy":
              
                mediumSign.SetActive(false);
                hardSign.SetActive(false);
                break;
            case "medium":
                easySign.SetActive(false);
                hardSign.SetActive(false);
                break;
            case "hard":
                easySign.SetActive(false);
                mediumSign.SetActive(false);
               
                break;




        }

    }

    void SetDifficulty()
    {
        if (GamePreferences.GetEasyDifficultyState() == 1)
        {
            SetInitialDifficulty("easy");
        }
        if (GamePreferences.GetMediumDifficultyState() == 1)
        {
            SetInitialDifficulty("medium");
        }
        if (GamePreferences.GetHardDifficultyState() == 1)
        {
            SetInitialDifficulty("hard");
        }




    }


    public void EasyDifficulty()
    {
        GamePreferences.SetEasyDifficultyState(1);
        GamePreferences.SetMediumDifficultyState(0);
        GamePreferences.SetHardDifficultyState(0);
        easySign.SetActive(true);
        mediumSign.SetActive(false);
        hardSign.SetActive(false);


    }

    public void MediumDifficulty()
    {

        GamePreferences.SetEasyDifficultyState(0);
        GamePreferences.SetMediumDifficultyState(1);
        GamePreferences.SetHardDifficultyState(0);
        easySign.SetActive(false);
        mediumSign.SetActive(true);
        hardSign.SetActive(false);


    }

    public void HardDifficulty()
    {
        GamePreferences.SetEasyDifficultyState(0);
        GamePreferences.SetMediumDifficultyState(0);
        GamePreferences.SetHardDifficultyState(1);
        easySign.SetActive(false);
        mediumSign.SetActive(false);
        hardSign.SetActive(true);

    }




    public void BackOptionButton()
    {
        SceneManager.LoadScene("Menu");


    }
}
