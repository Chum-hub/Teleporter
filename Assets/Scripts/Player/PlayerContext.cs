using Input;
using ScriptableObjects;
using Unity.Cinemachine;
using UnityEngine;


namespace Player
{
	
	public sealed class PlayerContext
	{
		public Transform CharacterTransform { get; set; }
		public CharacterState State { get; set; }
		public MovementSetting Settings { get; set; }
		public Rigidbody Rigidbody { get; set; }
		public PlayerInputCache InputCache { get; set; }


		public PlayerContext(
			Transform characterTransform,
			CharacterState state,
			MovementSetting settings,
			Rigidbody rigidbody,
			PlayerInputCache inputCache)
		{
			Debug.Log("Context");
			CharacterTransform = characterTransform;
			State = state;
			Settings = settings;
			Rigidbody = rigidbody;
			InputCache = inputCache;
		}
	}
}