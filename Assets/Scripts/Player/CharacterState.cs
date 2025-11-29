using System;

namespace Player
{
	public sealed class CharacterState
	{
		public Single VerticalLookAngle { get; set; } = 0;

		public Boolean IsGrounded { get; set; } = true;

		public Boolean IsDashReady { get; set; } = true;

		public Boolean IsMoving { get; set; } = true;
	}
}