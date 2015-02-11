using UnityEngine;
using System.Collections;

public class TankBarrelSupport : MonoBehaviour 
{
	[SerializeField]
	float MaxAngle = 60;
	
	float lastPoint=0;

	void Awake()
	{

	}

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	/// <summary>
	///角度を変更します
	/// </summary>
	/// <param name="point">最大角度の何パーセントか</param>
	public void ChangeAngle(float point)
	{
		if (point < 0 || point > 1) return;

		if (point != lastPoint)
		{
			Vector3 newRotation = new Vector3(MaxAngle * (point-lastPoint) * -1, 0, 0);
			transform.Rotate(newRotation);

			lastPoint = point;
		}

	}
}
