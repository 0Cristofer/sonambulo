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
    
    private IOnObjectClicked Listener { get; set; }

    public void SetObjectClickedListener(IOnObjectClicked listener)
    {
        Listener = listener;
    }
    
    private void Update()
    {
        Ray = MainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(Ray, out HitData, 1000000, SelectableLayer))
        {
            HighlightedObject = HitData.transform.gameObject;
            
            if (Input.GetMouseButtonDown(0))
            {
                SelectedObject = HitData.transform.gameObject;
                ClickableObject obj = SelectedObject.GetComponent<ClickableObject>();

                if (obj != null)
                {
                    Listener?.OnObjectClicked(obj);
                }
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

public interface IOnObjectClicked
{
    void OnObjectClicked(ClickableObject clickableObject);
}
