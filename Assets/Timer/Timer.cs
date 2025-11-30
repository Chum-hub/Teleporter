using System;
using UnityEngine;

namespace Timer
{
	public class Timer
	{
		public Boolean IsCooldownDone(Single lastOperationDone, Single cooldown)
		{
			return Time.time >= lastOperationDone + cooldown;
		}
	}
}