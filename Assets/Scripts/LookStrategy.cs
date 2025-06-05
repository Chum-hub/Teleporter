using UnityEngine;

public class LookStrategy : ILookStrategy
{
	public void Look(Transform character, MovementSetting settings, Transform cameraPivot, Vector2 lookInput, CharacterState state)
	{
		state.VerticalLookAngle -= lookInput.y * settings.lookSensitivity;
		state.VerticalLookAngle = Mathf.Clamp(state.VerticalLookAngle, settings.minLookAngle, settings.maxLookAngle);

		cameraPivot.localRotation = Quaternion.Euler(state.VerticalLookAngle, 0, 0);
		character.Rotate(Vector3.up * lookInput.x * settings.lookSensitivity);
	}
}