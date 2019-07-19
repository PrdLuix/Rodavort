using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class animacaoL : MonoBehaviour
{
     [SerializeField] Image[] letras;
    private float porcentagem,speed;
    private bool inverter;
  
    void Start()
    {
        speed = 0.1f;
        inverter = false;
        porcentagem = 0.5f;   
    }
    void Update()
    {
       Animacao();     
    }
    float Y(float speed , float porcentagem)
    {
        return speed*porcentagem*Time.deltaTime;
    }
    void Animacao()
    {
        if (!inverter)
        {
            porcentagem -= 0.1f;
            if (porcentagem <= -1)
            {
                inverter = true;
            }
            
        }
        else if (inverter)
        {
            porcentagem += 0.1f;
            if (porcentagem >= 1)
            {
                inverter = false;
            }
        }

        for (int i = 0; i < letras.Length; i++)
        {
          letras[i].transform.position += new Vector3(0, Y(speed, porcentagem));
        }      
        if (letras.Length <10)
        {
            transform.position += new Vector3(0, Y(speed, porcentagem));
        }
    }
}
