using UnityEngine;

public class ClickableObject : MonoBehaviour
{
	[SerializeField]
	public ObjectType ObjectType = ObjectType.None;
}

public enum ObjectType
{
	None = 0,
	Box,
	TileZUp,
	TileZDown,
	TileXUp,
	TileXDown
}
