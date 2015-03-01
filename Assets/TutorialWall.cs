using UnityEngine;
using System.Collections;

public class TutorialWall : MonoBehaviour 
{
	GameController gameController;
	WallParent wall;
	void Awake()
	{
		gameController = GameObject.FindWithTag(Tags.GameController).GetComponent<GameController>();
		wall = GetComponent<WallParent>();
	}

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (wall.Crashed == true)
		{
			gameController.SetGameOverFlag();
		}
	}
}
