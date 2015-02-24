using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
	[SerializeField]
	UILabel meters;
	[SerializeField]
	public UILabel walls;

	int crashedWallsCount;

	[SerializeField]
	GameObject tank;

	void Awake()
	{
		crashedWallsCount = 0;
	}

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		meters.text = tank.transform.position.x.ToString("N2") + " M";
		walls.text = crashedWallsCount.ToString() + " walls";
	
	}

	public void CountUp_CrashWallCounter()
	{
		crashedWallsCount++;
	}
}
