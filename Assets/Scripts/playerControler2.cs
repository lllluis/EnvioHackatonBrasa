using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControler2 : MonoBehaviour
{

    private CharacterController controller;


    public float speed;
    public float gravity;
    public float rotSpeed;

    private float rot;
    private Vector3 moveDirection;



    
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    
    }

    // Update is called once per frame
    void Update(){
        Move();
    }


    private void FixedUpdate()
    {
    

    }

    void Move()
    {

        if(controller.isGrounded)
        {
        
        if (Input.GetKey(KeyCode.I))
        {
            moveDirection = Vector3.forward * speed; 
            
        }

        if(Input.GetKeyUp(KeyCode.I))
        {
            moveDirection = Vector3.zero;
            
        }
        
        if(Input.GetKey(KeyCode.K))
        {
            moveDirection = Vector3.forward * speed; 
            
        }
        
        }
        
        rot += Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
        transform.eulerAngles = new Vector3(0, rot, 0); 

        moveDirection.y -= gravity * Time.deltaTime;
        moveDirection = transform.TransformDirection(moveDirection);

        controller.Move(moveDirection * Time.deltaTime);
        
    }

    
}
