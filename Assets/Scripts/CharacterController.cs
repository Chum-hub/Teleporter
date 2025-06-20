using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CharacterController : MonoBehaviour
{
	[Header("References")]
	[SerializeField] private Transform _cameraPivot;
	[SerializeField] private MovementSetting _movementSetting;

	private Rigidbody _rb;
	private CharacterState _state;
	private PlayerInputCache _inputCache;

	private readonly IMovementStrategy _movementStrategy = new WalkMovementStrategy();
	private readonly ILookStrategy _lookStrategy = new LookStrategy();
	private readonly IJumpStrategy _jumpStrategy = new JumpStrategy();
	private readonly IDashStrategy _dashStrategy = new DashStrategy();

	private void Awake()
	{
		_rb = GetComponent<Rigidbody>();
		_state = GetComponent<CharacterState>();
		_inputCache = GetComponent<PlayerInputCache>();
		_rb.freezeRotation = true;
	}

	private void FixedUpdate()
	{
		HandleMovement();
		HandleJump();
		HandleLook();
		HandleDash();
	}

	private void OnCollisionEnter(Collision other)
	{
		if (other.contactCount > 0 && other.contacts[0].normal.y > 0.5f)
			_state.IsGrounded = true;
	}

	private void HandleLook() =>
		_lookStrategy.Look(transform, _movementSetting, _cameraPivot, _inputCache.LookInput, _state);

	private void HandleMovement() =>
		_movementStrategy.Move(_rb, _cameraPivot, _inputCache.MoveInput, _movementSetting, _inputCache.SprintPressed, _state);

	private void HandleJump() =>
		_jumpStrategy.Jump(_rb, _movementSetting, _inputCache.JumpPressed, _state);

	private void HandleDash() =>
		_dashStrategy.Dash(_rb, _movementSetting, _cameraPivot, _inputCache.DashPressed, _inputCache.MoveInput, this, _state);
}