using UnityEngine;

public class DashStrategy : IDashStrategy
{
	private float _lastDashTime;

	public void Dash(Rigidbody rb, MovementSetting settings, Transform cameraPivot, bool dashPressed, Vector2 moveInput, MonoBehaviour mono, CharacterState state)
	{
		if (!dashPressed || Time.time < _lastDashTime + settings.dashCooldown || !state.IsDashReady) return;

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
}