using System;
using UnityEngine;

public class CharacterState : MonoBehaviour
{
	private Single _verticalLookAngle = 0f;
	public Single VerticalLookAngle
	{
		get => _verticalLookAngle;
		set
		{
			if (_verticalLookAngle == value) return;
			_verticalLookAngle = value;
			OnVerticalAngleChanged?.Invoke(value);
		}
	}
	public event Action<Single> OnVerticalAngleChanged;

	private bool isSprinting = false;
	
	
	
	private bool isGrounded = true;
	
	
	
	private bool isDashReady = true;
	
	
	
	
}