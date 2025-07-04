using UnityEngine;
using Zenject;

[RequireComponent(typeof(Rigidbody))]
public class CharacterController : MonoBehaviour
{
	[SerializeField] private Transform _cameraPivot;

	[Inject] private IMovementStrategy _movementStrategy;
	[Inject] private MovementSetting _movementSetting;
	[Inject] private ILookStrategy _lookStrategy;
	[Inject] private IJumpStrategy _jumpStrategy;
	[Inject] private IDashStrategy _dashStrategy;

	private PlayerInputCache _inputCache;
	private CharacterState _state;
	private Rigidbody _rb;

	private void Awake()
	{
		_inputCache = GetComponent<PlayerInputCache>();
		_state = GetComponent<CharacterState>();
		_rb = GetComponent<Rigidbody>();

		if (_cameraPivot == null)
			Debug.LogError("[CharacterController] _cameraPivot is NULL!");
	}

	private void FixedUpdate()
	{
		HandleMovement();
		HandleJump();
		HandleLook();
		HandleDash();
	}

	private void HandleLook() =>
		_lookStrategy.Look(transform, _movementSetting, _cameraPivot, _inputCache.LookInput, _state);

	private void HandleMovement() =>
		_movementStrategy.Move(_rb, _cameraPivot, _inputCache.MoveInput, _movementSetting, _inputCache.SprintPressed, _state);

	private void HandleJump() =>
		_jumpStrategy.Jump(_rb, _movementSetting, _inputCache.JumpPressed, _state);

	private void HandleDash() =>
		_dashStrategy.Dash(_rb, _movementSetting, _cameraPivot, _inputCache.DashPressed, _inputCache.MoveInput, this, _state);

	private void OnCollisionEnter(Collision other)
	{
		if (other.contactCount > 0 && other.contacts[0].normal.y > 0.5f)
			_state.IsGrounded = true;
	}
}