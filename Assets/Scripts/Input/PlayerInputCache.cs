using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputCache : MonoBehaviour
{
	private InputSystem_Actions _inputActions;

	public Vector2 MoveInput { get; private set; }
	public Vector2 LookInput { get; private set; }
	public Boolean JumpPressed { get; private set; }
	public Boolean DashPressed { get; private set; }
	public Boolean SprintPressed { get; private set; }
	public Boolean ThrowPressed { get; set; }

	private InputAction _move, _jump, _look, _sprint, _dash, _throw;

	private void Awake()
	{
		SetupInput();
	}

	private void Update()
	{
		MoveInput = _move.ReadValue<Vector2>();
		LookInput = _look.ReadValue<Vector2>();
		JumpPressed = _jump.IsPressed();
		DashPressed = _dash.IsPressed();
		SprintPressed = _sprint.IsPressed();
		ThrowPressed = _throw.triggered;
	}

	private void SetupInput()
	{
		_inputActions = new InputSystem_Actions();

		_move = _inputActions.Player.Move;
		_jump = _inputActions.Player.Jump;
		_look = _inputActions.Player.Look;
		_sprint = _inputActions.Player.Sprint;
		_dash = _inputActions.Player.Dash;
		_throw = _inputActions.Player.Throw;
	}

	private void OnEnable() => _inputActions.Enable();

	private void OnDisable() => _inputActions.Disable();
}