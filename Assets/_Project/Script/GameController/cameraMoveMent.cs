using UnityEngine;
using System.Collections;

/// <summary>
/// カメラに付けるコンポーネント
/// targetObjectとの距離を一定に保つように移動する
/// </summary>
public class cameraMoveMent : MonoBehaviour 
{
	
	[SerializeField]
	Transform targetObject;

	[SerializeField]
	float nearZ=-30;
	[SerializeField]
	float farZ=-35;


	Vector3 relPos;

	
	float ScreenLastRaito;

	void Awake()
	{
		float raito_16_9 = 16f / 9f;
		float raito_4_3 = 4f / 3f;

		float ScreenRaito = (float)Screen.width / (float)Screen.height;

		Debug.Log("screenraito " + ScreenRaito.ToString());

		if (ScreenRaito <= raito_4_3)
		{
			transform.position = new Vector3(transform.position.x, transform.position.y,farZ);
		}
		else if (ScreenRaito >= raito_16_9)
		{
			transform.position = new Vector3(transform.position.x, transform.position.y, nearZ);
		}
		else 
		{
			Debug.Log("test");
			float deferenceZ = farZ - nearZ;

			bool flag = false;
			if (deferenceZ < 0)
			{
				deferenceZ *= -1;
				flag = true;
			}

			float p = (ScreenRaito - raito_4_3) / (raito_16_9 - raito_4_3);
			
			float posZ;

			Debug.Log(p);

			if (flag)
			{
				posZ = nearZ - (deferenceZ * p);
			}
			else
			{
				posZ = nearZ + (deferenceZ * p);
			}

			transform.position = new Vector3(transform.position.x, transform.position.y, posZ);
			
		}


	}
	// Use this for initialization
	void Start () 
	{
		if (DebugManager.FunctionLog)
		{
			Debug.Log(this.ToString() + " Start");
		}

		relPos = this.transform.position - targetObject.position;
	}
	
	// Update is called once per frame
	void Update () 
	{
		this.transform.position = targetObject.position + relPos;
		//UpdateRaito();
	}

	/*
	void UpdateRaito()
	{ 
		float ScreenRaito=ScreenRaito = (float)Screen.width / (float)Screen.height;
		
		if (ScreenRaito != ScreenLastRaito)
		{
			float raito_16_9 = 16f / 9f;
			float raito_4_3 = 4f / 3f;

			Debug.Log("screenraito " + ScreenRaito.ToString());

			if (ScreenRaito <= raito_4_3)
			{
				relPos = new Vector3(relPos.x, relPos.y, farZ);
			}
			else if (ScreenRaito >= raito_16_9)
			{
				relPos = new Vector3(relPos.x, relPos.y, nearZ);
			}
			else
			{
				Debug.Log("test");
				float deferenceZ = farZ - nearZ;

				bool flag = false;
				if (deferenceZ < 0)
				{
					deferenceZ *= -1;
					flag = true;
				}

				float p = (ScreenRaito - raito_4_3) / (raito_16_9 - raito_4_3);

				float posZ;

				Debug.Log(p);

				if (flag)
				{
					posZ = nearZ - (deferenceZ * p);
				}
				else
				{
					posZ = nearZ + (deferenceZ * p);
				}

				relPos = new Vector3(relPos.x, relPos.y, posZ);

			}
		}
	}*/
}
