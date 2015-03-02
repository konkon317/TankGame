using UnityEngine;
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
	GameInputManager gameInputManager;

	Animator animator;

	/// <summary>
	/// 戦車が壊れているか(ゲームオーバーの条件)
	/// </summary>
	public bool IsCrashed { get { return isCrashed; } }
	bool isCrashed;


	void Awake()
	{
		animator = GetComponent<Animator>();

		gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
		gameInputManager = GameObject.FindWithTag("GameController").GetComponent<GameInputManager>();
	
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

	void LateUpdate()
	{
		if (gameController.Sequence==GameController.GameSequence.Playing)
		{

			if (!gameController.IsTutorial)
			{
				rigidbody.AddForce(new Vector3(5f, 0f, 0f) * rigidbody.mass * Time.deltaTime, ForceMode.Impulse);
				if (rigidbody.velocity.magnitude > MaxVelocity.magnitude)
				{
					rigidbody.velocity = MaxVelocity;
				}
			}

			ChangeAngele();
			//barrelSupport.ChangeAngle(burrelAngleSlider.sliderValue);
			barrelSupport.ChangeAngle(barrelAngle);

		/*	if (Input.GetKeyDown(KeyCode.Return))
			{
				muzzle.Fire();
			}*/
		}
	}

	void ChangeAngele()
	{
		float defY=gameInputManager.DeferencePositionY_FromLastFrame;
		barrelAngle += (float)(defY/Screen.height)*1.5f;

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
		this.animator.SetTrigger(HashIDs.Crash_Trigger);
		rigidbody.velocity = Vector3.zero;
		rigidbody.isKinematic = true;
		crashEfect.SetActive(true);

		gameController.SetGameOverFlag();
	}


}
