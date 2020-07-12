using System;
using DG.Tweening;
using UnityEngine;

public class BridgeController : MonoBehaviour, ILeverListener
{
	[SerializeField]
	private bool InitialState = false;
	[SerializeField]
	private LeverController LeverController = null;

	private Transform Transform { get; set; }

	private void Awake()
	{
		Transform = gameObject.GetComponent<Transform>();
	}

	private void Start()
	{
		LeverController.AddLeverListener(this);
		SetInitialValues();
	}

	public void OnStateChanged(LeverState state)
	{
		switch (state)
		{
			case LeverState.On:
				AnimateEnter();
				break;
			case LeverState.Off:
				AnimateExit();
				break;
			default:
				throw new ArgumentOutOfRangeException(nameof(state), state, null);
		}
	}

	private void AnimateEnter()
	{
		Sequence seq = DOTween.Sequence();

		seq.AppendCallback(() =>
		{
			gameObject.SetActive(true);
		});
		seq.Append(Transform.DOScale(Vector3.one, 0.14f));

		seq.Play();
	}

	private void AnimateExit()
	{
		Sequence seq = DOTween.Sequence();
		
		seq.Append(Transform.DOScale(Vector3.zero, 0.14f));
		seq.AppendCallback(() =>
		{
			gameObject.SetActive(false);
		});
		seq.Play();
	}

	private void SetInitialValues()
	{
		if (InitialState)
		{
			Transform.localScale = Vector3.one;
			gameObject.SetActive(true);
		}
		else
		{
			Transform.localScale = Vector3.zero;
			gameObject.SetActive(false);
		}
	}
}
