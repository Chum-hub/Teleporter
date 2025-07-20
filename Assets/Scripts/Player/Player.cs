using UnityEngine;
using Zenject;

namespace Player
{
	public class Player : MonoBehaviour
	{
		[SerializeField] private Transform _cameraPivot;
		
		private CharacterState _characterState;

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