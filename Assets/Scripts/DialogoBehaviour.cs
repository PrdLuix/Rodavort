using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogoBehaviour : MonoBehaviour
{
    [SerializeField] public Queue<string> dialogos;
    [SerializeField] private Dialogos falas;
    [SerializeField] private Animator textAnim,falaAnim,nomeAnim;
    [SerializeField] private Image TextBox;
    [SerializeField] private Image[] Texto;
    [SerializeField] private Text nome, sentença;
    [SerializeField] private float speed;
    public int counta;
    private float tempo;
    bool execute;
    public bool podeir;

    void Start()
    {
        tempo = Time.time + 3;
        counta = 0;
        dialogos = new Queue<string>();
        execute = true;
        nome.enabled = false;
        sentença.enabled = false;
        sentença.text = "";
        nome.text = "";
    }
    void Update()
    {
        if (execute)
        {
            StartCoroutine("NewDialogo");
            execute = false;
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            NextFrase();
        }

        switch (counta)
        {
            case 2:
            Texto[2].enabled = true;
            Texto[0].enabled = true;
            nome.text = "SERVANT:";
            break;
            case 5:
            Texto[2].enabled = false;
            Texto[1].enabled = true;
            nome.text = "NOJIR:";
            counta++;
            break;
        }
          
        

    }
    private void StartDialogo(Dialogos dialogo)
    {
        nome.text = dialogo.nomePersonagem;
        dialogos.Clear();
        foreach (string frase in dialogo.Falas)
        {
            dialogos.Enqueue(frase);
        }

    }
    private void NextFrase()
    {
        if(dialogos.Count == 0)
        {
             Texto[1].enabled = false;
            Texto[0].enabled = false;
            
        }
       if(dialogos.Count == 0 && Time.time >= tempo)
        {
            textAnim.SetBool("iniciarDialogo", false);
            nomeAnim.SetBool("Nome", false);
            falaAnim.SetBool("Dialogo", false);
            TextBox.enabled = false;
            nome.enabled = false;
            sentença.enabled = false;
            podeir = true;
            tempo = 10000000000000000;
            return;
        }
        string todasAsFalas = dialogos.Dequeue();
        StopAllCoroutines();
        StartCoroutine(DialogoFinal(todasAsFalas));
    }
    IEnumerator NewDialogo()
    {
        //muda o wairForSeconds para ajustar o tempo de inicio
        yield return new WaitForSeconds(2);
        textAnim.SetBool("iniciarDialogo", true);
        TextBox.enabled = true;
        nomeAnim.SetBool("Nome", true);
        nome.enabled = true;
        falaAnim.SetBool("Dialogo", true);
        sentença.enabled = true;
        StartDialogo(falas);
        NextFrase();
    }
    IEnumerator DialogoFinal(string todasAsFalas)
    {
        sentença.text = "";
        counta++;
        foreach (char letras in todasAsFalas.ToCharArray())
        {
            sentença.text += letras;
            yield return null;
        }     
    }
}
