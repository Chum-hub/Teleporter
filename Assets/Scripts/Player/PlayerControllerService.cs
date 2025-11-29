using Interfaces;
using Zenject;

namespace Player
{
	public class PlayerControllerService : IFixedTickable
	{
		private readonly IMovementStrategy _movementStrategy;
		private readonly ILookStrategy _lookStrategy;
		private readonly IJumpStrategy _jumpStrategy;
		private readonly IDashStrategy _dashStrategy;
		private readonly PlayerContext _context;

		[Inject]
		public PlayerControllerService(
			PlayerContext context,
			IMovementStrategy movementStrategy,
			ILookStrategy lookStrategy,
			IJumpStrategy jumpStrategy,
			IDashStrategy dashStrategy)
		{
			_context = context;
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

		private void HandleLook() => _lookStrategy.Look(_context);
		private void HandleMovement() => _movementStrategy.Move(_context);
		private void HandleJump() => _jumpStrategy.Jump(_context);
		private void HandleDash() => _dashStrategy.Dash(_context);
	}
}