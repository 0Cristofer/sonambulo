using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldPosition : MonoBehaviour
{
    [SerializeField]
    private Camera MainCamera;
    
    [SerializeField]
    private Vector3 MouseWorldPosition;

    [SerializeField]
    private LayerMask FloorLayerMask;

    [SerializeField]
    private GameObject prefabCube;
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = MainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out var hitData, 100000, FloorLayerMask))
            {
                MouseWorldPosition = hitData.point;
            }
            Instantiate(prefabCube, MouseWorldPosition, Quaternion.identity);
        }
    }
}
