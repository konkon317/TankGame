using UnityEngine;
using System.Collections;

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
