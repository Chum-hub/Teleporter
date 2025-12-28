using System;
using UnityEngine;

namespace Player
{
	public sealed class CharacterState
	{
		
		public Boolean IsGrounded { get; set; } = true;

		public Boolean IsDashReady { get; set; } = true;

		public Boolean IsMoving { get; set; } = true;

		public Boolean IsThrowReady { get; set; } = true;
		
	}
}