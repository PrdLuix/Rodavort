using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class MenuBehaviour : MonoBehaviour
{
    [SerializeField]GameObject fundo;
    [SerializeField]Image[] arabesco;
    [SerializeField]Text S;
    private Vector3 ajuste;
    [SerializeField] private Image blinkFade;

    private bool ativo,apertado;
    float tempo;
    private int index,start_p,credits_p;

    private Vector3 CreateV3(float y)=> new Vector3(0,y);
    void Start()
    {

      ajuste = new Vector3(0,-0.5f);
      index = 0;
      start_p = 2; 
      credits_p = 0; 
      fundo.SetActive(true);
      ativo = true;
   
    }
    void Update()
    {
    Desativar();
    arabesco[index].enabled = true;
        if (!apertado)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                index--;
                if (index == -1)
                    index = 2;
                    
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                index++;
                if (index == 3)
                    index = 0;  
            }
            
        }    
        switch(index)
        {
            case 0:
            blinkFade.rectTransform.position = CreateV3(start_p);
            break;
            case 1:
            blinkFade.rectTransform.position = CreateV3(credits_p);
            break;
            case 2:
            blinkFade.rectTransform.position = CreateV3(-2);
            break;
            
        }
      if (Input.GetKeyDown(KeyCode.Z) || apertado)
      {
         if (!apertado) 
         tempo = Time.time;
         apertado = true;
         switch (index)
         {
          case 0:
             SceneManager.LoadScene("Introduction");
          break;
          case 1:
             SceneManager.LoadScene("Credits");
          break;
          case 2:
            Application.Quit();
          break;
         }  
    }
    void Desativar()
    {
      for (int i = 0; i < arabesco.Length; i++)
      {
          arabesco[i].enabled = false;
      }
    }     
  }
}
