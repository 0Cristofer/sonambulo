using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] 
    private float Distance = 0;
    [SerializeField]
    private float MoveSpeed = 0;

    private bool Collided = false;
    private Vector3 MoveDirection;
    
    [SerializeField]
    private Rigidbody PlayerRigidBody = null;
    
    private void Start()
    {
        MoveDirection = Vector3.forward;
    }

    private void Update()
    {
        if (transform.position.z > Distance || Collided) 
            return;
        
        if (Input.GetKeyDown(KeyCode.L))
        {
            RotateLeft();
        }
        
        if (Input.GetKeyDown(KeyCode.R))
        {
            RotateRight();
        }

        PlayerRigidBody.velocity = MoveDirection.normalized * MoveSpeed;
    }

    private void RotateLeft()
    {
        if (MoveDirection.z == 1) // if moving forward
        {
            MoveDirection = new Vector3(-1, 0, 0);
        }
        else if (MoveDirection.x == -1) // if moving to the left
        {
            MoveDirection = new Vector3(0, 0, -1);
            
        } else if (MoveDirection.z == -1) //if moving backwards 
        {
            MoveDirection = new Vector3(1, 0,0);   
        }
        else // if moving to the right 
        {
            MoveDirection = new Vector3(0, 0, 1);
        }
        
        PlayerRigidBody.transform.Rotate(0, 90, 0);   
    }
    
    private void RotateRight()
    {
        if (MoveDirection.z == 1) // if moving forward
        {
            MoveDirection = new Vector3(1, 0, 0);
        }
        else if(MoveDirection.x == 1) // if moving to the left
        {
            MoveDirection = new Vector3(0, 0, -1);
            
        } else if (MoveDirection.z == -1) //if moving backwards 
        {
            MoveDirection = new Vector3(-1, 0,0);   
        }
        else // if moving to the right 
        {
            MoveDirection = new Vector3(0, 0, 1);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Collided = true;
        }
    }
}
