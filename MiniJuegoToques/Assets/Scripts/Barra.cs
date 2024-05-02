using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Barra : MonoBehaviour
{
    private float velocidad;
    private float x;

    private bool bloquearDerecha = false;
    private bool bloquearIzquierda = false;
    private int numeroToques = 0;

    public GameObject puntuacion;
    
    void Start()
    {
        velocidad = 8.0f;
    }

    void Update()
    {
        x = Input.GetAxis("Horizontal") * Time.deltaTime * velocidad;
        Debug.Log(x);
        Debug.Log(bloquearDerecha);
        
        if (x > 0.0f && bloquearDerecha || x < 0.0f && bloquearIzquierda)
        {
            return;
        }

        Debug.Log("Move");
        this.gameObject.transform.Translate(x, 0.0f, 0.0f);
    }

    private void OnTriggerEnter2D(Collider2D objeto)
    {
        Debug.Log("Enter");
        bloquearIzquierda = objeto.gameObject.tag == "LimiteIzquierdo";
        bloquearDerecha = objeto.gameObject.tag == "LimiteDerecho";
    }
    
    private void OnTriggerExit2D(Collider2D objeto)
    {
        bloquearIzquierda = false;
        bloquearDerecha = false;
    }
    
    private void OnCollisionEnter2D(Collider2D objeto)
    {
        if (objeto.gameObject.tag == "Balon")
        {
            numeroToques++;
            puntuacion.GetComponent<Text>().text = numeroToques.ToString();
        }
    }
}
