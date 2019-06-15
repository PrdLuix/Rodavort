using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    private float direcX, speed;
    public static Vector3 cameraP;
    private Vector3 comeco;
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
            /* if ()
             {
                 print("cima");
                 animator.SetBool("EmeioDireito", false);
                 animator.SetBool("EsuperiorDireito", false);
                 animator.SetBool("Ecima", true);
             }
             if ( == "SuperiorDireito")
             {
                 animator.SetBool("Ecima", false);
                 animator.SetBool("EmeioDireito", false);
                 animator.SetBool("EsuperiorDireito", true);
             }
             if (collision.tag == "MeioDireito")
             {
                 animator.SetBool("Ecima", false);
                 animator.SetBool("EsuperiorDireito", false);
                 animator.SetBool("EmeioDireito", true);
             }
             if (Input.GetKeyUp(KeyCode.Mouse0))
             {
                 Eativado = false;
                 animator.SetBool("Eativado", false);
                 animator.SetBool("EsuperiorDireito", false);
                 animator.SetBool("EmeioDireito", false);
                 animator.SetBool("Ecima", false);
             }
         }*/
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
            mouse.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0, 0, +10);
            print(mouse.transform.position);
            cameraP = transform.position + new Vector3(0, 0, -10);
            animator.SetFloat("direcX", direcX);
            direcX = Input.GetAxis("Horizontal");
            movimento();
        }
    }


