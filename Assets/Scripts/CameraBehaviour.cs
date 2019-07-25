using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraBehaviour : MonoBehaviour
{
    private float xmin,xmax,cameraZ;
    private int scene;
    private Scene currentScene;
    private string sceneName;
    int altura;
 
    void Start()
    {
        
        scene = 0;
        currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
        if(sceneName == "Act2"){
         scene = 1;
         altura = 2;
        }
         if (PlayerBehaviour.cameraP.x < xmin)
        {
           transform.position = new Vector3(xmin,transform.position.y  ,cameraZ);
        }
        else if (PlayerBehaviour.cameraP.x >xmax)
        {
           transform.position = new Vector3(xmax,transform.position.y  ,cameraZ);
        }
        else
        {
             transform.position =new Vector3(PlayerBehaviour.cameraP.x,PlayerBehaviour.cameraP.y ,cameraZ);
        }
       
    }

    void Update()
    {  
     Limite();
     Limitando();
    }
    void Limite()
    {
    cameraZ= -10;

    switch (scene)
        {
         case 0:
         LimiteCasa();
         break;
         case 1:
         LimiteCena_1();
         break;
         case 2:
         LimiteCena_2();
         break;
        }
    }
    void Limitando()
    {
        if (PlayerBehaviour.cameraP.x < xmin)
        {
           transform.position = new Vector3(xmin,transform.position.y  ,cameraZ);
        }
        else if (PlayerBehaviour.cameraP.x >xmax)
        {
           transform.position = new Vector3(xmax,transform.position.y  ,cameraZ);
        }
        else
        {
         transform.position =new Vector3(PlayerBehaviour.cameraP.x,PlayerBehaviour.cameraP.y ,cameraZ);
        }
    }
    void LimiteCasa()
    {
        xmin = -28;
        xmax = 15;
    }
    void LimiteCena_1()
    {      
       xmin = -3;
       xmax = 41;
    }
    void LimiteCena_2()
    {

    }
}
