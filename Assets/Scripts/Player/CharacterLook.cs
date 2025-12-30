using System;
using Data;
using Input;
using Interfaces;
using ScriptableObjects;
using Unity.Mathematics;
using UnityEngine;

namespace Player
{
	public class CharacterLook : ICharacterLook
	{
		private readonly Transform _charControl;
		private readonly CharacterLookData _lookData;
		private readonly MovementSetting _setting;
		private readonly PlayerInputCache _inputCache;
		private readonly GameObject _head;
		
		public CharacterLook(
			Transform charControl,
			CharacterLookData lookData,
			MovementSetting setting,
			PlayerInputCache inputCache,
			GameObject head)
		{
			_charControl = charControl;
			_lookData = lookData;
			_setting = setting;
			_inputCache = inputCache;
			_head = head;
		}

		public void Look()
		{
			var look = _inputCache.LookInput;
			var verticalDelta   =  -look.y * _setting.LookSensitivity;
			var horizontalDelta =  look.x * _setting.LookSensitivity;

			
			Debug.Log("Vdelta  " + verticalDelta);
			Debug.Log("Hdelta  " + horizontalDelta);

			_lookData.SetPitch(verticalDelta, _setting.MinLookAngle, _setting.MaxLookAngle);
			_lookData.SetYaw(horizontalDelta);
			
			_head.transform.localRotation =
				Quaternion.Euler(_lookData.Pitch, 0f, 0f);

			_charControl.transform.rotation =
				Quaternion.Euler(0f, _lookData.Yaw, 0f);
		}
	}
}