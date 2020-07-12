using System;
using UnityEngine;

public class HazardController : MonoBehaviour, ILeverListener
{
	[SerializeField]
	private LeverController LeverController = null;
	[SerializeField]
	private Collider Collider = null;
	[SerializeField]
	private Collider VoidCollider = null;
	
	private void Start()
	{
		LeverController.AddLeverListener(this);
	}

	public void OnStateChanged(LeverState state)
	{
		switch (state)
		{
			case LeverState.On:
				Collider.enabled = false;
				VoidCollider.enabled = false;
				break;
			case LeverState.Off:
				Collider.enabled = true;
				VoidCollider.enabled = true;
				break;
			default:
				throw new ArgumentOutOfRangeException(nameof(state), state, null);
		}
	}
}
