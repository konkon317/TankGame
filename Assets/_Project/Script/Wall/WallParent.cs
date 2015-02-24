using UnityEngine;
using System.Collections;

public class WallParent : MonoBehaviour 
{
    const int WallMax = 20;
    const int WeakPointRange = 10;

	GameObject WallBlcok_Prefab;
	GameObject WallBlockWeak_Prefab;

	ScoreManager scoreManager;

	public bool Crashed = false;
	int counter = 0;
	  
	bool isCreated = false;

	void Awake()
	{
		if (DebugManager.FunctionLog)
		{
			Debug.Log(this.ToString() + " Awake");
		}

		WallBlcok_Prefab = Resources.Load<GameObject>(ResourcesPath.Prefab_WallBlcok);
		WallBlockWeak_Prefab = Resources.Load<GameObject>(ResourcesPath.Prefab_WallBlockWeak);

		scoreManager = GameObject.FindWithTag("GameController").GetComponent<ScoreManager>();
	
	}

	
	void Start () 
	{
		if (DebugManager.FunctionLog)
		{
			Debug.Log(this.ToString() + " Start");
		}

		Create();
	}
	
	void Update () 
	{
		if (Crashed)
		{			
			if (counter == 2)
			{
				DisableColliderAllBlock();
				Destroy(gameObject, 5f);
				scoreManager.CountUp_CrashWallCounter();
			}

			counter++;
		}
	
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
				Vector3 Scale = prefab.transform.lossyScale;
				obj.transform.position = this.transform.position + (new Vector3(0, i*Scale.y+(Scale.y/2), 0));

				obj.transform.parent = transform;
			}
			isCreated = true;
		}
	}

    public void DisableKinematicsAllBlock()
    {
        Rigidbody[] rididbodys = GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody r in rididbodys)
        {
            r.isKinematic = false;           
        }

    }

	public void DisableColliderAllBlock()
	{
		Collider[] colliders = GetComponentsInChildren<Collider>();
		foreach (Collider c in colliders)
		{
			c.enabled = false;
		}
	}
}
