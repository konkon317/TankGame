using UnityEngine;
using System.Collections;

public class WallBlockWeak : MonoBehaviour {

    public GameObject DetonatorPrefab;

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    public void OnHit()
    {

        WallParent parent = GetComponentInParent<WallParent>();
        parent.DisableKinematicsAllBlock();
		parent.Crashed = true ;

        GameObject detonator = (GameObject)Instantiate(DetonatorPrefab);
        detonator.transform.position = this.transform.position;

		detonator.transform.parent = GameObject.FindWithTag(Tags.DetonatorParent).transform;

        Destroy(parent.gameObject, 5f);
    }
}
