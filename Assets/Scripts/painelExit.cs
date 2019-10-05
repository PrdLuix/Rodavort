using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class painelExit : MonoBehaviour
{
    public float opacidade = 0;
    public bool podeir;
     Color alou ;
     void Start()
     {
          alou = GetComponent<Image>().color;
     }
    void Update()
    {
        if(podeir){
        GetComponent<Image>().color = new Color(alou.r,alou.b,alou.g,opacidade);
        opacidade += 0.01f;
        print(opacidade);
        }
        if (opacidade >= 1)
        opacidade = 1;
    }
}
