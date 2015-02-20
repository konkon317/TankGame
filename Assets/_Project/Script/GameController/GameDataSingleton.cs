using UnityEngine;
using System.Collections;

public class GameDataSingleton : MonoBehaviour 
{
	int counter = 0;

	static GameDataSingleton instance;
	public static GameDataSingleton Instance
	{
		get 
		{
			if(instance==null)
			{
				GameObject go = new GameObject("GameData");
				instance = go.AddComponent<GameDataSingleton>();
				DontDestroyOnLoad(go);
			}

			return instance;
		}
	}

	public GameController.GameSequence StartSeq { get { return startSeq; } }
	GameController.GameSequence startSeq=GameController.GameSequence.Restart;

	/// <summary>
	/// シーンをりロードした際の開始シーケンスを指定します
	/// </summary>
	/// <param name="seq">Title タイトル画面から開始 : Rady ゲームスタート準備から開始</param>
	public void SetStartSeq(GameController.GameSequence seq)
	{
		if (seq == GameController.GameSequence.Title || seq == GameController.GameSequence.Restart)
		{
			startSeq = seq;
		}
		else
		{
			Debug.LogError(this.ToString() + "SetStartSeq:  seq is not title or rady");
		}
	}

	void OnEnable()
	{
		if (DebugManager.FunctionLog)
		{
			Debug.Log(this.ToString() + " OnEnable");
		}
	}

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
