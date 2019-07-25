using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HISTORY : MonoBehaviour
{
    [SerializeField] private GameObject personagem,Dormindo;
    [SerializeField] private Animator animator;
    float tempo;

    void Start()
    {
        tempo = Time.time + 3.3f;
        personagem.GetComponent<SpriteRenderer>().color = new Color (1,1,1,0);
        
    }
    void Update()
    {
       // if (GetComponent<DialogoBehaviour>().dialogos.Count == 0)
       // {
        //    Dormindo.GetComponent<SpriteRenderer>().color = new Color (1,1,1,0);
       // }
        if (Time.time >= tempo)
        {
            animator.SetBool("Acordado",true);
        }      
        else
        {
            animator.SetBool("Acordado",false);
        }
        personagem.transform.position = new Vector3(-14,-3);
    }
}
