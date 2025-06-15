using System;
using UnityEngine;

public class DashStrategy : IDashStrategy
{
	private Single _lastDashTime;

	public void Dash(Rigidbody rb, MovementSetting settings, Transform cameraPivot, Boolean dashPressed, Vector2 moveInput, MonoBehaviour mono, CharacterState state)
	{
		if (!dashPressed || Time.time < _lastDashTime + settings.dashCooldown || !IsDashReady(state))
			return;

		Vector3 forward = cameraPivot.forward;
		Vector3 right = cameraPivot.right;

		forward.y = 0f;
		right.y = 0f;

		Vector3 dashDir = (forward * moveInput.y + right * moveInput.x).normalized;
		if (dashDir == Vector3.zero)
			dashDir = cameraPivot.forward;

		rb.AddForce(dashDir.normalized * settings.dashForce, ForceMode.Impulse);
		state.IsDashReady = false;
		_lastDashTime = Time.time;

		// todo
	}

	private Boolean IsDashReady(CharacterState state)
	{
		if (Time.time > _lastDashTime && !state.IsDashReady) state.IsDashReady = true;
		return state.IsDashReady;
	}
}