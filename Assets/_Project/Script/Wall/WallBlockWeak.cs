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

        GameObject detornator = (GameObject)Instantiate(DetonatorPrefab);
        detornator.transform.position = this.transform.position;

        Destroy(parent.gameObject, 5f);
    }
}
