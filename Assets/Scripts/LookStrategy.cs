using Interfaces;
using Player;
using UnityEngine;

public class LookStrategy : ILookStrategy
{
	
	public void Look(PlayerContext context)
	{
		context.State.VerticalLookAngle -= context.InputCache.LookInput.y * context.Settings.lookSensitivity;
		context.State.VerticalLookAngle = Mathf.Clamp(context.State.VerticalLookAngle, context.Settings.minLookAngle, context.Settings.maxLookAngle);

		context.CameraPivot.localRotation = Quaternion.Euler(context.State.VerticalLookAngle, 0, 0);
		context.CharacterTransform.Rotate(Vector3.up * context.InputCache.LookInput.x * context.Settings.lookSensitivity);
	}
}