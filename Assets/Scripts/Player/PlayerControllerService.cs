using Interfaces;
using Zenject;

namespace Player
{
	public class PlayerControllerService : IFixedTickable
	{
		private readonly ICharacterMove _characterMove;
		private readonly ICharacterLook _characterLook;
		private readonly ICharacterJump _characterJump;
		private readonly ICharacterDash _characterDash;
		
		public PlayerControllerService(
			ICharacterMove characterMove,
			ICharacterLook characterLook,
			ICharacterJump characterJump,
			ICharacterDash characterDash)
		{
			_characterMove = characterMove;
			_characterLook = characterLook;
			_characterJump = characterJump;
			_characterDash = characterDash;
		}

		public void FixedTick()
		{
			HandleMovement();
			HandleJump();
			HandleLook();
			HandleDash();
		}

		private void HandleMovement() => _characterMove.Move();
		private void HandleLook() => _characterLook.Look();
		private void HandleJump() => _characterJump.Jump();
		private void HandleDash() => _characterDash.Dash();
	}
}