using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScreenFader : MonoBehaviour
{
	public enum State
	{ 
		Clear,
		Black,
		ToBlack,
		ToClear
	}

	public Color Color { get { return image.color; } }
	Image image;
	RectTransform rectTransform;

	[SerializeField]
	float spendTime;

	State state=State.ToClear;

	// Use this for initialization
	void Awake()
	{
		image = GetComponent<Image>();
		rectTransform = GetComponent<RectTransform>();
		rectTransform.sizeDelta = new Vector2(Screen.width, Screen.height);
	}
	
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		switch (state)
		{ 
			case State.ToBlack:
				ToBlack();
				break;
			case State.ToClear:
				ToClear();
				break;
		}
	
	}

	void ToBlack()
	{
		if (spendTime > 0)
		{
			image.color = Color.Lerp(image.color, Color.black, (1f / spendTime) * Time.deltaTime);
			if (image.color.a > 0.9f) image.color = Color.black;
		}
		else
		{
			image.color = Color.black;
		}

		if (image.color == Color.black)
		{
			state = State.Black;
		}
	}


	void ToClear()
	{

		if (spendTime > 0)
		{
			image.color = Color.Lerp(image.color, Color.clear, (1f / spendTime) * Time.deltaTime);
			if (image.color.a < 0.1f) image.color = Color.clear;
		}
		else
		{
			image.color = Color.clear;
		}

		if (image.color == Color.clear)
		{
			state = State.Clear;
		}
	}

	public void  SetStateClear()
	{
		image.color=Color.clear;
		state = State.Clear;
	}

	public void SetStateBlack()
	{
		image.color=Color.black;
		state = State.Black;
	}

	public void SetStateFadeToClear()
	{
		state = State.ToClear;
	}

	public void SetStateFadeToBlack()
	{
		state = State.ToBlack;
	}



}
