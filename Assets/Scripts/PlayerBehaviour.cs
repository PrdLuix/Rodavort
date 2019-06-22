using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    private float direcX, speed;
    public static Vector3 cameraP;
    private Vector3 comeco;
    private Vector2 Mouse;
    bool Eativado;
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject mouse;
    void movimento()
    {

        if (!Eativado)
        {
            transform.Translate(Vector3.right * Time.deltaTime * direcX * speed);
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && direcX == 0)
        {
            Eativado = true;
            animator.SetBool("Eativado", true);
        }
        if (Eativado)
        {
            if (Mouse.y >= 1.5f && Mouse.x <= -1.5)
            {
                animator.SetBool("EcimaEsquerda", false);
                animator.SetBool("EsuperiorDireito", false);
                animator.SetBool("EmeioDireito", false);
                animator.SetBool("Ecima", false);
                animator.SetBool("EmeioEsquerda", false);
                animator.SetBool("EsuperiorEsquerda", true);
            }
            if (Mouse.x <= 0f && Mouse.y <= 1.5f)
            {
                animator.SetBool("EcimaEsquerda", false);
                animator.SetBool("EsuperiorDireito", false);
                animator.SetBool("EmeioDireito", false);
                animator.SetBool("Ecima", false);
                animator.SetBool("EsuperiorEsquerda", false);
                animator.SetBool("EmeioEsquerda", true);
                
            }
            if (Mouse.y >= 2.5 && Mouse.x <= 0f && Mouse.x >= -1.5f)
            {
                animator.SetBool("EsuperiorDireito", false);
                animator.SetBool("EmeioDireito", false);
                animator.SetBool("Ecima", false);
                animator.SetBool("EmeioEsquerda", false);
                animator.SetBool("EsuperiorEsquerda", false);
                animator.SetBool("EcimaEsquerda", true);

            }
             if (Mouse.y >= 2.5 && Mouse.x >=0f && Mouse.x <=1.5f)
             {
                animator.SetBool("EcimaEsquerda", false);
                animator.SetBool("EsuperiorDireito", false);
                animator.SetBool("EmeioDireito", false);
                animator.SetBool("EmeioEsquerda", false);
                animator.SetBool("EsuperiorEsquerda", false);
                animator.SetBool("Ecima", true);
             }
           
             if (Mouse.y >=1.5f && Mouse.x >=1.5)
             {
                animator.SetBool("EcimaEsquerda", false);
                animator.SetBool("EmeioDireito", false);
                animator.SetBool("Ecima", false);
                animator.SetBool("EmeioEsquerda", false);
                animator.SetBool("EsuperiorEsquerda", false);
                animator.SetBool("EsuperiorDireito", true);
             } 
                
             if (Mouse.x >= 0f && Mouse.y <=1.5f )
             {
                animator.SetBool("EcimaEsquerda", false);
                animator.SetBool("EsuperiorDireito", false);
                animator.SetBool("Ecima", false);
                animator.SetBool("EmeioEsquerda", false);
                animator.SetBool("EsuperiorEsquerda", false);
                animator.SetBool("EmeioDireito", true);
             }
             
             if (Input.GetKeyUp(KeyCode.Mouse0))
             {
                 Eativado = false;
                animator.SetBool("Eativado", false);
                 animator.SetBool("EcimaEsquerda", false);
                 animator.SetBool("EsuperiorDireito", false);
                 animator.SetBool("EmeioDireito", false);
                 animator.SetBool("Ecima", false);
                 animator.SetBool("EmeioEsquerda", false);
                 animator.SetBool("EsuperiorEsquerda", false);
            }
        }
        
    }
        // Start is called before the first frame update
        void Start()
        {
            cameraP = transform.position + new Vector3(0, 0, -10);
            speed = 8;
            comeco = new Vector3(0, 0);
            Eativado = false;
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
            animator.SetFloat("direcX", direcX);
            direcX = Input.GetAxis("Horizontal");
            movimento();
        }
    }


