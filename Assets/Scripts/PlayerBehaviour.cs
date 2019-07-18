using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject[] Escudos = new GameObject[3];
    [SerializeField] private Image[] canvas = new Image[4];
    [SerializeField] private Animator animator;
    [SerializeField] private Image mao, segundo;
    [SerializeField] private Image[] Texto;
    [SerializeField] private GameObject mouse,Ecostasv,smoke_1,z,Z;
    private bool[] inventario = new bool[3];
    private GameObject clone,Ecostas;
    public static Vector3 cameraP; 
    private float direcX, speed,posicaoR;
    private int shield, armadura;
    private Vector2 Mouse;
    bool Eativado ,EAtivo,Einverso ,EcostasAtivo;
    Scene currentScene;
    string sceneName; 
    void Start()
        {
            //NECESSÁRIO
            for (int i = 1; i < canvas.Length; i++)
            {
              canvas[i].color = new Color(canvas[i].color.r, canvas[i].color.g, canvas[i].color.b, 0.5f);
            }
            currentScene = SceneManager.GetActiveScene();
            sceneName = currentScene.name;
            inventario[0] = true;
            shield = 1;
            armadura = 0;         
            speed = 8;
            if (sceneName == "Act2")
                speed = 4;
            Eativado = false;
            EAtivo = false;
            Texto[2].enabled = false;
            Texto[1].enabled = false;
            Texto[0].enabled = false;
            segundo.enabled = false;
    }
    void Update()
    {
        Iventario();
        MouseCamera();
        Vida();
        Movimento();
        AnimEscudo();
    }   
    void Dialogos()
    {

    }
    void Iventario()
    {
        if (inventario[1] && !Eativado)
        {
            if(Input.GetAxis("Mouse ScrollWheel") > 0f)
            {
                ScrollMouse();
            }
            if (Input.GetAxis("Mouse ScrollWheel") < 0f)
            {
                ScrollMouse();
            }
        }
    }
    void MouseCamera(){
     mouse.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0, 0, +10);
     Mouse = mouse.transform.position - cameraP;
     cameraP = transform.position + new Vector3(0, 0, -10);
    }
    void Vida()
    {
        //canvas
        for (int i = 3; i != 0; i--)
        {
            if (i - 1 == armadura)
                canvas[i].color = new Color(canvas[i].color.r, canvas[i].color.g, canvas[i].color.b, 0.5f);
            if (i == armadura)
                canvas[i].color = new Color(canvas[i].color.r, canvas[i].color.g, canvas[i].color.b, 1f);
        }
        if (armadura!= 0)
        {

            if (Input.GetKeyDown(KeyCode.Q))
          {
                
            armadura--;
        /*   switch (armadura)
            {
                case 0:
                Destroy(Instantiate(smoke_1, transform.position + new Vector3(-1.9f,0.92f),Quaternion.identity),2);                      
                break;
                case 1:
                Destroy(Instantiate(smoke_1, transform.position + new Vector3(-1.9f,2.82f),Quaternion.identity),2);
                break;
                case 2:
                Destroy(Instantiate(smoke_1, transform.position + new Vector3(-1.9f,4f),Quaternion.identity),2);
                break;
            }
        */
            animator.SetInteger("Armadura", armadura);
          }
        }
    if (armadura !=3 )
    {
        if (Input.GetKeyDown(KeyCode.E)) 
       {
            armadura++;
          /*  switch (armadura)
            {
                case 1:
                Destroy(Instantiate(smoke_1, transform.position + new Vector3(-1.9f,0.92f),Quaternion.identity),2);
                break;
                case 2:
                Destroy(Instantiate(smoke_1, transform.position + new Vector3(-1.9f,2.82f),Quaternion.identity),2);
                break;
                case 3:
                Destroy(Instantiate(smoke_1, transform.position + new Vector3(-1.9f,4f),Quaternion.identity),2);
                break;
            }
          */
            animator.SetInteger("Armadura", armadura);
        }
    }
}
    void Movimento()
{
    animator.SetFloat("direcX", direcX);
    if (!Eativado)
    {
      direcX = Input.GetAxis("Horizontal");
      transform.Translate(Vector3.right * Time.deltaTime * direcX * speed,Space.World);
    }
}
    void AnimEscudo()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Eativado = true;
            animator.SetBool("Eativado", true);
        } 
        if (Eativado)
        {
            direcX = 0;
           
            if (!EAtivo)
           {
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
                 if (sceneName == "Act2")
                speed = 4;
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
    void ScrollMouse()
    {
        switch (shield)
        {
            case 0:
                shield = 1;
                mao.enabled = true;
                segundo.enabled = false;
                break;
            case 1:
                shield = 0;
                mao.enabled = false;
                segundo.enabled = true;
                break;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "escudoPegar")
        {
            collision.GetComponent<Animator>().SetBool("PlayerNearby", true);
            Z = Instantiate(z);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        
        if (collision.tag == "escudoPegar") { 
         collision.GetComponent<Animator>().SetBool("PlayerNearby", false);
         Destroy(Z);
        }

    }
    private void OnTriggerStay2D(Collider2D collision)
    {

        if (Input.GetKeyDown(KeyCode.Z) && collision.tag == "escudoPegar" && !Eativado)
        {
            Destroy(Z);
            Destroy(collision.gameObject);
            shield = 0;
            segundo.enabled = true;
            mao.enabled = false;
            inventario[1] = true; // escudo
        }

    }
}


