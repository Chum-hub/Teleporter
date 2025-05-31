using System;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

[RequireComponent(typeof(Rigidbody))]
public class CharacterController : MonoBehaviour
{
	[Header("References")]
	[SerializeField] private Transform cameraPivot;
	[FormerlySerializedAs("movement")] [SerializeField]
	private MovementSetting movementSetting;

	private Rigidbody rb;

	private InputSystem_Actions inputActions;
	private InputAction move;
	private InputAction jump;
	private InputAction look;
	private InputAction sprint;
	private InputAction dash;

	private float verticalLookAngle = 0f;
	private bool isSprinting = false;
	private bool isGrounded = true;

	private IMovementStrategy movementStrategy = new WalkMovementStrategy();
	private ILookStrategy lookStrategy = new LookStrategy();
	private IJumpStrategy jumpStrategy = new JumpStrategy();
	private IDashStrategy dashStrategy = new DashStrategy();

	private void Awake()
	{
		rb = GetComponent<Rigidbody>();
		rb.freezeRotation = true;

		SetupInput();
	}

	private void OnEnable() => inputActions.Enable();
	private void OnDisable() => inputActions.Disable();

	private void HandleMovement() => movementStrategy.Move(rb, cameraPivot, move, movementSetting, ref isSprinting, sprint, isGrounded);

	private void HandleJump() => jumpStrategy.Jump(ref isGrounded, rb, movementSetting, jump);

	private void HandleLook() => lookStrategy.Look(transform, movementSetting, cameraPivot, look, ref verticalLookAngle);
	
	private void HandleDash() => dashStrategy.Dash(rb, movementSetting, cameraPivot, dash, move, this);

	private void OnCollisionEnter(Collision other)
	{
		if (other.contactCount > 0 && other.contacts[0].normal.y > 0.5f)
			isGrounded = true;
	}

	private void FixedUpdate()
	{
		HandleLook();
		HandleMovement();
		HandleJump();
		HandleDash();
	}

	private void SetupInput()
	{
		inputActions = new InputSystem_Actions();
		move = inputActions.Player.Move;
		jump = inputActions.Player.Jump;
		look = inputActions.Player.Look;
		sprint = inputActions.Player.Sprint;
		dash = inputActions.Player.Dash;
	}
}