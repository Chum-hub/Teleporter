using System;
using UnityEngine;
using UnityEngine.InputSystem;

public interface ILookStrategy
{
	public void Look(Transform transform, MovementSetting movementSetting, Transform cameraPivot, InputAction look, ref Single verticalLookAngle);
}
