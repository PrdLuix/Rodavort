﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainBehaviour : MonoBehaviour
{
    float speed;
    void Update()
    {
        speed = 10 *Time.deltaTime;
        transform.position += new Vector3(speed,-speed);
    }
}
