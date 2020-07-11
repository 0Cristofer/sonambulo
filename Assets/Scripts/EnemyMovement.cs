using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private Rigidbody EnemyRigidbody = null;

    [SerializeField]
    private float MoveSpeed = 0f;
    
    private void Update()
    {
        EnemyRigidbody.velocity = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized * MoveSpeed;
    }
}
