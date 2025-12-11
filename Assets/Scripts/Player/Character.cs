using System;
using UnityEngine;
using Zenject;

namespace Player
{
	public class Character : MonoBehaviour, ICharacter
	{
		private CharacterState _characterState;
		//private Health _health;
		//public event Action Death;

		[Inject]
		public void Construct(CharacterState characterState)
		{
			_characterState = characterState;
		}

		private void OnCollisionEnter(Collision other)
		{
			if (other.contactCount > 0 && other.contacts[0].normal.y > 0.5f)
				_characterState.IsGrounded = true;
		}
	}
}