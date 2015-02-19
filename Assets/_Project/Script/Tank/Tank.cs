﻿using UnityEngine;
using System.Collections;

public class Tank : MonoBehaviour 
{

	[SerializeField]
	GameObject crashEfect;

	[SerializeField]
	NGUIButton buttonFire;

	[SerializeField]
	UISlider burrelAngleSlider;

	TankMuzzle muzzle;
	TankBarrelSupport barrelSupport;

    [SerializeField]
    float MaxSpeed;
	
    Vector3 MaxVelocity;

	float barrelAngle;

	GameController gameController;


	/// <summary>
	/// 戦車が壊れているか(ゲームオーバーの条件)
	/// </summary>
	public bool IsCrashed { get { return isCrashed; } }
	bool isCrashed;


	void Awake()
	{
		gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
	
		if (DebugManager.FunctionLog)
		{
			Debug.Log(this.ToString() + " Awake");
		}

		muzzle = GetComponentInChildren<TankMuzzle>();
		barrelSupport = GetComponentInChildren<TankBarrelSupport>();
		buttonFire.SetDelegate_OnPressFunction(muzzle.Fire);

        MaxVelocity = new Vector3(MaxSpeed, 0, 0);
		barrelAngle = 0f;
	}

	void Start()
	{
		if (DebugManager.FunctionLog)
		{
			Debug.Log(this.ToString() + " Start");
		}

		crashEfect.SetActive(false);
		isCrashed = false;
	}

	void Update()
	{
		if (gameController.Sequence==GameController.GameSequence.Playing)
		{

			rigidbody.AddForce(new Vector3(2f, 0f, 0f) * rigidbody.mass, ForceMode.Impulse);
			if (rigidbody.velocity.magnitude > MaxVelocity.magnitude)
			{
				rigidbody.velocity = MaxVelocity;
			}

			ChangeAngele();
			//barrelSupport.ChangeAngle(burrelAngleSlider.sliderValue);
			barrelSupport.ChangeAngle(barrelAngle);

			if (Input.GetKeyDown(KeyCode.Return))
			{
				muzzle.Fire();
			}
		}
	}

	void ChangeAngele()
	{

		barrelAngle += Input.GetAxis("Vertical")  * Time.deltaTime*1.5f;

		if (barrelAngle > 1) barrelAngle = 1;
		if (barrelAngle < 0) barrelAngle = 0;
	}


	void OnCollisionEnter(Collision collision)
	{
		string tag = collision.collider.tag;

		if (tag == Tags.WallBlockCube || tag == Tags.WallBlockCubeWeak)
		{
			if (!IsCrashed)
			{
				Crash();
			}
		}
	}

	void Crash()
	{
		isCrashed = true;
		rigidbody.velocity = Vector3.zero;
		crashEfect.SetActive(true);

		
	}


}
