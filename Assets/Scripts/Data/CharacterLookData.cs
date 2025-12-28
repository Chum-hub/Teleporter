using System;
using Unity.Cinemachine;
using UnityEngine;
using Object = System.Object;

namespace Data
{
	public sealed class CharacterLookData
	{
		public Single VerticalLookAngle { get; private set; } = 0;

		public Single HorizontalLookAngle { get; private set; } = 0;

		public void SetVerticalAngle(Single delta, Single minAngle, Single maxAngle)
		{
			VerticalLookAngle = Math.Clamp(delta, minAngle, maxAngle);
		}

		public void SetHorizontalAngle(Single delta)
		{
			HorizontalLookAngle += delta;
		}

		public Vector3 GetLookDirection() => new Vector3(VerticalLookAngle, HorizontalLookAngle, 0f);
	}
}