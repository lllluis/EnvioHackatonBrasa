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
public GameObject[] enemys;
public MoveJogador jogador;
int cont=0;


    // Start is called before the first frame update
    void Start()
    {
        bot = this.GetComponent <NavMeshAgent>();      
    }

    // Update is called once per frame
    void Update()
    {

    if(tempoDeCongelamento>0){
        tempoDeCongelamento-=Time.deltaTime;

    return;
    }



        if(jogador.checkBandeira){
            //bot vai atras de jogador com a bandeira
            
            bot.SetDestination(jogador.gameObject.transform.position);
            
        }
        
      else
      {
           bot.SetDestination(bandeira.transform.position);
       
      }

       if(checkBandeira){
          bandeira.transform.position =  this.transform.position + offset;
          bot.SetDestination(area.transform.position);
        }
                 
    }
       private void OnTriggerEnter(Collider other)
    {

     var otherBot = other.GetComponent<Bot>();

     if(otherBot){
           if(otherBot.time != time ){
                  otherBot.tempoDeCongelamento = 5; 
                  Debug.Log("COLISAO");
               
           }
     
        }
           if(other.tag == "PegaBandeira"){
            Debug.Log("Entrou Bandeira",gameObject);

            checkBandeira = true; 

        }
    }

}
