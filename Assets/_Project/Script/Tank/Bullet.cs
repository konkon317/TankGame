using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour 
{
    [SerializeField]
    GameObject detonatorPrefab;

	// Use this for initialization
	void Start () 
    {
        Destroy(this.gameObject, 5f);	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision collision)
    {
        string tag = collision.collider.tag;

        if (tag == Tags.WallBlockCube || tag == Tags.Ground)
        {
            GameObject obj = (GameObject)Instantiate(detonatorPrefab);
            obj.transform.position = this.transform.position;

			obj.transform.parent = GameObject.FindWithTag(Tags.DetonatorParent).transform;

            Destroy(this.gameObject);

        }
        else
        {
            if (tag == Tags.WallBlockCubeWeak)
            {
                Destroy(this.gameObject);
            }
        }
    }

}
