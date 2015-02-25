using UnityEngine;
using System.Collections;

public class GameInputManager : MonoBehaviour
{

	public enum InputMode
	{ 
		Mouse,
		Touch,
		KeyBord
	}

	int fingerID;

	public bool IsTouching { get { return isTouching; } }
	bool isTouching;

	public float DeferencePositionY_FromLastFrame{get {return defY;}}
	float defY;

	Vector3 lastPos;

	GameController gameController;

	public UILabel DebPosition;
	public UILabel DebLastPos;

	public InputMode inputMode;


	void Awake()
	{
		gameController = GetComponent<GameController>();
	}

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (gameController.Sequence == GameController.GameSequence.Playing)
		{
			defY = 0;
			switch(inputMode)
			{
				case InputMode.Mouse:
					MouseInput();
					break;
				case InputMode.Touch:
					TouchInput();
					break;
				case InputMode.KeyBord:
					KeyBordInput();
					break;
			}	
		}
	}

	void TouchInput()
	{
		if (Input.touchCount > 0)
		{
			for (int i = 0; i < Input.touchCount; i++)
			{
				Touch touch = Input.touches[i];

				if (isTouching)
				{
					if (touch.fingerId == this.fingerID)
					{
						DebPosition.text = touch.position.y.ToString();
						DebLastPos.text = lastPos.y.ToString();

						defY = touch.position.y - lastPos.y;
						lastPos = touch.position;


						if (touch.phase == TouchPhase.Ended)
						{
							//指が離れた瞬間
							isTouching = false;
						}
					}
				}
				else
				{
					//触られた瞬間
					if (touch.phase == TouchPhase.Began)
					{
						if (touch.position.x <= (Screen.width / 2))
						{
							fingerID = touch.fingerId;
							isTouching = true;
							lastPos = touch.position;
						}
					}
				}
			}
		}
	}

	void MouseInput()
	{
		if (IsTouching)
		{
			if (Input.GetMouseButton(0))
			{
				defY = Input.mousePosition.y - lastPos.y;
				lastPos = Input.mousePosition;

			}
			else
			{
				//離れた瞬間
				defY = Input.mousePosition.y- lastPos.y;
				lastPos = Input.mousePosition;

				isTouching = false;
			}
		}
		else 
		{
			if (Input.GetMouseButtonDown(0))
			{
				if (Input.mousePosition.x <= (Screen.width / 2))
				{
					isTouching = true;
					lastPos = Input.mousePosition;
				}
			}
		}
	}

	void KeyBordInput()
	{
		defY = Input.GetAxis("Vertical")*500f*Time.deltaTime;
	}




}
