using System;
using DG.Tweening;
using UnityEngine;

public class Rato : EnemyMovement
{
	private bool Animating { get; set; }
	private Sequence Animation { get; set; }
	private Transform Transform { get; set; }
	private int ForwardAngle { get; set; }

	private void Start()
	{
		Animating = false;
		Transform = GetComponent<Transform>();
		ForwardAngle = 1;
	}
	
	protected override void OnDirectionChanged()
	{
		Vector3 localEulerAngles = Transform.localEulerAngles;
		float rotationY = localEulerAngles.y + (Direction == MovementDirection.Forward ? -180f * ForwardAngle : 180f * ForwardAngle);
		AnimateRotation(rotationY);
	}

	protected override void OnForwardChanged(TileDirection tileDirection)
	{
		switch (tileDirection)
		{
			case TileDirection.ZUp:
				AnimateRotation(0);
				break;
			case TileDirection.ZDown:
				AnimateRotation(180);
				break;
			case TileDirection.XUp:
				AnimateRotation(90);
				break;
			case TileDirection.XDown:
				AnimateRotation(270);
				break;
			default:
				throw new ArgumentOutOfRangeException(nameof(tileDirection), tileDirection, null);
		}

		if (Direction == MovementDirection.Backwards)
			ForwardAngle *= -1;
	}

	private void AnimateRotation(float rotationY)
	{
		if (Animating)
		{
			Animation.Complete();
		}
		
		Sequence seq = DOTween.Sequence();
		
		Vector3 localEulerAngles = Transform.localEulerAngles;
		Vector3 rotation = new Vector3(localEulerAngles.x, rotationY, localEulerAngles.z);

		Animating = true;
		Animation = seq;
		
		seq.Append(Transform.DOLocalRotate(rotation, 0.3f));
		seq.AppendCallback(() =>
		{
			Animating = false;
			Animation = null;
		});

		seq.Play();
	}
}
