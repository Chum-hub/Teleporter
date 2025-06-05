using System;
using UnityEngine;
using UnityEngine.InputSystem;

public interface IMovementStrategy
{
	void Move(Rigidbody rb, Transform cameraPivot, Vector2 moveInput, MovementSetting settings, bool isSprinting, CharacterState state);
}