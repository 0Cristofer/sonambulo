using UnityEngine;

public class Unicornio : MonoBehaviour, IOnObjectClicked, IOnFloorClicked
{
	[SerializeField]
	private SelectOnClick SelectOnClick = null;

	private ClickableObject SelectedObject { get; set; }

	private void Awake()
	{
		SelectOnClick.SetObjectClickedListener(this);
		SelectOnClick.SetOnFloorClickedListener(this);
		SelectOnClick.SetClickObject(true);
	}

	private void Start()
	{
		SelectedObject = null;
	}

	public void OnObjectClicked(ClickableObject objectType)
	{
		if (SelectedObject != null)
			return;

		SelectedObject = objectType;
		SelectedObject.gameObject.SetActive(false);
		SelectOnClick.SetClickObject(false);
	}

	public void OnFloorClicked(Vector3 position)
	{
		if (SelectedObject == null)
			return;

		SelectedObject.gameObject.GetComponent<Transform>().position = position;
		SelectedObject.gameObject.SetActive(true);
		SelectedObject = null;
		SelectOnClick.SetClickObject(true);
	}
}
