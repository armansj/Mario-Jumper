﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableScripts : MonoBehaviour
{

    private void OnEnable()
    {

        Invoke("DestroyCollectable",6f);

        
    }


    

    void DestroyCollectable()
    {

        gameObject.SetActive(false);
    }





}
