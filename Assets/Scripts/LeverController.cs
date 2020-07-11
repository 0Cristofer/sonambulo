using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class LeverController : MonoBehaviour
{
	[SerializeField]
	private LeverState InitialState = LeverState.Off;
	[SerializeField]
	private GameObject Pivot = null;

	private Transform PivotTransform { get; set; }
	private bool Animating { get; set; }
	
	private LeverState CurrentState { get; set; }
	private LeverState PreviousState { get; set; }
	private List<ILeverListener> Listeners { get; set; }

	private void Awake()
	{
		PivotTransform = Pivot.GetComponent<Transform>();
		CurrentState = InitialState;
		PreviousState = InitialState == LeverState.Off ? LeverState.On : LeverState.Off;
		Animating = false;
		Listeners = new List<ILeverListener>();
	}

	public void AddLeverListener(ILeverListener listener)
	{
		Listeners.Add(listener);
	}

	private void OnMouseUpAsButton()
	{
		if (Animating)
			return;
		
		Animate(ChangeState);
	}

	private void Animate(Action onComplete = null)
	{
		Sequence seq = DOTween.Sequence();
		float rotation = PivotTransform.localEulerAngles.z + (CurrentState == LeverState.Off ? -120f : 120f);

		seq.AppendCallback(() =>
		{
			Animating = true;
		});
		seq.Append(PivotTransform.DOLocalRotate(new Vector3(0, 0, rotation), 0.15f));
		seq.OnComplete(() => onComplete?.Invoke());
		seq.AppendCallback(() =>
		{
			Animating = false;
		});
		
		seq.Play();
	}

	private void ChangeState()
	{
		PreviousState = CurrentState;
		CurrentState = CurrentState == LeverState.Off ? LeverState.On : LeverState.Off;
		FireEvent();
	}

	private void FireEvent()
	{
		foreach (ILeverListener listener in Listeners)
		{
			listener.OnStateChanged(CurrentState);
		}
	}

	private void OnDestroy()
	{
		Listeners.Clear();
	}
}

public enum LeverState
{
	On = 0,
	Off
}

public interface ILeverListener
{
	void OnStateChanged(LeverState state);
}
