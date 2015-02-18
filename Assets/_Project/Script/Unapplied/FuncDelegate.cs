using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public delegate void FuncDelegate();

public class FuncDelegateList
{
	List<FuncDelegate> list=new List<FuncDelegate>();

	public int Count { get { return list.Count; } }

	public void Add(FuncDelegate func)
	{
		list.Add(func);
	}

	public void RunAllFunction()
	{ 
		foreach(FuncDelegate func in list)
		{
			func();
		}
	}

	public void Clear()
	{
		list.Clear();
	}
}