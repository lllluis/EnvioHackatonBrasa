using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class botTimeSec : MonoBehaviour
{
    public float velocidade, forcaPulo;
    bool atacando;
    public bool checkBandeira;
    public bool congelado;
    public float tempoCongelado;

    private NavMeshAgent player;
    private Rigidbody rb;
    private bool frente, direita, esquerda, tras, pular;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        player = GetComponent<NavMeshAgent>();
    }

    void Update(){

                ChecarInputs();
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
            player.velocity = new Vector3(0f,0f,7f);
            frente = false;
        }
        if (direita)
        {
            player.velocity = new Vector3(7f,0f,0f);
            direita = false;
        }
        if (esquerda)
        {
            player.velocity = new Vector3(-7f,0f,0f);
            esquerda = false;
        }
        if (tras)
        {
            player.velocity = new Vector3(0f,0f,-7f);
            tras = false;
        }
        if (pular)
        {
            player.velocity = new Vector3(0f,7f,0f);
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


