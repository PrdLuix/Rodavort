﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{

    [SerializeField] private GameObject[] Escudos = new GameObject[3];
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject mouse,Ecostasv;
    private GameObject clone,Ecostas;

    public static Vector3 cameraP; 
    private float direcX, speed,posicaoR;
    private int shield,armadura;
    private Vector2 Mouse;
    bool Eativado ,EAtivo,Einverso ,EcostasAtivo;
    
    void Vida()
    {
        //primeiro escudo adquirido
        /*
        if (shield == 0 && armadura == 0)
        {
            armadura++;
            Ecostas = Instantiate(Ecostasv);
            EcostasAtivo = true;
        }
        if (armadura == 0 && EcostasAtivo)
        {
            Destroy(this.Ecostas);
            EcostasAtivo = false;
        }*/
    }

    void movimento()
    {

        if (!Eativado)
        {
            direcX = Input.GetAxis("Horizontal");
            transform.Translate(Vector3.right * Time.deltaTime * direcX * speed);
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Eativado = true;
            animator.SetBool("Eativado", true);
        } 
        if (Eativado)
        {
            direcX = 0;
            {
            if (!EAtivo)
             
                clone = Instantiate(Escudos[shield], transform.position , Quaternion.identity);
                EAtivo = true;
            }

           
            #region animacaoEscudoEsquerdo
            //ESuperiorEsquerdo
            if (Mouse.y >= 1.5f && Mouse.x <= -1.5)
            {
                if (!Einverso)
                {
                    clone.transform.Rotate(0, -180, 0, Space.World);
                    Einverso = true;
                }
                clone.transform.position = transform.position + new Vector3(0.3f, 0.7f);

                switch (posicaoR)
                {
                    case 45:
                        break;
                    case 0:
                        clone.transform.Rotate(0, 0, 45);
                        break;
                    case 90:
                        clone.transform.Rotate(0, 0, -45);
                        break;
                }
                posicaoR = 45;

                animator.SetBool("EcimaEsquerda", false);
                animator.SetBool("EsuperiorDireito", false);
                animator.SetBool("EmeioDireito", false);
                animator.SetBool("Ecima", false);
                animator.SetBool("EmeioEsquerda", false);
                animator.SetBool("EsuperiorEsquerda", true);
            }
            //EMeioEsquerda
            if (Mouse.x <= 0f && Mouse.y <= 1.4f)
            {
                if (!Einverso)
                {
                    clone.transform.Rotate(0, -180, 0, Space.World);
                    Einverso = true;
                }
                clone.transform.position = transform.position + new Vector3(0f, 0.4f);

                switch (posicaoR)
                {
                    case 0:
                        break;
                    case 45:
                        clone.transform.Rotate(0, 0, -45);
                        break;

                    case 90:
                        clone.transform.Rotate(0, 0, -90);
                        break;
                }
                posicaoR = 0;
                animator.SetBool("EcimaEsquerda", false);
                animator.SetBool("EsuperiorDireito", false);
                animator.SetBool("EmeioDireito", false);
                animator.SetBool("Ecima", false);
                animator.SetBool("EsuperiorEsquerda", false);
                animator.SetBool("EmeioEsquerda", true);
                
            }
            //ECimaEsquerda
            if (Mouse.y >= 1.4f && Mouse.x <= 0f && Mouse.x >= -1.5f)
            {
                if (!Einverso)
                {           
                        clone.transform.Rotate(0, -180, 0,Space.World);        
                    Einverso = true;
                }
                clone.transform.position = transform.position + new Vector3(0f, 0.7f);
                switch (posicaoR)
                {
                    case 45:
                        clone.transform.Rotate(0, 0, 45);
                        break;
                    case 0:
                        clone.transform.Rotate(0, 0, 90);
                        break;
                    case 90:
                        break;
                }
                posicaoR = 90;
                animator.SetBool("EsuperiorDireito", false);
                animator.SetBool("EmeioDireito", false);
                animator.SetBool("Ecima", false);
                animator.SetBool("EmeioEsquerda", false);
                animator.SetBool("EsuperiorEsquerda", false);
                animator.SetBool("EcimaEsquerda", true);

            }
            #endregion
            #region animacaoEscudoDireito
            //ECimaDireita           
            if (Mouse.y >= 1.4f && Mouse.x > 0f && Mouse.x <=1.5f)
             {
                //instancia o escudo
                if (Einverso)
                {
                   
                    clone.transform.Rotate(0, 180, 0, Space.World);
                    Einverso = false;

                }
                clone.transform.position = transform.position + new Vector3(0f,0.7f);                
                        switch (posicaoR)
                        {
                            case 45:
                                clone.transform.Rotate(0, 0, 45);
                                break;
                            case 0:
                                clone.transform.Rotate(0, 0, 90);
                                break;
                            case 90:
                                break;
                        }
                posicaoR = 90;        
                animator.SetBool("EcimaEsquerda", false);
                animator.SetBool("EsuperiorDireito", false);
                animator.SetBool("EmeioDireito", false);
                animator.SetBool("EmeioEsquerda", false);
                animator.SetBool("EsuperiorEsquerda", false);
                animator.SetBool("Ecima", true);
               
             }
            //ESuperiorDireito
            if (Mouse.y >=1.5f && Mouse.x >=1.5)
             {
                if (Einverso)
                {

                    clone.transform.Rotate(0,180, 0, Space.World);
                    Einverso = false;

                }
                clone.transform.position = transform.position + new Vector3(-0.3f, 0.7f);               
                    switch (posicaoR)
                    {
                        case 45:
                            break;
                        case 0:
                            clone.transform.Rotate(0, 0,  45);                  
                            break;                     
                        case 90:
                            clone.transform.Rotate(0, 0, -45);
                            break;
                    }
                    posicaoR = 45;
                
                animator.SetBool("EcimaEsquerda", false);
                animator.SetBool("EmeioDireito", false);
                animator.SetBool("Ecima", false);
                animator.SetBool("EmeioEsquerda", false);
                animator.SetBool("EsuperiorEsquerda", false);
                animator.SetBool("EsuperiorDireito", true);
             }
            //EMeioDireito   
            if (Mouse.x > 0f && Mouse.y <=1.4f )
             {
                if (Einverso)
                {
                    clone.transform.Rotate(0, 180, 0, Space.World);
                    Einverso = false;
                }
                clone.transform.position = transform.position + new Vector3(0f, 0.4f);
               
                    switch(posicaoR)
                        {
                            case 0:                               
                        break;
                            case 45:
                                clone.transform.Rotate(0, 0, -45);
                        break;
                   
                            case 90:
                            clone.transform.Rotate(0, 0, -90);
                        break;
                    }
                    posicaoR = 0;
                
                animator.SetBool("EcimaEsquerda", false);
                animator.SetBool("EsuperiorDireito", false);
                animator.SetBool("Ecima", false);
                animator.SetBool("EmeioEsquerda", false);
                animator.SetBool("EsuperiorEsquerda", false);
                animator.SetBool("EmeioDireito", true);
             }
            #endregion
            //Finalizada a Animação
            if (Input.GetKeyUp(KeyCode.Mouse0))
             {
                 speed = 8;
                 Destroy(this.clone);
                 Eativado = false;
                 Einverso = false;
                 EAtivo = false;
                 animator.SetBool("Eativado", false);
                 animator.SetBool("EcimaEsquerda", false);
                 animator.SetBool("EsuperiorDireito", false);
                 animator.SetBool("EmeioDireito", false);
                 animator.SetBool("Ecima", false);
                 animator.SetBool("EmeioEsquerda", false);
                 animator.SetBool("EsuperiorEsquerda", false);
                 posicaoR = 0;
            }
        }
        
    }
        // Start is called before the first frame update
        void Start()
        {
        // por enquanto
            shield = 0;
        // por enquanto

            cameraP = transform.position + new Vector3(0, 0, -10);
            speed = 8;
            Eativado = false;
            EAtivo = false;
      
        }

    // Update is called once per frame
    void Update()
    {
        // mouse é a posição do mouse em relação a camera no spaço
        mouse.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0, 0, +10);
        Mouse = mouse.transform.position - cameraP;
        // Mouse é a posição do mouse 
        print(Mouse);
        cameraP = transform.position + new Vector3(0, 0, -10);
         Vida();
      //  Ecostas.transform.position = transform.position + new Vector3(0f, 0.5f);
        animator.SetFloat("direcX", direcX);
        movimento();
       
    }   
}

