using System;
using UnityEngine;
using UnityEngine.InputSystem;

public interface IJumpStrategy
{
	public void Jump(Rigidbody rb, MovementSetting settings, bool jumpPressed, CharacterState state);
}
