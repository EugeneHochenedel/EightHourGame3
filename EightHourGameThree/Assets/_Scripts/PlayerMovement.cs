using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{

	public float Velocity;

	public float CameraSensitivity;

	// Use this for initialization
	void Start()
	{
	
	}
	
	// Update is called once per frame
	void Update()
	{
		float VerticalLook = -Input.GetAxis("Mouse Y") * CameraSensitivity;
		transform.Rotate(VerticalLook, 0, 0);

		float HorizontalLook = Input.GetAxis("Mouse X") * CameraSensitivity;
		transform.Rotate(0, HorizontalLook, 0);

		float ForwardMove = Input.GetAxis("Vertical") * Velocity;

		float StrafeMove = Input.GetAxis("Horizontal") * Velocity;

	//	float VertMove = Input.GetAxis("Jump") * Velocity;

		if (Input.GetKey("space"))
		{
			gameObject.transform.position = new Vector3(0, Time.deltaTime * Velocity * 5, 0);
		}

		Vector3 speed = new Vector3(StrafeMove, 0, ForwardMove);
		speed = transform.localRotation * speed;

		CharacterController playerMove = GetComponent<CharacterController>();
		playerMove.Move(speed);
	}
}
