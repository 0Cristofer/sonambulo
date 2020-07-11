using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private Rigidbody EnemyRigidbody;

    [SerializeField]
    private float moveSpeed;
    
    private void Update()
    {
        EnemyRigidbody.velocity = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized * moveSpeed;
    }
}
