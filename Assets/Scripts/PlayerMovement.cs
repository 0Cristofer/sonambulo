using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private bool collided = false;
    
    [SerializeField] 
    private float distance;

    [SerializeField]
    private float moveSpeed;

    private Vector3 moveDirection;
    public LayerMask objectsLayer;
    
    [SerializeField]
    private Rigidbody PlayerRigidBody;
    
    // Start is called before the first frame update
    private void Start()
    {
        moveDirection = Vector3.forward;
    }

    // Update is called once per frame
    private void Update()
    {
        if (transform.position.z > distance || collided) return;
        
        if (Input.GetKeyDown(KeyCode.L))
        {
            RotateLeft();
        }
        
        if (Input.GetKeyDown(KeyCode.R))
        {
            RotateRight();
        }

        PlayerRigidBody.velocity = moveDirection.normalized * moveSpeed;
    }

    private void RotateLeft()
    {
        if (moveDirection.z == 1) // if moving forward
        {
            moveDirection = new Vector3(-1, 0, 0);
        }
        else if(moveDirection.x == -1) // if moving to the left
        {
            moveDirection = new Vector3(0, 0, -1);
            
        } else if (moveDirection.z == -1) //if moving backwards 
        {
            moveDirection = new Vector3(1, 0,0);   
        }
        else // if moving to the right 
        {
            moveDirection = new Vector3(0, 0, 1);
        }
        PlayerRigidBody.transform.Rotate(0, 90, 0);   
    }
    
    private void RotateRight()
    {
        if (moveDirection.z == 1) // if moving forward
        {
            moveDirection = new Vector3(1, 0, 0);
            //PlayerRigidBody.transform.localEulerAngles = new Vector3();
        }
        else if(moveDirection.x == 1) // if moving to the left
        {
            moveDirection = new Vector3(0, 0, -1);
            
        } else if (moveDirection.z == -1) //if moving backwards 
        {
            moveDirection = new Vector3(-1, 0,0);   
        }
        else // if moving to the right 
        {
            moveDirection = new Vector3(0, 0, 1);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            collided = true;
        }
    }
}
