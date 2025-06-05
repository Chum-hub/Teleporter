using System;
using UnityEngine;
using UnityEngine.InputSystem;

public interface ILookStrategy
{
	void Look(Transform character, MovementSetting settings, Transform cameraPivot, Vector2 lookInput, CharacterState state);
}