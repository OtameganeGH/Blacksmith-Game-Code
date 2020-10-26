using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalk : MonoBehaviour
{
	public bool canWalk = true ;
	public CharacterController controller;
	public float moveSpeed = 12f;
    void Update()
    {
		float x = Input.GetAxis("Horizontal");
		float z = Input.GetAxis("Vertical");
		
		Vector3 move = transform.right * x + transform.forward * z;
		
		if(canWalk)
		controller.Move(move * moveSpeed * Time.deltaTime);
	}
}
