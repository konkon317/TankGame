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

	Vector3 relPos;
	// Use this for initialization
	void Start () 
	{
		relPos = this.transform.position - targetObject.position;
	}
	
	// Update is called once per frame
	void Update () 
	{
		this.transform.position = targetObject.position + relPos;
	}
}
