using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField]
    private Camera MainCamera;
    
    [SerializeField]
    private Vector3 WorldPosition;

    [SerializeField]
    private LayerMask FloorLayerMask;
    
    void Update()
    {
        Ray ray = MainCamera.ScreenPointToRay(Input.mousePosition);
        
        if (Physics.Raycast(ray, out var hitData, 100000, FloorLayerMask))
        {
            WorldPosition = hitData.point;
        }
    }
}
