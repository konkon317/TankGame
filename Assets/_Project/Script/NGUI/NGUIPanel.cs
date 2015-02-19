using UnityEngine;
using System.Collections;

public enum UIPanelState
{ 
	FadeIn,
	FadeOut,
	Display,
	Hidden
}

public class NGUIPanel : MonoBehaviour
{
	UIPanel panel;

	public UIPanelState State { get { return state; } }
	[SerializeField]
	public UIPanelState state;

	[SerializeField]
	float maxAlpha=1;

	[SerializeField]
	float spendTimeFadeInOut=1;

	void Awake()
	{
		panel = GetComponent<UIPanel>();

		if (maxAlpha > 1)
		{
			maxAlpha = 1f;
		}

		if (maxAlpha < 0)
		{
			Debug.LogError("default alpha < 0");
		}

		if (panel.alpha > maxAlpha)
		{
			panel.alpha = maxAlpha;
		}

		if (panel.alpha > 0)
		{
			state = UIPanelState.Display;
		}
		else
		{
			state = UIPanelState.Hidden;
		}
	}

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		switch (State)
		{ 
			case UIPanelState.FadeIn:
				FadeIn();
				break;
			case UIPanelState.FadeOut:
				FadeOut();
				break;
		}
		
	}

	/// <summary>
	/// 
	/// </summary>
	public void SetStateFadeIn()
	{
		if (State == UIPanelState.Hidden)
		{
			SetState(UIPanelState.FadeIn);
		}
	}

	/// <summary>
	/// 
	/// </summary>
	public void SetStateFadeOut()
	{
		if (State == UIPanelState.Display)
		{
			SetState(UIPanelState.FadeOut);
		}
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="state"></param>
	void SetState(UIPanelState state)
	{
		this.state = state;
	}

	/// <summary>
	/// 
	/// </summary>
	void FadeIn()
	{
		if (state == UIPanelState.FadeIn)
		{
			if (spendTimeFadeInOut == 0)
			{
				panel.alpha = maxAlpha;
			}
			else if (spendTimeFadeInOut > 0)
			{
				float f = (maxAlpha / spendTimeFadeInOut) * Time.deltaTime;
				panel.alpha += f;
			}
			else
			{
				Debug.Log(this.ToString()+"fadeIn()  spend time < 0");
			}

			if (panel.alpha >= maxAlpha)
			{
				SetState(UIPanelState.Display);
				panel.alpha = maxAlpha;
			}

		}
	}

	/// <summary>
	/// 
	/// </summary>
	void FadeOut()
	{
		if (state == UIPanelState.FadeOut)
		{
			if (spendTimeFadeInOut == 0)
			{
				panel.alpha = 0;
			}
			else if (spendTimeFadeInOut > 0)
			{
				float f = (maxAlpha / spendTimeFadeInOut) * Time.deltaTime;
				panel.alpha -= f;
			}
			else
			{
				Debug.Log(this.ToString() + "fadeIn()  spend time < 0");
			}

			if (panel.alpha <= 0)
			{
				SetState(UIPanelState.Hidden);
				panel.alpha = 0;
			}
		}
	}


}
