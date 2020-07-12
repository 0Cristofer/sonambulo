using UnityEngine;

public abstract class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private Rigidbody EnemyRigidbody = null;
    [SerializeField]
    private float MoveSpeed = 0f;
    [SerializeField]
    private Vector3 ForwardDirection = Vector3.zero;
    [SerializeField]
    protected Vector3 BackwardsDirection = Vector3.zero;
    [SerializeField]
    private MovementDirection InitialDirection = MovementDirection.Forward;

    protected MovementDirection Direction { get; private set; }

    private void Awake()
    {
        Direction = InitialDirection;
    }
    
    private void FixedUpdate()
    {
        EnemyRigidbody.velocity =
            (Direction == MovementDirection.Forward ? ForwardDirection : BackwardsDirection) * MoveSpeed;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.CompareTag("Bounceable"))
            return;
        
        ChangeDirection();
    }

    private void ChangeDirection()
    {
        Direction = Direction == MovementDirection.Forward ? MovementDirection.Backwards : MovementDirection.Forward;
        OnDirectionChanged();
    }

    protected abstract void OnDirectionChanged();

    protected enum MovementDirection
    {
        Forward = 0,
        Backwards
    }
}
