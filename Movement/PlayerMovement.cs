using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float MouseSensitivity = 100f;
	public Transform playerBody;
	public GameObject player;
	public bool cursorOn;
	public float startSens,  MoveSpeed;
	float xRotation = 0f;
	// Start is called before the first frame update
	void Start()
	{
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		startSens = MouseSensitivity;
		
	}

	// Update is called once per frame
	void Update()
	{
		float mouseX = Input.GetAxis("Mouse X") * MouseSensitivity * Time.deltaTime;
		float mouseY = Input.GetAxis("Mouse Y") * MouseSensitivity * Time.deltaTime;
		xRotation -= mouseY;
		xRotation = Mathf.Clamp(xRotation, -90f, 90f);

		transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
		playerBody.Rotate(Vector3.up * mouseX);
	}

	public void ToggleCursor()
	{
		if (cursorOn == false)
		{
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
			MouseSensitivity = 0;
			player.GetComponent<PlayerWalk>().canWalk = false;
			cursorOn = true;
		}
		else if (cursorOn == true)
		{
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
			MouseSensitivity = startSens;
			player.GetComponent<PlayerWalk>().canWalk = true;
			cursorOn = false;
		}


	}
}
