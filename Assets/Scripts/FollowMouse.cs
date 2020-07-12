using UnityEngine;

public class FollowMouse : MonoBehaviour
{
	[SerializeField]
	private Camera MainCamera = null;

	[SerializeField]
	private LayerMask WallLayerMask;
    
	[SerializeField]
	private Vector3 WorldPosition = Vector3.zero;

	[SerializeField]
	private float SmoothTime = 0.2f;
    
	[SerializeField]
	private Vector3 Velocity = Vector3.zero;
    
	private void LateUpdate()
	{
		Ray ray = MainCamera.ScreenPointToRay(Input.mousePosition);

		if (Physics.Raycast(ray, out var hitData, 100000, ~WallLayerMask))
		{
			WorldPosition = hitData.point;
			transform.position = Vector3.SmoothDamp(transform.position, new Vector3(WorldPosition.x, WorldPosition.y + 1.5f, WorldPosition.z),  ref Velocity, SmoothTime);
		}
      
	}
}