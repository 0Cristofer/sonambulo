using System;
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
    private MovementDirection InitialDirection = MovementDirection.Forward;

    protected MovementDirection Direction { get; private set; }

    private void Awake()
    {
        Direction = InitialDirection;
    }
    
    private void FixedUpdate()
    {
        EnemyRigidbody.velocity =
            (Direction == MovementDirection.Forward ? ForwardDirection : ForwardDirection * -1) * MoveSpeed;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.CompareTag("Bounceable"))
            return;
        
        ChangeDirection();
    }

    private void OnTriggerEnter(Collider other)
    {
        ChangeForwardDirection(other.gameObject.GetComponent<TileController>().TileDirection);
    }
    
    private void ChangeForwardDirection(TileDirection tileDirection)
    {
        Vector3 newDirection;
        switch (tileDirection)
        {
            case TileDirection.ZUp:
                newDirection = new Vector3(0, 0, 1);
                EnemyRigidbody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
                break;
            case TileDirection.ZDown:
                newDirection = new Vector3(0, 0, -1);
                EnemyRigidbody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
                break;
            case TileDirection.XUp:
                newDirection = new Vector3(1, 0, 0);
                EnemyRigidbody.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
                break;
            case TileDirection.XDown:
                newDirection = new Vector3(-1, 0, 0);
                EnemyRigidbody.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(tileDirection), tileDirection, null);
        }

        if (Direction == MovementDirection.Forward)
        {
            ForwardDirection = newDirection;
        }
        else
        {
            ForwardDirection = newDirection * -1;
        }
        
        OnForwardChanged(tileDirection);
    }

    private void ChangeDirection()
    {
        Direction = Direction == MovementDirection.Forward ? MovementDirection.Backwards : MovementDirection.Forward;
        OnDirectionChanged();
    }

    protected abstract void OnDirectionChanged();
    protected abstract void OnForwardChanged(TileDirection tileDirection);

    protected enum MovementDirection
    {
        Forward = 0,
        Backwards
    }
}
