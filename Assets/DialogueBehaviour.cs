using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueBehaviour : MonoBehaviour
{
    string[] dialogues = new string[1];
    string texto_Output;
    int caractere,dialogoIndex;
    float tempo,cd;
    bool TextoAtivo;
    
    string Dialogo(string[] a, int I_dialogo, string dialogo)
    {
        if(tempo < Time.time && a[I_dialogo].Length != caractere -1){
        texto_Output = a[I_dialogo].Substring(0,caractere);
        caractere++;
        tempo = Time.time + cd;
        }
        return dialogo;
    }
    void Start()
    {
        TextoAtivo = true;
        cd = 0.3f;
        dialogues[0] = "Wait for me!!!";
    }

    void Update()
    {
        if(TextoAtivo)
        texto_Output = Dialogo(dialogues,dialogoIndex,texto_Output);
    }
}
