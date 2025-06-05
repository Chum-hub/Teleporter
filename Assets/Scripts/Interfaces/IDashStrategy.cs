using System;
using UnityEngine;
using UnityEngine.InputSystem;

public interface IDashStrategy
{
	void Dash(Rigidbody rb, MovementSetting settings, Transform cameraPivot, bool dashPressed, Vector2 moveInput, MonoBehaviour mono, CharacterState state);
}
