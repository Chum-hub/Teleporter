using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

namespace Input
{
	public class PlayerInputCache : IDisposable
	{
		private InputSystem_Actions _inputActions;

		public Vector2 MoveInput { get; private set; }
		public Vector2 LookInput { get; private set; }
		public Boolean JumpPressed { get; private set; }
		public Boolean DashPressed { get; private set; }
		public Boolean SprintPressed { get; private set; }
		public Boolean ThrowPressed { get; private set; }

		private InputAction _move, _jump, _look, _sprint, _dash, _throw;

		public PlayerInputCache()
		{
			SetupInput();
			_inputActions.Enable();
			BindCallbacks();
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

		private void BindCallbacks()
		{
			_move.performed += OnMove;
			_move.canceled += OnMove;

			_look.started += OnLook;
			_look.canceled += OnLook;

			_sprint.started += OnSprint;
			_sprint.canceled += OnSprint;

			_jump.started += OnJump;
			_jump.canceled += OnJump;

			_dash.started += OnDash;
			_dash.canceled += OnDash;

			_throw.started += OnThrow;
			_throw.canceled += OnThrow;
		}

		private void OnMove(InputAction.CallbackContext ctx)
		{
			MoveInput = ctx.ReadValue<Vector2>();

			if (ctx.canceled)
			{
				MoveInput = Vector2.zero;
			}
		}

		private void OnLook(InputAction.CallbackContext ctx)
		{
			LookInput = ctx.ReadValue<Vector2>();
			if (ctx.canceled)
				LookInput = Vector2.zero;
		}

		private void OnSprint(InputAction.CallbackContext ctx)
		{
			if (ctx.started)
			{
				SprintPressed = true;
			}

			if (ctx.canceled)
			{
				SprintPressed = false;
			}
		}

		private void OnJump(InputAction.CallbackContext ctx)
		{
			if (ctx.started)
			{
				JumpPressed = true;
			}

			if (ctx.canceled)
			{
				JumpPressed = false;
			}
		}

		private void OnDash(InputAction.CallbackContext ctx)
		{
			if (ctx.started)
				DashPressed = true;
			if (ctx.canceled)
				DashPressed = false;
		}

		private void OnThrow(InputAction.CallbackContext ctx)
		{
			if (ctx.started)
				ThrowPressed = true;
			if (ctx.canceled)
				ThrowPressed = false;
		}

		public void Dispose()
		{
			_inputActions.Disable();

			_inputActions?.Dispose();
			_move?.Dispose();
			_jump?.Dispose();
			_look?.Dispose();
			_sprint?.Dispose();
			_dash?.Dispose();
			_throw?.Dispose();
		}
	}
}