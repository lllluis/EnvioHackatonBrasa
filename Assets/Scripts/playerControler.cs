using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControler : MonoBehaviour
{

    private CharacterController controller;
    private Animator anim;

    public float speed;
    public float gravity;
    public float rotSpeed;

    private float rot;
    private Vector3 moveDirection;


    bool atacando;
    public bool checkBandeira;
    public bool congelado;
    public float tempoCongelado;

    
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
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
            Move();

    }
    }

    private void FixedUpdate()
    {
        






    }

    void Move(){

        if(controller.isGrounded)
        {
        
        if (Input.GetKey(KeyCode.W)){
            moveDirection = Vector3.forward * speed; 
            anim.SetInteger("transition",1);
        }

        if(Input.GetKeyUp(KeyCode.W)){
            moveDirection = Vector3.zero;
            anim.SetInteger("transition",0);
        }
        
        if(Input.GetKey(KeyCode.S)){
            moveDirection = Vector3.forward * speed; 
            anim.SetInteger("transition",1);
        }
        
        
        
        }



        rot += Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
        transform.eulerAngles = new Vector3(0, rot, 0); 

        moveDirection.y -= gravity * Time.deltaTime;
        moveDirection = transform.TransformDirection(moveDirection);

        controller.Move(moveDirection * Time.deltaTime);
        /*else {
            //pulo
        }*/
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
