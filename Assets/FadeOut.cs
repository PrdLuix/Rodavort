using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour
{
    private float opacidade = 1f;
    private float velocidade = 0.01f;
    void Update()
    {
        if(opacidade >= 0)
            GetComponent<Image>().color = new Color(0,0,0,opacidade);
        opacidade -= velocidade;
        if(opacidade < 0)
            return;
    }
}
