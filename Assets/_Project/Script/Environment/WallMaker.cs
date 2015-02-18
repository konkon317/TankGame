using UnityEngine;
using System.Collections;

public class WallMaker : MonoBehaviour 
{

	GameObject wallPrefab;

	[SerializeField]
	Transform tank;

	[SerializeField]
	float firstX=45;

	[SerializeField]
	float interval=10;

	[SerializeField]
	float createLengeX=30;

	[SerializeField]
	Vector3 createPosition;

	void Awake()
	{
		if (DebugManager.FunctionLog)
		{
			Debug.Log(this.ToString()+" Awake");
		}

		wallPrefab = Resources.Load<GameObject>(ResourcesPath.Prefab_Wall);
		Initialize();
	}

	// Use this for initialization
	void Start () 
	{
		if (DebugManager.FunctionLog)
		{
			Debug.Log(this.ToString() + " Start");
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (interval > 0)
		{
			while (tank.transform.position.x + createLengeX > createPosition.x)
			{
				Make();
			}
		}
	}

	void Initialize()
	{
		createPosition = new Vector3(firstX, 1, 0);
		if (interval > 0)
		{
			while (tank.transform.position.x + createLengeX > createPosition.x)
			{
				Make();
			}
		}
	}

	void Make()
	{
		GameObject obj = (GameObject)Instantiate(wallPrefab);
		obj.transform.position = createPosition;
		obj.transform.parent = this.transform;
		createPosition += new Vector3(interval, 0, 0);
	}


}
