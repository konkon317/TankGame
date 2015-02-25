using UnityEngine;
using System.Collections;

public class Ground : MonoBehaviour 
{

    [SerializeField]
    Transform tank;

	[SerializeField]
	float size;
	public float Size { get { return size;} }

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
        if (this.transform.position.x + (Size* 2) < tank.position.x)
        {
            Destroy(this.gameObject);
        }
	}

    public void SetTankTransform(Transform target)
    {
        this.tank = target;
    }
}
