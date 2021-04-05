using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotAtras : MonoBehaviour
{
    public float Speed;
    public float StoppingDistance;
    private Transform Target;
    public GameObject enemy;


    void Start(){
        Target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update (){

 if (Target.transform.position.z >= 25f){

        if(Vector2.Distance(transform.position, Target.position) > StoppingDistance){
        transform.position = Vector2.MoveTowards(transform.position,Target.position, Speed * Time.deltaTime);
    }}



}
}
