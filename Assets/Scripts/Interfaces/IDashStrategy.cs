using System;
using UnityEngine;
using UnityEngine.InputSystem;

public interface IDashStrategy
{
	void Dash(Rigidbody rb, MovementSetting movementSetting, Transform cameraPivot, InputAction dash, InputAction move, MonoBehaviour context, ref Boolean isDashReady);
}
