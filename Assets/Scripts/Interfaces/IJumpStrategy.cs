using System;
using UnityEngine;
using UnityEngine.InputSystem;

public interface IJumpStrategy
{
	void Jump(ref Boolean  isGrounded, Rigidbody rb, MovementSetting movementSetting, InputAction jump);
}
