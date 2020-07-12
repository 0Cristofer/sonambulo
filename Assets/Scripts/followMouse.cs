using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class FollowMouse : MonoBehaviour
{
    [SerializeField]
    private Camera MainCamera;

    [SerializeField]
    private LayerMask WallLayerMask;
    
    [SerializeField]
    private Vector3 WorldPosition;

    [SerializeField]
    private float SmoothTime = 0.2f;
    
    [SerializeField]
    private float SmoothGetOutTime = 0.01f;
    
    [SerializeField]
    private Vector3 Velocity = Vector3.zero;
    
    void LateUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitData;

        if (Physics.Raycast(ray, out hitData, 100000, ~WallLayerMask))
        {
            WorldPosition = hitData.point;
            transform.position = Vector3.SmoothDamp(transform.position, new Vector3(WorldPosition.x, WorldPosition.y + 1.5f, WorldPosition.z),  ref Velocity, SmoothTime);
        }
        
    }

}
