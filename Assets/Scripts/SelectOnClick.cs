using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectOnClick : MonoBehaviour
{
    [SerializeField]
    private Camera MainCamera;
    
    [SerializeField]
    private GameObject SelectedObject;

    [SerializeField]
    private GameObject HighlightedObject;

    [SerializeField]
    private LayerMask SelectableLayer;

    private Ray Ray;

    private RaycastHit HitData;
    
    private void Update()
    {
        Ray = MainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(Ray, out HitData, 1000000, SelectableLayer))
        {
            HighlightedObject = HitData.transform.gameObject;
            
            if (Input.GetMouseButtonDown(0))
            {
                SelectedObject = HitData.transform.gameObject;
            }
            
        }
        else
        {
            HighlightedObject = null;

            if (Input.GetMouseButtonDown(0))
            {
                SelectedObject = null;
            }
            
        }
    }
}
