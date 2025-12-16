using System;
using UnityEngine;

namespace Timer
{
	public class CooldownTimer
	{
		public Boolean IsCooldownDone(Single lastOperationDone, Single cooldown)
		{
			return Time.time >= lastOperationDone + cooldown;
		}
	}
}