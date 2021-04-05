using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bot : MonoBehaviour
{

    private bool checkBandeira;

    private NavMeshAgent bot;

    public float tempoDeCongelamento;
    public int time;
    public GameObject bandeira;
    public Vector3 offset;
    public GameObject area;
    public GameObject enemy;
    public float distanciaMaisPerto;
    public int inimigoMaisPerto;
    public playerControler jogador;
    int cont = 0;


    // Start is called before the first frame update
    void Start()
    {
        bot = this.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (checkBandeira  == true)
        {
            //bot vai atras de jogador com a bandeira
            bot.SetDestination(jogador.gameObject.transform.position);
        }
        else
        {
            if (enemy.transform.position.z >= 25f)
            {
                float distanceHelper = Vector3.Distance(transform.position, enemy.transform.position);
                if (distanceHelper <= 7f)
                {
                    bot.SetDestination(enemy.transform.position);
                    if (distanceHelper <= 1.5f)
                    {
                        Debug.Log("Pegou Inimigo");

                    }
                }
            }
            else
            {
                bot.SetDestination(bandeira.transform.position);
            }
        }


        if (tempoDeCongelamento > 0)
        {
            tempoDeCongelamento -= Time.deltaTime;

            return;
        }

        if (checkBandeira)
        {
            bandeira.transform.position = this.transform.position + offset;
            bot.SetDestination(area.transform.position);
        }

    }
    private void OnTriggerEnter(Collider other)
    {

        var otherBot = other.GetComponent<Bot>();

        if (otherBot)
        {
            if (otherBot.time != time)
            {
                otherBot.tempoDeCongelamento = 5;
                Debug.Log("COLISAO");

            }

        }
        if (other.tag == "PegaBandeira")
        {
            Debug.Log("Entrou Bandeira", gameObject);

            checkBandeira = true;

        }
    }

}