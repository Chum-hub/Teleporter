using Input;
using ScriptableObjects;
using UnityEngine;
using Zenject;

namespace Player
{
	public sealed class PlayerContext
	{
		public Transform CharacterTransform { get; }
		public Transform CameraPivot { get; }
		public CharacterState State { get; }
		public MovementSetting Settings { get; }
		public Rigidbody Rigidbody { get; }
		public PlayerInputCache InputCache { get; }

		public PlayerContext(
			[Inject(Id = "PlayerTransform")] Transform characterTransform,
			CharacterState state,
			MovementSetting settings,
			Rigidbody rigidbody,
			PlayerInputCache inputCache,
			[Inject(Id = "CameraPivot")] Transform cameraPivot)
		{
			CharacterTransform = characterTransform;
			State = state;
			Settings = settings;
			Rigidbody = rigidbody;
			InputCache = inputCache;
			CameraPivot = cameraPivot;
		}
	}
}