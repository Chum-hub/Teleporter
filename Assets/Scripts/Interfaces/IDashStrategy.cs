using System;
using UnityEngine;

public interface IDashStrategy
{
	void Dash(Rigidbody rb, MovementSetting settings, Transform cameraPivot, Boolean dashPressed, Vector2 moveInput, MonoBehaviour mono, CharacterState state);
}
