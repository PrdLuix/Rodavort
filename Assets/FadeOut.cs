using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour
{
    [SerializeField] GameObject dialogo,personagem,dormindo,Event;
    [SerializeField] Image[] coisas;
   
    private float opacidade = 1f;
    private float velocidade;
    void Start()
    {
        for (int i = 0; i < coisas.Length; i++)
        {
            coisas[i].enabled = false;
        }
        velocidade = 0.01f;
    }
    void Update()
    {
        if (opacidade >= 0)
            GetComponent<Image>().color = new Color(0, 0, 0, opacidade);
        opacidade -= velocidade;
        if (opacidade <= 0)
            opacidade = 0;
        if (dialogo.GetComponent<DialogoBehaviour>().podeir)
        {
            velocidade = -0.006f;
            dialogo.GetComponent<DialogoBehaviour>().podeir = false;
        }
        if (opacidade > 1)
        {

            for (int i = 0; i < coisas.Length; i++)
            {
                coisas[i].enabled = true;
            }
            dormindo.SetActive(false);
            personagem.GetComponent<Rigidbody2D>().gravityScale = 1;
            personagem.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1,1);
            Event.GetComponent<HISTORY>().soltaOmenino = true;
            velocidade = 0.009f;
        }
    }
}

