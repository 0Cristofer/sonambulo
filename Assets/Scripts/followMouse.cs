using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class followMouse : MonoBehaviour
{
    [SerializeField]
    private Camera MainCamera;

    [SerializeField]
    private float Distance;

    [SerializeField]
    private Vector3 MousePosition;

    [SerializeField]
    private float UnicornSize;

    [SerializeField]
    private bool UseMouseYtoSetUnicornSize;
    
    void LateUpdate()
    {
        MousePosition = Input.mousePosition;
        MousePosition.z = UseMouseYtoSetUnicornSize ? MousePosition.y / UnicornSize : Distance;
        transform.position = MainCamera.ScreenToWorldPoint(MousePosition);
    }
}
