using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class MenuBehaviour : MonoBehaviour
{
    [SerializeField]GameObject blinkFade;
    [SerializeField]Text S;
    private GameObject clone;
    private bool ativo;
    private int index,start_p,credits_p,exit_p;
    
    void Start()
    {
      index = 0;
      start_p = 2;
      credits_p = 0;
      exit_p = -2;
      ativo = true;
      clone = Instantiate(blinkFade, S.transform.position + CreateV3(start_p),Quaternion.identity);
    }
    private Vector3 CreateV3(float y)=> new Vector3(0,y);
    
    void Update()
    {
    
      if (Input.GetKeyDown(KeyCode.UpArrow)||Input.GetKeyDown(KeyCode.W))
      {
        index--;   
        Destroy(clone); 
        if (index == -1)
            index = 2;
        ativo = false;
      }
      else if(Input.GetKeyDown(KeyCode.DownArrow)||Input.GetKeyDown(KeyCode.S))
      {
        index++;
        if (index == 3)
            index = 0;
        Destroy(clone);
        ativo = false;
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
          goto case -1;
          case 1:
          clone = Instantiate(blinkFade, S.transform.position + CreateV3(credits_p),Quaternion.identity);
          goto case -1;
          case 2:
         clone = Instantiate(blinkFade, S.transform.position + CreateV3(exit_p),Quaternion.identity);
          goto case -1;
        }
      }
      if (Input.GetKeyDown(KeyCode.Z))
      {   
        switch(index)
      {
          case 0:   
           SceneManager.LoadScene("Act1");
          break;
          case 1:
          print("creditos");
          break;
          case 2:
          Application.Quit();
          break;
      }  
    }
      
    }
}
