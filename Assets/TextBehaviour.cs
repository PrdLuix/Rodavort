using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class TextBehaviour : MonoBehaviour
{
    [SerializeField] Text falas;
    [SerializeField] GameObject fundo;
    string[] textos = new string[4];
    float tempo,speed;
    public float opacidade;
    bool inverso,tempado;
    public int index;
    void Start()
    {
        fundo.SetActive(true);
        Textos();
        Variaveis();
    }
    
    void Update()
    {
        falas.text = textos[index];
        falas.color = new Color(falas.color.r, falas.color.g, falas.color.b, opacidade);
        Transicao();

    }
    void Textos()
    {
        textos[0] = "Once upon a time, on a rainy day between          1095 - 1492"; ;
        textos[1] = "There was a man who, after repenting ...";
        textos[2] = "Sought his forgiveness before God. ";
        textos[3] = "Today it's the day, the day he shall be forgiven";
    }
    void Transicao()
    {
        if (index < 3 && Input.GetKeyDown(KeyCode.Z))
        {
            speed = 3;
        }
        
        if (!inverso)
            opacidade += speed * Time.deltaTime;
        else 
            opacidade += -speed * Time.deltaTime;
        if (opacidade >= 1 && !inverso)
        {
            inverso = true;
          
        }
        if (opacidade <= 0.4f && index == 3 && inverso)
            fundo.GetComponent<Animator>().SetBool("carregandoScebe", true);
        if (opacidade <= 0 && inverso)
        {
            speed = 0.4f;
            if (index >= 3)
            {
                SceneManager.LoadScene("Act1");               
            }
            else 
                index++;
            inverso = false;
            
        }
    }
    void Variaveis()
    {
        tempo = 100000000000000;
        index = 0;
        opacidade = 0;
        speed = 0.4f;
    }
}
