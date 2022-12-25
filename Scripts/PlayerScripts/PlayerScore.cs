using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{

    [SerializeField]
    private AudioClip coinClip;
    [SerializeField]
    private AudioClip lifeClip;


    private CameraScript cameraScript;
    private bool countScore;
    private Vector3 previousPosition;

    public static int scoreCount;
    public static int lifeCount;
    public static int coinCount;

    private void Awake()
    {
        cameraScript = Camera.main.GetComponent<CameraScript>();


    }


    // Start is called before the first frame update
    void Start()
    {
        previousPosition = transform.position;
        countScore = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        CountScore();
    }

    void CountScore()
    {
        if (countScore)
        {
            if (transform.position.y < previousPosition.y)
            {
                scoreCount++;
            }
            previousPosition = transform.position;
            GamePlayController.instance.SetScore(scoreCount);
        }
    }


     void OnTriggerEnter2D(Collider2D target)
    {

        if (target.tag == "Coin")
        {
            coinCount++;
            scoreCount += 200;
            GamePlayController.instance.SetScore(scoreCount);
            GamePlayController.instance.SetCoinScore(coinCount);
            AudioSource.PlayClipAtPoint(coinClip,transform.position);
            target.gameObject.SetActive(false);
        }

        if (target.tag == "Life")
        {
            lifeCount++;
            scoreCount += 300;
            GamePlayController.instance.SetScore(scoreCount);
            GamePlayController.instance.SetLifeScore(lifeCount);
            AudioSource.PlayClipAtPoint(lifeClip, transform.position);
            target.gameObject.SetActive(false);

        }

        if (target.tag == "Bounds" || target.tag == "Deadly")
        {
            cameraScript.moveCamera = false;
            countScore = false;


            transform.position = new Vector3(500, 500, 0);
            lifeCount--;

            GameManager.instace.CheckGameStatus(scoreCount, coinCount, lifeCount);
        }






    }

  



}



