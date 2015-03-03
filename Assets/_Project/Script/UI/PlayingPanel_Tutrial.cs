using UnityEngine;
using System.Collections;

public class PlayingPanel_Tutrial : MonoBehaviour
{
	bool flag = false;

	Animator animator;
	GameController gameController;
	NGUIPanel panel;

	void Awake()
	{
		animator = GetComponent<Animator>();
		gameController = GameObject.FindWithTag(Tags.GameController).GetComponent<GameController>();
		panel = GetComponent<NGUIPanel>();
	}

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (flag == false)
		{
			if (gameController.Sequence == GameController.GameSequence.Playing)
			{
				if (panel.state == UIPanelState.Display)
				{
					flag = true;
					animator.SetTrigger(HashIDs.TutrialStarted_Trigger);
				}
			}
		}
	
	}
}
