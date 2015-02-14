using UnityEngine;
using System.Collections;

public class Tank : MonoBehaviour 
{
	

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

	void Awake()
	{
		muzzle = GetComponentInChildren<TankMuzzle>();
		barrelSupport = GetComponentInChildren<TankBarrelSupport>();
		buttonFire.SetDelegate_OnPressFunction(muzzle.Fire);

        MaxVelocity = new Vector3(MaxSpeed, 0, 0);
		barrelAngle = 0f;
	}

	void Start()
	{
       
	}

	void Update()
	{
		//ChangeAngele();
		barrelSupport.ChangeAngle(burrelAngleSlider.sliderValue);
		//barrelSupport.ChangeAngle(barrelAngle);

        rigidbody.AddForce(new Vector3(2f, 0f, 0f)  *rigidbody.mass,ForceMode.Impulse);
        if (rigidbody.velocity.magnitude > MaxVelocity.magnitude)
        {
            rigidbody.velocity = MaxVelocity;
        }

		if (Input.GetKeyDown(KeyCode.Return))
		{
			muzzle.Fire();
		}
	}

	void ChangeAngele()
	{

		barrelAngle += Input.GetAxis("Vertical")  * Time.deltaTime*1.5f;

		if (barrelAngle > 1) barrelAngle = 1;
		if (barrelAngle < 0) barrelAngle = 0;
	}
	
	

}
