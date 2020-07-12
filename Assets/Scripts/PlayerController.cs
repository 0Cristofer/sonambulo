using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float MoveSpeed = 0;
    [SerializeField]
    private Rigidbody PlayerRigidBody = null;
    [SerializeField]
    private Vector3 InitialDirection = Vector3.zero;
    [SerializeField]
    private Canvas WinCanvas = null;
    [SerializeField]
    private Canvas LoseCanvas = null;

    private Vector3 MoveDirection;
    private bool Collided = false;

    private void Start()
    {
        MoveDirection = InitialDirection;
    }
    
    private void Update()
    {
        if (Collided)
        {
            // perder
            Debug.Log("PERDEU");
            return;
        }

        PlayerRigidBody.velocity = MoveDirection.normalized * MoveSpeed;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Hazard") || other.gameObject.CompareTag("Bounceable") || other.gameObject.CompareTag("Bounceable"))
        {
            Collided = true;
            LoseCanvas.gameObject.SetActive(true);
        }

        if (other.gameObject.CompareTag("Bed"))
        {
            gameObject.SetActive(false);
            Application.App.WinLevel();
            WinCanvas.gameObject.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        ChangeDirection(other.gameObject.GetComponent<TileController>().TileDirection);
    }

    private void ChangeDirection(TileDirection tileDirection)
    {
        switch (tileDirection)
        {
            case TileDirection.ZUp:
                MoveDirection = new Vector3(0, 0, 1);
                break;
            case TileDirection.ZDown:
                MoveDirection = new Vector3(0, 0, -1);
                break;
            case TileDirection.XUp:
                MoveDirection = new Vector3(1, 0, 0);
                break;
            case TileDirection.XDown:
                MoveDirection = new Vector3(-1, 0, 0);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(tileDirection), tileDirection, null);
        }
    }
}
