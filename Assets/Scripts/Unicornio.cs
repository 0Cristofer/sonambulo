using UnityEngine;

public class Unicornio : MonoBehaviour, IOnObjectClicked
{
	[SerializeField]
	private SelectOnClick SelectOnClick = null;

	private ClickableObject SelectedObject { get; set; }

	private void Awake()
	{
		SelectOnClick.SetObjectClickedListener(this);
	}

	private void Start()
	{
		SelectedObject = null;
	}

	public void OnObjectClicked(ClickableObject objectType)
	{
		if (SelectedObject != null)
			return;
        
		SelectedObject.gameObject.SetActive(false);
		SelectedObject = objectType;
	}

	public void OnFloorClicked(Vector3 position)
	{
		if (SelectedObject == null)
			return;

		SelectedObject.gameObject.GetComponent<Transform>().position = position;
		SelectedObject.gameObject.SetActive(true);
		SelectedObject = null;
	}
}
