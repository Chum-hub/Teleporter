using System;
using Unity.Cinemachine;
using UnityEngine;
using Object = System.Object;

namespace Data
{
	public sealed class CharacterLookData
	{
		public Single Pitch { get; private set; } = 0;

		public Single Yaw { get; private set; } = 0;

		public void SetPitch(Single delta, Single min, Single max)
		{
			Pitch = Math.Clamp(Pitch + delta, min, max);
		}

		public void SetYaw(Single delta)
		{
			Yaw += delta;
		}

		public Vector3 GetLookDirection() => Quaternion.Euler(Pitch, Yaw, 0f) * Vector3.forward.normalized;
	}
}