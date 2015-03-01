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

    const string android="23974";
    const string ios="23981";

	int counter;


	private AdsSingleton()
	{
		Debug.Log("adsInitialize");
		counter = 2;
        Advertisement.Initialize(ios,true);
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

