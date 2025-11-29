using System;
using UnityEngine;

namespace Player
{
	public class DashStrategy : IDashStrategy
	{
		private Single _lastDashTime;
		private readonly Timer _timer = new Timer();

		public void Dash(PlayerContext context)
		{
			if (!context.InputCache.DashPressed ||
			    Time.time < _lastDashTime + context.Settings.dashCooldown ||
			    !_timer.IsCooldownDone(_lastDashTime, context.Settings.dashCooldown)
			   ) return;

			context.State.IsDashReady = true;

			var forward = context.CameraPivot.forward;
			var right = context.CameraPivot.right;

			forward.y = 0f;
			right.y = 0f;

			var dashDir = (forward * context.InputCache.MoveInput.y + right * context.InputCache.MoveInput.x).normalized;
			if (dashDir == Vector3.zero)
				dashDir = context.CameraPivot.forward;

			context.Rigidbody.AddForce(dashDir.normalized * context.Settings.dashForce, ForceMode.Impulse);
			context.State.IsDashReady = false;
			_lastDashTime = Time.time;

			// todo
		}
	}
}