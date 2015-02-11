using UnityEngine;
using System.Collections;

public class WallCreater : MonoBehaviour 
{
	const int WallMax=15;
	const int WeakPointRange = 7;

	GameObject WallBlcok_Prefab;
	GameObject WallBlockWeak_Prefab;

	bool isCreated = false;

	void Awake()
	{
		WallBlcok_Prefab = Resources.Load<GameObject>(ResourcesPath.Prefab_WallBlcok);
		WallBlockWeak_Prefab = Resources.Load<GameObject>(ResourcesPath.Prefab_WallBlockWeak);
	
	}

	
	void Start () 
	{
		Create();
	}
	
	void Update () 
	{
	
	}


	/// <summary>
	/// 壁を作成します
	/// </summary>
	void Create()
	{
		if (!isCreated)
		{
			int rand = Random.Range(0, WeakPointRange);

			for (int i = 0; i < WallMax; i++)
			{
				GameObject prefab;
				if (i == rand)
				{
					prefab = WallBlockWeak_Prefab;
				}
				else
				{
					prefab = WallBlcok_Prefab;
				}

				GameObject obj = (GameObject)Instantiate(prefab);
				obj.transform.position = this.transform.position + (new Vector3(0, i, 0));

				obj.transform.parent = transform;
			}
			isCreated = true;
		}
	}
}
