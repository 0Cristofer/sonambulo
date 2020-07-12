using UnityEngine;

public class TileController : MonoBehaviour
{
	[SerializeField]
	public TileDirection TileDirection = TileDirection.ZUp;
}

public enum TileDirection
{
	ZUp = 0,
	ZDown,
	XUp,
	XDown
}
