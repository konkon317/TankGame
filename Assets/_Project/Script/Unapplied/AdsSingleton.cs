using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine.Advertisements;
using UnityEngine;

class AdsSingleton
{
	public static AdsSingleton GetInstance
	{
		get 
		{
			if (instance == null)
			{
				instance = new AdsSingleton();	
			}

			return instance;
		}
	}
	static AdsSingleton instance;

	int counter;


	private AdsSingleton()
	{
		Debug.Log("adsInitialize");
		counter = 2;
		Advertisement.Initialize("23974",true);
	}

	public void Show()
	{
		counter--;
		if (counter == 0)
		{
			counter = 2;
			Advertisement.Show();
		}
	}
}

