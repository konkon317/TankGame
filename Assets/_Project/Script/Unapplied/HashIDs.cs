using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;


class HashIDs
{

	public static int Run_State { get { return run_State; } }
	static int run_State;

	public static int Crash_Trigger{get {return crash_Trigger;}}
	static int crash_Trigger;

	static HashIDs()
	{
		run_State = Animator.StringToHash("Base Layer.Run");
		crash_Trigger = Animator.StringToHash("Crash_Trigger");
	}

}

