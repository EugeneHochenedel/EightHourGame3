using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{

	public float Velocity;
	public float CameraSensitivity;
	public float vertRange;

	float VerticalLook = 0;
	
	// Use this for initialization
	void Start()
	{
	
	}
	
	// Update is called once per frame
	void Update()
	{
		float HorizontalLook = Input.GetAxis("Mouse X") * CameraSensitivity;
		transform.Rotate(0, HorizontalLook, 0);

		VerticalLook -= Input.GetAxis("Mouse Y") * CameraSensitivity;
		VerticalLook = Mathf.Clamp(VerticalLook, -vertRange, vertRange);
		Camera.main.transform.localRotation = Quaternion.Euler(VerticalLook, 0, 0);

		if (Input.GetKey("space"))
		{
			Vector3 tempVector = new Vector3(0, Time.deltaTime * Velocity * 5, 0);
			gameObject.transform.position = gameObject.transform.position + tempVector;
		}

		Vector3 speed = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
		speed = transform.rotation * speed;

		CharacterController playerMove = GetComponent<CharacterController>();
		playerMove.SimpleMove(speed);

		if(playerMove.detectCollisions == true)
		{
			playerMove.Move(speed);
		}
	}
}
