using System;
using UnityEngine;

public class Timer
{
	public Boolean IsCooldownDone(Single lastOperationDone, Single cooldown)
	{
		return Time.time >= lastOperationDone + cooldown;
	}
}