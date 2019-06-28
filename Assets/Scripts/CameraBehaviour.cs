using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    private float xmin,xmax,cameraZ;
   
    void Start()
    {
        transform.position = PlayerBehaviour.cameraP;
        xmin = -28;
        cameraZ= -10;
        xmax = 15;
    }

    void Update()
    {
         #region LimiteCasa
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
        #endregion
       
    }
}
