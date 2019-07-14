using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class MenuBehaviour : MonoBehaviour
{
    [SerializeField]GameObject blinkFade,arabesco,fundo;
    [SerializeField]Text S;
    private Vector3 ajuste;
    private GameObject clone;
    private bool ativo,apertado;
    float tempo;
    private int index,start_p,credits_p,exit_p;

    private Vector3 CreateV3(float y)=> new Vector3(0,y);
    void Start()
    {
      ajuste = new Vector3(0,-0.5f);
      index = 0;
      start_p = 2;
      fundo.SetActive(true);
      credits_p = 0;
      exit_p = -2;
      ativo = true;
      clone = Instantiate(blinkFade, S.transform.position + CreateV3(start_p),Quaternion.identity);
    }
  
    
    void Update()
    {

        if (!apertado)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                index--;
                Destroy(clone);
                if (index == -1)
                    index = 2;
                ativo = false;
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                index++;
                if (index == 3)
                    index = 0;
                Destroy(clone);
                ativo = false;
            }
        }
      if (!ativo)
      {
         switch(index)
          {
          case -1:
          ativo = true;
          break;
          case 0:
          clone = Instantiate(blinkFade, S.transform.position + CreateV3(start_p),Quaternion.identity);
          arabesco.transform.position = CreateV3(start_p)+ ajuste;
          goto case -1;
          case 1:
          clone = Instantiate(blinkFade, S.transform.position + CreateV3(credits_p),Quaternion.identity);
          arabesco.transform.position = CreateV3(credits_p)+ ajuste;
          goto case -1;
          case 2:
          clone = Instantiate(blinkFade, S.transform.position + CreateV3(exit_p),Quaternion.identity);
          arabesco.transform.position = CreateV3(exit_p) + ajuste;
          goto case -1;
        }
      }
      if (Input.GetKeyDown(KeyCode.Z) || apertado)
      {
         if (!apertado) 
         tempo = Time.time;
         apertado = true;
         switch (index)
         {
          case 0:
           if (Time.time >= tempo + 1.3f)
          SceneManager.LoadScene("Act1");
          break;
          case 1:
          SceneManager.LoadScene("Credits");
          break;
          case 2:
          if (Time.time >= tempo + 1.3f)
            Application.Quit();
          break;
         }  
    }
      
    }
}
