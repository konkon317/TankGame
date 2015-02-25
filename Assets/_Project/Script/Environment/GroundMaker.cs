using UnityEngine;
using System.Collections;

public class GroundMaker : MonoBehaviour {

    [SerializeField]
    Transform tank;

    GameObject GroundPrefab;
	Ground GroundPrefabComp;

    [SerializeField]
    Vector3 newGroundPosition;

    void Awake()
    {
		if (DebugManager.FunctionLog)
		{
			Debug.Log(this.ToString() + " Awake");
		}

        GroundPrefab = Resources.Load<GameObject>(ResourcesPath.Prefab_Ground);
		GroundPrefabComp = GroundPrefab.GetComponent<Ground>();

    }

	// Use this for initialization
	void Start () 
    {
		if (DebugManager.FunctionLog)
		{
			Debug.Log(this.ToString() + " Start");
		}

        Initialize();
	}
	
	// Update is called once per frame
	void Update () 
    {
        while (tank.transform.position.x + (GroundPrefabComp.Size*2) > newGroundPosition.x)
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

        newGroundPosition +=  new Vector3(GroundPrefabComp.Size, 0f, 0f);

    }

    void Initialize()
    {
        newGroundPosition = new Vector3(GroundPrefabComp.Size * 2, 0f, 0f);

    }
}
