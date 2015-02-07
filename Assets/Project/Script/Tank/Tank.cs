using UnityEngine;
using System.Collections;

public class Tank : MonoBehaviour 
{
	GameObject bulletPrefab;

	[SerializeField]
	NGUIButton buttonFire;

	public Transform muzzle;
	public Transform BulletsParent;

	void Awake()
	{
		bulletPrefab = Resources.Load<GameObject>(ResourcesPath.Prefab_Bullet);
		buttonFire.SetDelegate_OnPressFunction(Fire);
	}

	void Start()
	{
		
	}

	void Update()
	{
		//Fire();
	}

	/// <summary>
	/// 発砲します
	/// </summary>
	public void Fire()
	{
		
		GameObject obj = (GameObject)Instantiate(bulletPrefab);
		obj.transform.position=muzzle.position;
		obj.transform.Rotate(muzzle.rotation.eulerAngles);
		
		

		Vector3 tankScale=this.transform.localScale;
		Vector3 defaultScale=obj.transform.localScale;
		obj.transform.localScale = new Vector3(defaultScale.x * tankScale.x, defaultScale.y * tankScale.y, defaultScale.z * tankScale.z);
		
		Rigidbody rigidbody = obj.rigidbody;
		rigidbody.AddForce(muzzle.forward* 800);

		obj.transform.parent = BulletsParent;
	}

}
