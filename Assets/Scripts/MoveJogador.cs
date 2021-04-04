using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveJogador : MonoBehaviour
{
    public float velocidade, forcaPulo;
    bool atacando;
    public bool checkBandeira;
    public bool congelado;
    public float tempoCongelado;

    

    private Rigidbody rb;
    private bool frente, direita, esquerda, tras, pular;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {

if(this.gameObject.transform.position.z>=25f){
    atacando = true;
    //Debug.Log("player esta atacando");
}
else {
    atacando = false;
   // Debug.Log("player esta defendendo");
}

if(congelado){
    tempoCongelado -= Time.deltaTime;
    if(tempoCongelado<=0.1f){
        congelado = false;
        tempoCongelado = 5f;
    }}
    else{
                ChecarInputs();

    }
    }

    private void FixedUpdate()
    {
        Movimentar();
    }

    void ChecarInputs()
    {
        if (Input.GetKey(KeyCode.W))
            frente = true;
        if (Input.GetKey(KeyCode.D))
            direita = true;
        if (Input.GetKey(KeyCode.A))
            esquerda = true;
        if (Input.GetKey(KeyCode.S))
            tras = true;
        if (Input.GetKeyDown(KeyCode.Space))
            pular = true;
    }

    void Movimentar()
    {
        if (frente)
        {
            rb.velocity = new Vector3(0f,0f,7f);
            frente = false;
        }
        if (direita)
        {
            rb.velocity = new Vector3(7f,0f,0f);
            direita = false;
        }
        if (esquerda)
        {
            rb.velocity = new Vector3(-7f,0f,0f);
            esquerda = false;
        }
        if (tras)
        {
            rb.velocity = new Vector3(0f,0f,-7f);
            tras = false;
        }
        if (pular)
        {
            rb.velocity = new Vector3(0f,7f,0f);
            pular = false;
        }

    }
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "AreaBandeiraTime1"){
            Debug.Log("Entrou na Area Bandeira 1");
        }

        if(other.tag == "AreaBandeiraTime2"){
        Debug.Log("Entrou na Area Bandeira 2");

    }
        if(other.tag == "PegaBandeira"){
            Debug.Log("Entrou Bandeira");
            checkBandeira = true; 

        }




}
}


