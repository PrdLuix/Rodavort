using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    private float xmin,xmax,cameraZ;
    private int scene;
 
    void Start()
    {
        scene = 0;
    }

    void Update()
    {
     Limite();
    }
    void Limite()
    {
    xmin = -28;
    cameraZ= -10;
    xmax = 15;
    
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
    void LimiteCasa()
    {
        xmin = -28;
        cameraZ= -10;
        xmax = 15;

         if (PlayerBehaviour.cameraP.x < xmin)
        {
           transform.position = new Vector3(xmin,transform.position.y,cameraZ);
        }
        else if (PlayerBehaviour.cameraP.x >xmax)
        {
           transform.position = new Vector3(xmax,transform.position.y,cameraZ);
        }
        else
        {
             transform.position =new Vector3(PlayerBehaviour.cameraP.x,PlayerBehaviour.cameraP.y,cameraZ);
        }
    }
    void LimiteCena_1()
    {

    }
    void LimiteCena_2()
    {}
}
