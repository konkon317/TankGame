﻿using UnityEngine;
using System.Collections;

public class TankMuzzle : MonoBehaviour 
{

	GameObject bulletPrefab;
	Transform bulletsParent;
	Tank tank;

    FiringManager firingManager;

	[SerializeField]
    AudioSource fireSe;

	float point;

	void Awake()
	{
		if (DebugManager.FunctionLog)
		{
			Debug.Log(this.ToString() + " Awake");
		}

        firingManager = GameObject.FindWithTag(Tags.GameController).GetComponent<FiringManager>();

		bulletPrefab = Resources.Load<GameObject>(ResourcesPath.Prefab_Bullet);
        //fireSe = GetComponent<AudioSource>();

		bulletsParent = GameObject.FindWithTag(Tags.BulletsParent).transform;
		tank = this.GetComponentInParent<Tank>();
	}

	// Use this for initialization
	void Start () 
	{
		if (DebugManager.FunctionLog)
		{
			Debug.Log(this.ToString() + " Start");
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	/// <summary>
	/// 発砲します
	/// </summary>
	public void Fire()
	{
        if(firingManager.CanFire())
        {
            firingManager.OnFire();
            fireSe.Play();

            GameObject obj = (GameObject)Instantiate(bulletPrefab);	//プリファブからクローンを作成
            obj.transform.position = transform.position;			//位置の設定
            obj.transform.Rotate(transform.rotation.eulerAngles);	//弾の向きを設定
		
            //大きさの設定
            Vector3 tankScale = tank.transform.localScale;
            Vector3 defaultScale = obj.transform.localScale;
            //obj.transform.localScale = new Vector3(defaultScale.x * tankScale.x, defaultScale.y * tankScale.y, defaultScale.z * tankScale.z);

            //力をかけて弾を飛ばす
            obj.rigidbody.AddForce(transform.forward * 2000 * obj.rigidbody.mass);
	
            //弾の親オブジェクトを設定
            //（ヒエラルキービューを見やすくするために）
            obj.transform.parent = bulletsParent;


        }
	}
}
