using UnityEngine;
using System.Collections;

public class WallBlockCubeWeak : MonoBehaviour 
{
	

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

    void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == Tags.Bullet)
        {
            WallBlockWeak parent = GetComponentInParent<WallBlockWeak>();
            parent.OnHit();

		
        }
    }

   
}
