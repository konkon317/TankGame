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
		Restart,
		Rady,
		Playing,
		GameOver,
	}
	AdsSingleton ads;

	bool adsFlag = false;

	ScreenFader screenFader;
	
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

	bool DidSetStartScene=false;

	/// <summary>
	///ゲームの実行状態
	/// </summary>
	public GameSequence Sequence { get { return sequence; } }
	GameSequence sequence;

	bool gameOverflag=false;

	void Awake()
	{
		ads = AdsSingleton.GetInstance;
		//ads = AdsSingleton.GetInstance;

		titlePanel = GameObject.FindWithTag(Tags.UITitlePanel).GetComponent<NGUIPanel>();
		radyPanel = GameObject.FindWithTag(Tags.UIRadyPanel).GetComponent<NGUIPanel>();
		playPanel = GameObject.FindWithTag(Tags.UIPlayPanel).GetComponent<NGUIPanel>();
		gameOverPanel = GameObject.FindWithTag(Tags.UIGameOverPanel).GetComponent<NGUIPanel>();

		screenFader = GameObject.FindWithTag(Tags.ScreenFader).GetComponent<ScreenFader>();

		if (DebugManager.FunctionLog)
		{
			Debug.Log(this.ToString() + " Awake");
		}
		gameData = GameDataSingleton.Instance;

		sequence = gameData.StartSeq;


		InitializeDelegateLists();
		InitializeButtonDelegate();

		screenFader.SetStateBlack();
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
		/*if (Input.GetKeyDown(KeyCode.Return))
		{
			
		}*/

		switch (Sequence)
		{ 
			case GameSequence.Title:
				OnTitle();
				break;
			case GameSequence.Restart:
				OnRestart();
				break;
			case GameSequence.Rady:
				OnRady();
				break;
			case GameSequence.Playing:
				OnPlaying();
				break;
			case GameSequence.GameOver:
				OnGameOver();
				break;
		}
	}

	void OnTitle()
	{
		if (titlePanel.state == UIPanelState.Hidden)
		{
			SetSequence(GameSequence.Rady);
		}
	}

	void OnRestart()
	{
		if (screenFader.Color == Color.clear)
		{
			SetSequence(GameSequence.Playing);
		}
	}

	void OnRady()
	{
		SetSequence(GameSequence.Playing);
	}

	void OnPlaying()
	{
		if (gameOverflag)
		{
			SetSequence(GameSequence.GameOver);
		}
	}

	void OnGameOver()
	{
		if (adsFlag == false)
		{
			adsFlag = true;
			ads.Show();
		}

		if (screenFader.Color == Color.black)
		{
			Application.LoadLevel("mainScene");
		}
		
	}

	void ToTitleWithLoad()
	{
		if (!DidSetStartScene)
		{
			DidSetStartScene = true;
			screenFader.SetStateFadeToBlack();			
			gameOverPanel.SetStateFadeOut();

			gameData.SetStartSeq(GameSequence.Title);
		}
	}

	void ToRestartWithLoad()
	{
		if (!DidSetStartScene)
		{
			DidSetStartScene = true;
			screenFader.SetStateFadeToBlack();			
			gameOverPanel.SetStateFadeOut();

			gameData.SetStartSeq(GameSequence.Restart);
		}
	}

	void SetSequence(GameSequence targetSeq)
	{
		switch (targetSeq)
		{
			case GameSequence.Rady:
				SetUp_Rady();
				break;
			case GameSequence.Playing:
				SetUp_Play();
				break;
			case GameSequence.GameOver:
				SetUp_GameOver();
				break;
		}
		sequence = targetSeq;
	}

	public void SetGameOverFlag()
	{
		gameOverflag = true;
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
		SetDelegateSetUpFunc_Title(screenFader.SetStateFadeToClear);

		//リスタート画面になった際に実行する関数
		SetDelegateSetUpFunc_Restart(titlePanel.SetStateHidden);
		SetDelegateSetUpFunc_Restart(playPanel.SetStateHidden);
		SetDelegateSetUpFunc_Restart(radyPanel.SetStateHidden);
		SetDelegateSetUpFunc_Restart(gameOverPanel.SetStateHidden);
		SetDelegateSetUpFunc_Restart(screenFader.SetStateFadeToClear);

		//ゲーム開始準備画面に実行する関数
		SetDelegateSetUpFunc_Rady(radyPanel.SetStateFadeIn);

		//ゲーム開始時に実行する関数
		SetDelegateSetUpFunc_Play(playPanel.SetStateFadeIn);

		//ゲームオーバーになった際に実行する関数
		SetDelegateSetUpFunc_GameOver(playPanel.SetStateFadeOut);
		SetDelegateSetUpFunc_GameOver(gameOverPanel.SetStateFadeIn);
		 	
	}

	void InitializeButtonDelegate()
	{
		GameStartButton.SetDelegate_OnPressFunction(titlePanel.SetStateFadeOut);

		GoTitleButton.SetDelegate_OnPressFunction(this.ToTitleWithLoad);
		RestartButton.SetDelegate_OnPressFunction(this.ToRestartWithLoad);

	}

	

	
}
