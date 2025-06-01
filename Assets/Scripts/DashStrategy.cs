using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class DashStrategy : IDashStrategy
{

	public void Dash(Rigidbody rb, MovementSetting movementSetting, Transform cameraPivot, InputAction dash, InputAction move, MonoBehaviour context, ref Boolean isDashReady)
	{
		if (!dash.IsPressed() || !isDashReady) return;

		Vector2 moveVector = move.ReadValue<Vector2>();

		Vector3 forward = cameraPivot.forward;
		Vector3 right = cameraPivot.right;
		forward.y = 0;
		right.y = 0;
		forward.Normalize();
		right.Normalize();

		Vector3 dashDirection = forward * moveVector.y + right * moveVector.x;

		rb.AddForce(dashDirection.normalized * movementSetting.dashSpeed, ForceMode.Impulse);

		context.StartCoroutine(Cooldown());
		
	}

	private IEnumerator Cooldown()
	{
		// isDashReady = false;
		yield return new WaitForSeconds(5f);
		// isDashReady = true;
	}
}