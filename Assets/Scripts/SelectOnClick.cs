using UnityEngine;

public class SelectOnClick : MonoBehaviour
{
    [SerializeField]
    private Camera MainCamera = null;

    [SerializeField]
    private GameObject HighlightedObject = null;
    
    [SerializeField]
    private LayerMask FloorLayerMask;

    private Ray Ray;

    private RaycastHit HitData;

    private bool ClickObject { get; set; }
    private IOnObjectClicked Listener { get; set; }
    private IOnFloorClicked FloorListener { get; set; }

    public void SetObjectClickedListener(IOnObjectClicked listener)
    {
        Listener = listener;
    }
    
    public void SetOnFloorClickedListener(IOnFloorClicked listener)
    {
        FloorListener = listener;
    }

    public void SetClickObject(bool clickObject)
    {
        ClickObject = clickObject;
    }

    private void Update()
    {
        Ray = MainCamera.ScreenPointToRay(Input.mousePosition);

        if (ClickObject)
        {
            if (Physics.Raycast(Ray, out HitData, 1000000))
            {
                HighlightedObject = HitData.transform.gameObject;
                
                if (Input.GetMouseButtonDown(0))
                {
                    GameObject selectedObject = HitData.transform.gameObject;
                    ClickableObject obj = selectedObject.GetComponent<ClickableObject>();

                    if (obj != null)
                    {
                        Listener?.OnObjectClicked(obj);
                    }
                }
            }
        }
        else if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(Ray, out var hitData, 100000, FloorLayerMask))
            {
                Vector3 mouseWorldPosition = hitData.point;
                
                FloorListener?.OnFloorClicked(mouseWorldPosition);
            }
        }
        else
        {
            HighlightedObject = null;
        }
    }
}

public interface IOnObjectClicked
{
    void OnObjectClicked(ClickableObject clickableObject);
}

public interface IOnFloorClicked
{
    void OnFloorClicked(Vector3 position);
}