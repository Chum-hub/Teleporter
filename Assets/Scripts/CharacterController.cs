using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class CharacterController : MonoBehaviour
{
	[Header("References")]
	[SerializeField] private Transform cameraPivot;
	[SerializeField] private MovementSetting movementSetting;

	private Rigidbody _rb;
	private CharacterState _state;

	private InputSystem_Actions _inputActions;
	private InputAction _move, _jump, _look, _sprint, _dash, _throw;

	private IMovementStrategy movementStrategy = new WalkMovementStrategy();
	private ILookStrategy lookStrategy = new LookStrategy();
	private IJumpStrategy jumpStrategy = new JumpStrategy();
	private IDashStrategy dashStrategy = new DashStrategy();

	// Кэшированные инпуты
	private Vector2 _moveInput;
	private Vector2 _lookInput;
	private bool _jumpPressed;
	private bool _dashPressed;
	private bool _sprintPressed;

	private void Awake()
	{
		_rb = GetComponent<Rigidbody>();
		_state = GetComponent<CharacterState>();

		_rb.freezeRotation = true;
		SetupInput();
	}

	private void OnEnable() => _inputActions.Enable();
	private void OnDisable() => _inputActions.Disable();

	private void Update()
	{
		CacheInput();
	}
	private void FixedUpdate()
	{
		HandleMovement();
		HandleJump();
		HandleDash();
		HandleThrow();
		HandleLook();

	}

	private void OnCollisionEnter(Collision other)
	{
		if (other.contactCount > 0 && other.contacts[0].normal.y > 0.5f)
			_state.IsGrounded = true;
	}

	private void HandleLook() =>
		lookStrategy.Look(transform, movementSetting, cameraPivot, _lookInput, _state);

	private void HandleMovement() =>
		movementStrategy.Move(_rb, cameraPivot, _moveInput, movementSetting, _sprintPressed, _state);

	private void HandleJump() =>
		jumpStrategy.Jump(_rb, movementSetting, _jumpPressed, _state);

	private void HandleDash() =>
		dashStrategy.Dash(_rb, movementSetting, cameraPivot, _dashPressed, _moveInput, this, _state);

	private void HandleThrow()
	{
		// todo
	}

	private void CacheInput()
	{
		_moveInput = _move.ReadValue<Vector2>();
		_lookInput = _look.ReadValue<Vector2>();
		_jumpPressed = _jump.triggered;
		_dashPressed = _dash.triggered;
		_sprintPressed = _sprint.IsPressed();
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
}