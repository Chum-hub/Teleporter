using Interfaces;
using UnityEngine;
using Zenject;

namespace Player
{
	public class PlayerControllerService : IFixedTickable
	{
		private readonly IMovementStrategy _movementStrategy;
		private readonly ILookStrategy _lookStrategy;
		private readonly IJumpStrategy _jumpStrategy;
		private readonly IDashStrategy _dashStrategy;
		
		public PlayerControllerService(
			IMovementStrategy movementStrategy,
			ILookStrategy lookStrategy,
			IJumpStrategy jumpStrategy,
			IDashStrategy dashStrategy)
		{
			_movementStrategy = movementStrategy;
			_lookStrategy = lookStrategy;
			_jumpStrategy = jumpStrategy;
			_dashStrategy = dashStrategy;
		}

		public void FixedTick()
		{
			HandleMovement();
			HandleJump();
			HandleLook();
			HandleDash();
		}

		private void HandleMovement() => _movementStrategy.Move();
		private void HandleLook() => _lookStrategy.Look();
		private void HandleJump() => _jumpStrategy.Jump();
		private void HandleDash() => _dashStrategy.Dash();
	}
}