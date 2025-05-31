using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class LookStrategy : ILookStrategy
{
	private ILookStrategy _lookStrategyImplementation;

	public void Look(Transform transform, MovementSetting movementSetting, Transform cameraPivot, InputAction look, ref Single verticalLookAngle)
	{
		var lookVector = look.ReadValue<Vector2>();
		if (lookVector.sqrMagnitude < 0.01f) return;

		float mouseX = lookVector.x * movementSetting.rotationSpeed;
		float mouseY = lookVector.y * movementSetting.rotationSpeed;
		transform.Rotate(Vector3.up * mouseX);

		verticalLookAngle = Mathf.Clamp(verticalLookAngle - mouseY, movementSetting.minLookAngle, movementSetting.maxLookAngle);
		cameraPivot.localEulerAngles = new Vector3(verticalLookAngle, 0f, 0f);
	}
}
