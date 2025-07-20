using System;
using UnityEngine;

public sealed class CharacterState
{
	private Single _verticalLookAngle = 0;
	public Single VerticalLookAngle {
		get => _verticalLookAngle;
		set => _verticalLookAngle = value;
	}
	private bool _isGrounded = true;
	public bool IsGrounded
	{
	    get => _isGrounded;
	    set => _isGrounded = value;
	}

	private bool _isDashReady = true;
	public bool IsDashReady
	{
	    get => _isDashReady;
	    set => _isDashReady = value;
	}

	private bool _isMoving = true;
	public bool IsMoving
	{
	    get => _isMoving;
	    set => _isMoving = value;
	}
}