﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class piscandoLabel : MonoBehaviour
{
    [SerializeField] Animator fundo;
    private float tempo;
    
    void Start()
    {
        tempo = 10000000000000000;
    }

    void Update()
    {
        if (Input.anyKeyDown && Time.time > 1.9f)
        {
            fundo.SetBool("carregandoScebe", true);
            
            tempo = Time.time;
            
        }
        if (Time.time >= tempo + 1.3f)

        {
           SceneManager.LoadScene("Act1");
        }
    }
}