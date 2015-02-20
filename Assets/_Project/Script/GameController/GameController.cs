﻿using UnityEngine;
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
		Restart,
		Rady,
		Playing,
		GameOver,
	}

	
	//状態が切り替わった際に実行する関数をリスト
	FuncDelegateList setUpFunctions_Title=new FuncDelegateList();
	FuncDelegateList setUpFunctions_Restart = new FuncDelegateList();
	FuncDelegateList setUpFunctions_Rady=new FuncDelegateList();
	FuncDelegateList setUpFunctions_Play=new FuncDelegateList();
	FuncDelegateList setUpFunctions_GameOver=new FuncDelegateList();

	/// <summary>
	/// シーンのりロードの際リセットされない（されてはいけない）データ
	/// </summary>
	GameDataSingleton gameData;

	[SerializeField]
	NGUIButton GameStartButton;
	[SerializeField]
	NGUIButton GoTitleButton;
	[SerializeField]
	NGUIButton RestartButton;

	//各UIパネルのオンオフをサポートします
	NGUIPanel titlePanel;
	NGUIPanel radyPanel;
	NGUIPanel playPanel;
	NGUIPanel gameOverPanel;


	/// <summary>
	///ゲームの実行状態
	/// </summary>
	public GameSequence Sequence { get { return sequence; } }
	GameSequence sequence;

	void Awake()
	{
		titlePanel = GameObject.FindWithTag(Tags.UITitlePanel).GetComponent<NGUIPanel>();
		radyPanel = GameObject.FindWithTag(Tags.UIRadyPanel).GetComponent<NGUIPanel>();
		playPanel = GameObject.FindWithTag(Tags.UIPlayPanel).GetComponent<NGUIPanel>();
		gameOverPanel = GameObject.FindWithTag(Tags.UIGameOverPanel).GetComponent<NGUIPanel>();
		

		if (DebugManager.FunctionLog)
		{
			Debug.Log(this.ToString() + " Awake");
		}
		gameData = GameDataSingleton.Instance;

		sequence = gameData.StartSeq;


		InitializeDelegateLists();
	}

	void Start()
	{
		switch(Sequence)
		{
			case GameSequence.Title:
				SetUp_Title();
				break;
			case GameSequence.Restart:
				SetUp_Restart();
				break;
			default:
				Debug.LogError(this.ToString() + " seqence is not title or restart");
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
	void SetUp_Restart()
	{
		setUpFunctions_Restart.RunAllFunction();
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
	/// リスタートになった時に実行する関数　を登録します
	/// </summary>
	/// <param name="func"></param>
	public void SetDelegateSetUpFunc_Restart(FuncDelegate func)
	{
		setUpFunctions_Restart.Add(func);
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

	void InitializeDelegateLists()
	{
		//タイトル画面になった際に実行する関数
		SetDelegateSetUpFunc_Title(titlePanel.SetStateDisplay);
		SetDelegateSetUpFunc_Title(playPanel.SetStateHidden);
		SetDelegateSetUpFunc_Title(radyPanel.SetStateHidden);
		SetDelegateSetUpFunc_Title(gameOverPanel.SetStateHidden);

		//リスタート画面になった際に実行する関数
		SetDelegateSetUpFunc_Restart(titlePanel.SetStateHidden);
		SetDelegateSetUpFunc_Restart(playPanel.SetStateHidden);
		SetDelegateSetUpFunc_Restart(radyPanel.SetStateHidden);
		SetDelegateSetUpFunc_Restart(gameOverPanel.SetStateHidden);

		//ゲーム開始準備画面に実行する関数
		SetDelegateSetUpFunc_Rady(radyPanel.SetStateFadeIn);

		//ゲーム開始時に実行する関数
		SetDelegateSetUpFunc_Play(playPanel.SetStateFadeIn);

		//ゲームオーバーになった際に実行する関数
		SetDelegateSetUpFunc_GameOver(playPanel.SetStateFadeOut);
		SetDelegateSetUpFunc_GameOver(gameOverPanel.SetStateFadeIn);
		 	
	}

	public void Test()
	{
		Debug.Log("test");
	}
}
