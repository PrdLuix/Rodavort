using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CreditsBehaviour : MonoBehaviour
{
    private float yInicial, yFinal,speed;
    private void Start()
    {
        yFinal = 6;
        yInicial = -9;
        speed = 0.03f;
    }
    [SerializeField] Text text;
    void Update()
    {
        InputBack();
        SubirTxt();   
    }
    void SubirTxt()
    {
        text.transform.position += new Vector3(0, speed);
        if (text.transform.position.y >= yFinal)
            text.transform.position = new Vector3(0, yInicial);
    }
    void InputBack()
    {
        if (Input.GetKeyDown(KeyCode.Z))
            SceneManager.LoadScene("Menu");
    }
}
