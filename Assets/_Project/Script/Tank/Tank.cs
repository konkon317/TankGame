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

	void Awake()
	{
		muzzle = GetComponentInChildren<TankMuzzle>();
		barrelSupport = GetComponentInChildren<TankBarrelSupport>();
		buttonFire.SetDelegate_OnPressFunction(muzzle.Fire);

        MaxVelocity = new Vector3(MaxSpeed, 0, 0);
	}

	void Start()
	{
       
	}

	void Update()
	{
		barrelSupport.ChangeAngle(burrelAngleSlider.sliderValue);

        rigidbody.AddForce(new Vector3(2f, 0f, 0f)  *rigidbody.mass,ForceMode.Impulse);
        if (rigidbody.velocity.magnitude > MaxVelocity.magnitude)
        {
            rigidbody.velocity = MaxVelocity;
        }
	}

	
	

}
