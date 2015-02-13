using UnityEngine;
using System.Collections;

public class GroundMaker : MonoBehaviour {

    [SerializeField]
    Transform tank;

    GameObject GroundPrefab;

    [SerializeField]
    Vector3 newGroundPosition;

    void Awake()
    {
        GroundPrefab = Resources.Load<GameObject>(ResourcesPath.Prefab_Ground);

    }

	// Use this for initialization
	void Start () 
    {

        Initialize();
	}
	
	// Update is called once per frame
	void Update () 
    {
        while (tank.transform.position.x + (GroundPrefab.transform.transform.localScale.x*2) > newGroundPosition.x)
        {
            Make();
        }
	}

    void Make()
    {
        GameObject obj = (GameObject)Instantiate(GroundPrefab);
        obj.transform.position = newGroundPosition;
        obj.transform.parent = this.transform;

        Ground g = obj.GetComponent<Ground>();
        g.SetTankTransform(tank);

        newGroundPosition +=  new Vector3(GroundPrefab.transform.localScale.x, 0f, 0f);

    }

    void Initialize()
    {
        newGroundPosition = new Vector3(GroundPrefab.transform.localScale.x * 2, 0f, 0f);

    }
}
