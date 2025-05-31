using System;
using UnityEngine;
using UnityEngine.InputSystem;

public interface IMovementStrategy
{
	void Move(Rigidbody rb, Transform cameraPivot, InputAction move, MovementSetting movementSetting,ref  Boolean isSprinting, InputAction action, Boolean isGrounded);
}