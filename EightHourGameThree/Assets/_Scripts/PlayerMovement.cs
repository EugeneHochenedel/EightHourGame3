using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{

	public float Velocity;
	public float CameraSensitivity;
	public float vertRange = 60.0f;

	float VerticalLook = 0;
	
	// Use this for initialization
	void Start()
	{
	
	}
	
	// Update is called once per frame
	void Update()
	{
		VerticalLook -= Input.GetAxis("Mouse Y") * CameraSensitivity;
		VerticalLook = Mathf.Clamp(VerticalLook, -vertRange, vertRange);
		//transform.Rotate(VerticalLook, 0, 0);
		Camera.main.transform.localRotation = Quaternion.Euler(VerticalLook, 0, 0);

		float HorizontalLook = Input.GetAxis("Mouse X") * CameraSensitivity;
		transform.Rotate(0, HorizontalLook, 0);

		float ForwardMove = Input.GetAxis("Vertical") * Velocity;

		float StrafeMove = Input.GetAxis("Horizontal") * Velocity;

		//float VertMove = Input.GetAxis("Jump") * Velocity;

		if (Input.GetKey("space"))
		{
			Vector3 tempVector = new Vector3(0, Time.deltaTime * Velocity * 5, 0);
			gameObject.transform.position = gameObject.transform.position + tempVector;
        }

		Vector3 speed = new Vector3(StrafeMove, 0, ForwardMove);
		speed = transform.rotation * speed;

		CharacterController playerMove = GetComponent<CharacterController>();
		playerMove.Move(speed);
	}
}
