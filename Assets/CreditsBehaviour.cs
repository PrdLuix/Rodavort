using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditsBehaviour : MonoBehaviour
{
    [SerializeField] Text text;
    void Update()
    {
        text.transform.position += new Vector3(0, 0.01f);
    }
}
