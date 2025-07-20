using System;
using Player;
using UnityEngine;

public class DashStrategy : IDashStrategy
{
	private Single _lastDashTime;

	public void Dash(PlayerContext context)
	{
		if (!context.InputCache.DashPressed || Time.time < _lastDashTime + context.Settings.dashCooldown || !IsDashReady(context.State))
			return;

		Vector3 forward = context.CameraPivot.forward;
		Vector3 right = context.CameraPivot.right;

		forward.y = 0f;
		right.y = 0f;

		Vector3 dashDir = (forward * context.InputCache.MoveInput.y + right * context.InputCache.MoveInput.x).normalized;
		if (dashDir == Vector3.zero)
			dashDir = context.CameraPivot.forward;

		context.Rigidbody.AddForce(dashDir.normalized * context.Settings.dashForce, ForceMode.Impulse);
		context.State.IsDashReady = false;
		_lastDashTime = Time.time;

		// todo
	}

	private Boolean IsDashReady(CharacterState state)
	{
		if (Time.time > _lastDashTime && !state.IsDashReady) state.IsDashReady = true;
		return state.IsDashReady;
	}
}