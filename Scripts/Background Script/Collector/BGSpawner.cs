using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGSpawner : MonoBehaviour
{

    private GameObject[] background;
    private float lastY;






    // Start is called before the first frame update
    void Start()
    {
        GetBackgroundSetLastY();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void GetBackgroundSetLastY()
    {

        background = GameObject.FindGameObjectsWithTag("Background");
        lastY = background[0].transform.position.y;

        for (int i = 1; i < background.Length; i++)
        {

            if (lastY > background[i].transform.position.y)
            {
                lastY = background[i].transform.position.y;
            }

        }



    }

     void OnTriggerEnter2D(Collider2D target)
    {

        if (target.tag == "Background")
        {
            if (target.transform.position.y == lastY)
            {
                Vector3 temp = target.transform.position;
                float height = ((BoxCollider2D)target).size.y;
                for (int i = 0; i < background.Length; i++)
                {
                    if (!background[i].activeInHierarchy)
                    {
                        temp.y -= height;
                        lastY = temp.y;
                        background[i].transform.position = temp;
                        background[i].SetActive(true);
                    }
                }
            }
        }
    }


}
