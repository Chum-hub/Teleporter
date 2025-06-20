using System;
using UnityEngine;

public class ThrowController : MonoBehaviour
{
	[SerializeField] private GameObject _projectilePrefab;
	[SerializeField] private Transform _throwOrigin;
	[SerializeField] private Single _throwForce = 10f;

	private CharacterState _playerState;
	private PlayerInputCache _inputCache;
	private CharacterState _state;

	private void Awake()
	{
		_playerState = GetComponent<CharacterState>();
		_inputCache = GetComponent<PlayerInputCache>();
	}

	private void FixedUpdate()
	{
		ToThrow();
	}

	private void ToThrow()
	{
		if (!_inputCache.ThrowPressed) return;

		var verticalAngle = _playerState.VerticalLookAngle;
		GameObject projectile = Instantiate(_projectilePrefab, _throwOrigin.position, Quaternion.identity);

		Vector3 direction = _throwOrigin.forward;
		direction.y = 0f;
		direction.Normalize();

		Quaternion pitchRotation = Quaternion.AngleAxis(verticalAngle, _throwOrigin.right);
		direction = pitchRotation * direction;

		Rigidbody rb = projectile.GetComponent<Rigidbody>();
		rb.AddRelativeForce(direction * _throwForce, ForceMode.Impulse);
	}
}