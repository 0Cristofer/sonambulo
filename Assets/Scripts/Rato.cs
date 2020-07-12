using DG.Tweening;
using UnityEngine;

public class Rato : EnemyMovement
{
	private bool Animating { get; set; }
	private Sequence Animation { get; set; }
	private Transform Transform { get; set; }

	private void Start()
	{
		Animating = false;
		Transform = GetComponent<Transform>();
	}
	
	protected override void OnDirectionChanged()
	{
		AnimateRotation();
	}

	private void AnimateRotation()
	{
		if (Animating)
		{
			Animation.Complete();
		}
		
		Sequence seq = DOTween.Sequence();
		Vector3 localEulerAngles = Transform.localEulerAngles;

		float rotationY = localEulerAngles.y + (Direction == MovementDirection.Forward ? -180f : 180f);
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
