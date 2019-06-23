using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{

    [SerializeField] private GameObject[] Escudos = new GameObject[3];
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject mouse;
    private GameObject clone;

    public static Vector3 cameraP;
    
    private float direcX, speed;
    private int shield;
    private Vector3 comeco;
    private Vector2 Mouse;
    bool Eativado ,EAtivo;
    
    
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
            if (!EAtivo)
            {
               // clone = Instantiate(Escudos[shield], transform.position , Quaternion.identity);
                EAtivo = true;
            }

            direcX = 0;
            #region animacaoEscudoEsquerdo
            //ESuperiorEsquerdo
            if (Mouse.y >= 1.5f && Mouse.x <= -1.5)
            {
                animator.SetBool("EcimaEsquerda", false);
                animator.SetBool("EsuperiorDireito", false);
                animator.SetBool("EmeioDireito", false);
                animator.SetBool("Ecima", false);
                animator.SetBool("EmeioEsquerda", false);
                animator.SetBool("EsuperiorEsquerda", true);
            }
            //EMeioEsquerda
            if (Mouse.x <= 0f && Mouse.y <= 1.5f)
            {
                animator.SetBool("EcimaEsquerda", false);
                animator.SetBool("EsuperiorDireito", false);
                animator.SetBool("EmeioDireito", false);
                animator.SetBool("Ecima", false);
                animator.SetBool("EsuperiorEsquerda", false);
                animator.SetBool("EmeioEsquerda", true);
                
            }
            //ECimaEsquerda
            if (Mouse.y >= 2.5 && Mouse.x <= 0f && Mouse.x >= -1.5f)
            {
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
            if (Mouse.y >= 2.5 && Mouse.x >=0f && Mouse.x <=1.5f)
             {
                //instancia o escudo
                clone.transform.position = transform.position + new Vector3(-0.5f,1f);
              //  clone.transform.Rotate(0, 0, 90);
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
                animator.SetBool("EcimaEsquerda", false);
                animator.SetBool("EmeioDireito", false);
                animator.SetBool("Ecima", false);
                animator.SetBool("EmeioEsquerda", false);
                animator.SetBool("EsuperiorEsquerda", false);
                animator.SetBool("EsuperiorDireito", true);
             }
            //EMeioDireito   
            if (Mouse.x >= 0f && Mouse.y <=1.5f )
             {
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
                 EAtivo = false;
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
        // por enquanto
            shield = 0;
            cameraP = transform.position + new Vector3(0, 0, -10);
            speed = 8;
            comeco = new Vector3(0, 0);
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
            animator.SetFloat("direcX", direcX);
           
            movimento();
        }
    }


