﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
   
    void Start()
    {
        transform.position = PlayerBehaviour.cameraP;
    }

    void Update()
    {
        transform.position = PlayerBehaviour.cameraP;
    }
}
