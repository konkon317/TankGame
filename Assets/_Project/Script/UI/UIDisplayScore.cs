using UnityEngine;
using System.Collections;

public class UIDisplayScore: MonoBehaviour 
{
	public enum ScoreType
	{ 
		Meters,
		Walls,
	}

	[SerializeField]
	ScoreType scoreType;

	public string before;
	public string behind;

	UILabel label;
	ScoreManager scoreManager;

	void Awake()
	{
		label = GetComponent<UILabel>();
		scoreManager = GameObject.FindWithTag(Tags.GameController).GetComponent<ScoreManager>();
	}

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		switch(scoreType)
		{
			case ScoreType.Meters:
				label.text = before + scoreManager.Meters.ToString("N2") + behind;
			break;

			case ScoreType.Walls:
				label.text = before + scoreManager.CrashedWalls.ToString() + behind;
			break;
		}
	}
}
