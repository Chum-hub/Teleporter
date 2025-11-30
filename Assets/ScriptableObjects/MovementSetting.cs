using System;
using UnityEngine;

namespace ScriptableObjects
{
	[CreateAssetMenu(fileName = "MovementSetting", menuName = "Setting/Movement")]
	public class MovementSetting : ScriptableObject
	{
		public Single speed;
		public Single jumpForce;
		public Single sprintSpeed;
		public Single maxLookAngle;
		public Single minLookAngle;
		public Single lookSensitivity;
		public Single dashForce;
		public Single dashCooldown;
	}
}