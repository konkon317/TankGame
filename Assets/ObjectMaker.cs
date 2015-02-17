using UnityEngine;
using System.Collections;

public class ObjectMaker : MonoBehaviour 
{

	[SerializeField]
	GameObject Prefab;

	/// <summary>
	/// 作成したオブジェクトの親オブジェクトを設定します
	/// </summary>
	Transform Parent { get { return parent; } set { parent = value; } }
	[SerializeField]
	Transform parent;


	[SerializeField]
	bool useRandomPos=false;

	[SerializeField]
	bool makeOneTime;

	[SerializeField]
	float intervalSec=1f;
	float intervalTimer=0f;

	[SerializeField]
	float RangeXLow=0;
	[SerializeField]
	float RangeXHigh=0;
	[SerializeField]
	float RangeYLow=0;
	[SerializeField]
	float RangeYHigh=0;
	[SerializeField]
	float RangeZLow=0;
	[SerializeField]
	float RangeZHigh=0;



	// Use this for initialization
	void Start () 
	{
		Make();
		intervalTimer = intervalSec;

	}
	
	// Update is called once per frame
	void Update () 
	{
		if (!makeOneTime)
		{
			intervalTimer -= Time.deltaTime;
			if (intervalTimer < 0f)
			{
				intervalTimer += intervalSec;
				Make();
			}
		}
	}

	void Make()
	{ 
		Vector3 makePos;
		if (useRandomPos)
		{
			float x = Random.Range(RangeXLow, RangeXHigh);
			float y= Random.Range(RangeYLow, RangeYHigh);
			float z = Random.Range(RangeZLow, RangeZHigh);
			makePos = this.transform.position+new Vector3(x,y,z);
		}
		else 
		{
			makePos = this.transform.position; 
		}

		GameObject obj = (GameObject)Instantiate(Prefab);
		obj.transform.position = makePos;
		obj.transform.parent = Parent;

	}

}
