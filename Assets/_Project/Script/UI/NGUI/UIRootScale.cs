using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class UIRootScale : MonoBehaviour 
{

	public int manualWidth = 1280;
	public int manualHeight = 720;

	UIRoot uiRoot;

	public float raito
	{
		get {
			if (!uiRoot)
			{ return 1f; }

			return (float)Screen.height / uiRoot.manualHeight;
		}
	}

	void Awake()
	{
		uiRoot = GetComponent<UIRoot>();
	}

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (!uiRoot || manualWidth <= 0 || manualHeight <= 0) { return; }

		int h = manualHeight;
		float r = (float)(Screen.height * manualWidth) / (Screen.width * manualHeight);
		if (r > 1.0f) { h = (int)(h * r); }

		if (uiRoot.scalingStyle != UIRoot.Scaling.FixedSize) { uiRoot.scalingStyle = UIRoot.Scaling.FixedSize; }
		if (uiRoot.manualHeight != h) { uiRoot.manualHeight = h; }
		if (uiRoot.minimumHeight > 1) { uiRoot.minimumHeight = 1; }
		if (uiRoot.maximumHeight < System.Int32.MaxValue) { uiRoot.maximumHeight = System.Int32.MaxValue; }

	
	}
}
