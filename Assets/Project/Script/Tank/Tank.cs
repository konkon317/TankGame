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
	

	void Awake()
	{
		muzzle = GetComponentInChildren<TankMuzzle>();
		barrelSupport = GetComponentInChildren<TankBarrelSupport>();
		buttonFire.SetDelegate_OnPressFunction(muzzle.Fire);
	}

	void Start()
	{
		
	}

	void Update()
	{
		barrelSupport.ChangeAngle(burrelAngleSlider.sliderValue);
	}

	
	

}
