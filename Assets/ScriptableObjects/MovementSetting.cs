using UnityEngine;

[CreateAssetMenu(fileName = "MovementSetting", menuName = "Setting/Movement")]
public class MovementSetting : ScriptableObject
{
	public float speed;
	public float jumpForce;
	public float rotationSpeed;
	public float sprintSpeed;
	public float maxLookAngle;
	public float minLookAngle;
	public float dashSpeed;
}