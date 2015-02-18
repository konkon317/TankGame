using UnityEngine;
using System.Collections;

public class WallBlockCube : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (rigidbody.velocity.magnitude>1)
        {
           // Collider collider = GetComponent<Collider>();
           // collider.enabled = false;
        }
	}
}
