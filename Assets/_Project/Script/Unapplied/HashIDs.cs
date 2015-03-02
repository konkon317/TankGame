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

	public static int TutrialStarted_Trigger { get { return tutrialStarted_Trigger; } }
	static int tutrialStarted_Trigger;

	static HashIDs()
	{
		run_State = Animator.StringToHash("Base Layer.Run");
		crash_Trigger = Animator.StringToHash("Crash_Trigger");
		tutrialStarted_Trigger = Animator.StringToHash("TutrialStarted_Trigger");
	}

}

