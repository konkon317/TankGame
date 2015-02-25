using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
	[SerializeField]
	UILabel meters;
	[SerializeField]
	public UILabel walls;


	public float Meters
	{
		get
		{
			return tank.transform.position.x;
		}
	}

	public int CrashedWalls{get {return crashedWalls;}}
	int crashedWalls;

	[SerializeField]
	GameObject tank;

	void Awake()
	{
		crashedWalls = 0;
	}

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
			
	}

	public void CountUp_CrashWallCounter()
	{
		crashedWalls++;
	}

	


}
