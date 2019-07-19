using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogoBehaviour : MonoBehaviour
{
    [SerializeField] private Queue<string> dialogos;
    [SerializeField] private Dialogos falas;
    [SerializeField] private Animator textAnim,falaAnim,nomeAnim;
    [SerializeField] private Image TextBox;
    [SerializeField] private Text nome, sentença;
    [SerializeField] private float speed;
    bool execute;

    void Start()
    {
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
            textAnim.SetBool("iniciarDialogo", false);
            nomeAnim.SetBool("Nome", false);
            falaAnim.SetBool("Dialogo", false);
            TextBox.enabled = false;
            nome.enabled = false;
            sentença.enabled = false;
            return;
        }
        string todasAsFalas = dialogos.Dequeue();
        StopAllCoroutines();
        StartCoroutine(DialogoFinal(todasAsFalas));
    }
    IEnumerator NewDialogo()
    {
        //muda o wairForSeconds para ajustar o tempo de inicio
        yield return new WaitForSeconds(3);
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
        foreach (char letras in todasAsFalas.ToCharArray())
        {
            sentença.text += letras;
            yield return null;
        }

    }
}
