using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HISTORY : MonoBehaviour
{
    public bool soltaOmenino;
    [SerializeField] private GameObject personagem,Dormindo, dialogo;
    [SerializeField] private Animator animator;
    float tempo;

    void Start()
    {
        tempo = Time.time + 3.3f;
        personagem.GetComponent<SpriteRenderer>().color = new Color (1,1,1,0);
        personagem.GetComponent<Rigidbody2D>().gravityScale = 0;

    }
    void Update()
    {
        if (Time.time >= tempo)
        {
            animator.SetBool("Acordado",true);
        }      
        else
        {
            animator.SetBool("Acordado",false);
        }

        if(!soltaOmenino)
             personagem.transform.position = new Vector3(-14,-2);
        else { return; }
    }
}
