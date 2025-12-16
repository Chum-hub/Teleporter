using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace ScriptableObjects
{
	[CreateAssetMenu(
		fileName = "MovementSetting",
		menuName = "Setting/Movement")]
	public class MovementSetting : ScriptableObject
	{
		[FormerlySerializedAs("speed")] public Single Speed;
		[FormerlySerializedAs("jumpForce")] public Single JumpForce;
		[FormerlySerializedAs("sprintSpeed")] public Single SprintSpeed;
		[FormerlySerializedAs("maxLookAngle")] public Single MaxLookAngle;
		[FormerlySerializedAs("minLookAngle")] public Single MinLookAngle;
		[FormerlySerializedAs("lookSensitivity")] public Single LookSensitivity;
		[FormerlySerializedAs("dashForce")] public Single DashForce;
		[FormerlySerializedAs("dashCooldown")] public Single DashCooldown;
	}
}