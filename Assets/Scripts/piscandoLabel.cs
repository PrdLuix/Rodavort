﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class piscandoLabel : MonoBehaviour
{
    [SerializeField] Animator fundo;
    private float tempo;
    private bool tapado;
    
    void Start()
    {
        tempo = 10000000000000000;
    }

    void Update()
    {
        if(transform.tag != "escudo" && transform.tag != "fundoIntrodução")
        { 
           if (Input.anyKeyDown && Time.time > 1.0f)
           {
              fundo.SetBool("carregandoScebe", true);
                tempo = Time.time;
            
           }
           if (Time.time >= tempo + 1.3f)

           {
             SceneManager.LoadScene("Menu");
           }
        }
         if(Input.GetKeyDown(KeyCode.Z) && transform.tag == "escudo")
        {
          
        }
    }
}
