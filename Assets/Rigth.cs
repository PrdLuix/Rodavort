using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rigth : MonoBehaviour
{

    void Update()
    {
        transform.position += new Vector3(1f * Time.deltaTime,0);
    }
}
