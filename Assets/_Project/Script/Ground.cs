using UnityEngine;
using System.Collections;

public class Ground : MonoBehaviour 
{

    [SerializeField]
    Transform tank;
	// Use this for initialization
	void Start () 
    {
	    
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (this.transform.position.x + (this.transform.localScale.x * 2) < tank.position.x)
        {
            Destroy(this.gameObject);
        }
	}

    public void SetTankTransform(Transform target)
    {
        this.tank = target;
    }
}
