using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class GameController : MonoBehaviour 
{
	/// <summary>
	/// ゲームの実行状態
	/// </summary>
	public enum GameSequence
	{ 
		Title,
		Rady,
		Playing,
		GameOver,
	}

	
	FuncDelegateList setUpFunctions_Title=new FuncDelegateList();
	FuncDelegateList setUpFunctions_Rady=new FuncDelegateList();
	FuncDelegateList setUpFunctions_Play=new FuncDelegateList();
	FuncDelegateList setUpFunctions_GameOver=new FuncDelegateList();


	GameDataSingleton gameData;
	
	/// <summary>
	///ゲームの実行状態
	/// </summary>
	public GameSequence Sequence { get { return sequence; } }
	GameSequence sequence;

	void Awake()
	{
		if (DebugManager.FunctionLog)
		{
			Debug.Log(this.ToString() + " Awake");
		}
		gameData = GameDataSingleton.Instance;

		SetDelegateSetUpFunc_Title(this.test);
		SetDelegateSetUpFunc_Title(this.test);

		sequence = gameData.StartSeq;
	}

	void Start()
	{
		switch(Sequence)
		{
			case GameSequence.Title:
				SetUp_Title();
				break;
			case GameSequence.Rady:
				SetUp_Rady();
				break;
			default:
				Debug.LogError(this.ToString() + " seqence is not title or rady");
				break;
		}
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Return))
		{
			Application.LoadLevel("mainScene");
		}
	}


	void SetUp_Title()
	{
		setUpFunctions_Title.RunAllFunction();
	}

	void SetUp_Rady()
	{
		setUpFunctions_Rady.RunAllFunction();
	}

	void SetUp_Play()
	{
		setUpFunctions_Play.RunAllFunction();
	}

	void SetUp_GameOver()
	{
		setUpFunctions_GameOver.RunAllFunction();
	}

	void test()
	{
		Debug.Log("test");
	}

//以下コールバック関数の登録
	/// <summary>
	/// "タイトルになった時に実行する関数"を登録します
	/// </summary>
	public void SetDelegateSetUpFunc_Title(FuncDelegate func)
	{
		setUpFunctions_Title.Add(func);
	}
	/// <summary>
	/// "ゲーム開始準備状態になった際に実行する関数"を登録します
	/// </summary>
	/// <param name="func"></param>
	public void SetDelegateSetUpFunc_Rady(FuncDelegate func)
	{
		setUpFunctions_Rady.Add(func);
	}
	/// <summary>
	/// "ゲームプレイになった際に実行する関数"を登録します
	/// </summary>
	/// <param name="func"></param>
	public void SetDelegateSetUpFunc_Play(FuncDelegate func)
	{
		setUpFunctions_Play.Add(func);
	}
	/// <summary>
	/// "ゲームオーバーになった際に実行する関数"を登録します
	/// </summary>
	/// <param name="func"></param>
	public void SetDelegateSetUpFunc_GameOver(FuncDelegate func)
	{
		setUpFunctions_GameOver.Add(func);
	}
}
