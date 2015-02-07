using UnityEngine;
using System.Collections;

public class NGUIButton : MonoBehaviour 
{
	//このコンポーネントがアタッチされているNGUIのボタンが押された時などの
	//イベントに応じて関数を実行するコンポーネントです
	//実行する関数はdelegateに予め設定する必要があります
	//delegateの設定は"SetDelegate"関数群を介して行います
	//未設定のdelegateは実行されません

	public bool isHolding;	//ボタンが押され、離されるまでの間"true"を保持します

	public delegate void FuncDelegate();	//この型名の変数に実行するべき関数を設定します

	FuncDelegate OnClickFunction			=null;	//ボタンがクリックされ離された時に実行する
	FuncDelegate OnHoldingFunction_Update 	=null;	//ボタンが押されている間毎フレーム"Update"内で実行する
	FuncDelegate OnHoldingFunction_FUpdate	=null;	//ボタンが押されている間毎フレーム"FixedUpdate"内で実行する
	FuncDelegate OnHoldingFunction_LUpdate	=null;	//ボタンが押されている間毎フレーム"LateUpdate"内で実行する
	FuncDelegate OnPressFunction			=null;	//ボタンが押された瞬間実行する
	FuncDelegate OnReleaseFunction			=null;	//ボタンが離された瞬間実行する

	//----------------------------------------
	void Awake()
	{
		isHolding = false;

	}

	//----------------------------------------

	void Start () 
	{
	
	}


	//----------------------------------------
	void Update () 
	{
		if (OnHoldingFunction_Update != null) 
		{
			if(isHolding)
			{
				OnHoldingFunction_Update();
			}
		}
	}
	//----------------------------------------
	void FixedUpdate()
	{
		if (OnHoldingFunction_FUpdate != null) 
		{
			if(isHolding)
			{
				OnHoldingFunction_FUpdate();
			}
		}
	}
	//----------------------------------------
	void LateUpdate()
	{
		if (OnHoldingFunction_LUpdate != null) 
		{
			if(isHolding)
			{
				OnHoldingFunction_LUpdate();
			}
		}
	}
	//----------------------------------------
	void OnClick()
	{
		if (OnClickFunction != null) 
		{
			OnClickFunction();
		}

	}
	//----------------------------------------
	void OnPress()
	{
		//onPressは押された瞬間と離された瞬間の二つのタイミングで呼ばれます
		//そのためisHoldingに押されている間なのかを保存しています

		isHolding=!isHolding;

		if (isHolding) 
		{
			if(OnPressFunction != null)
			{
				OnPressFunction();
			}
		}
		else 
		{
			if(OnReleaseFunction != null)
			{
				OnReleaseFunction();
			}
		}
	}
	//----------------------------------------

	//以下の関数群を介してdelegateに関数を設定します

	public void SetDelegate_OnClickFunction(FuncDelegate target)
	{
		OnClickFunction = target;
	}

	public void SetDelegate_OnHoldingFunction_Update(FuncDelegate target)
	{
		OnHoldingFunction_Update = target;
	}

	public void SetDelegate_OnHoldingFunction_LUpdate(FuncDelegate target)
	{
		OnHoldingFunction_LUpdate = target;
	}

	public void SetDelegate_OnHoldingFunction_FUpdate(FuncDelegate target)
	{
		OnHoldingFunction_FUpdate = target;
	}

	public void SetDelegate_OnPressFunction(FuncDelegate target)
	{
		OnPressFunction = target;
	}

	public void SetDelegate_OnReleaseFunction(FuncDelegate target)
	{
		OnReleaseFunction = target;
	}


}
