using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class EnemyController : NetworkBehaviour {

	public float m_TurnSpeed = 180f;
	public float m_Speed = 2f;
	public VirtualJoystick joystick;
	private float m_MovementInputValue;
	private float m_TurnInputValue;


	// Update is called once per frame
	void Update () {
		if (hasAuthority == true)
		{
			print("find main cam");
			transform.Find("Main Camera").gameObject.SetActive(true);
//			transform.Find("EnemyCanvas").gameObject.SetActive(true);
		}
		m_MovementInputValue = joystick.InputDirection[2];
		m_TurnInputValue = joystick.InputDirection[0];
	}
	private void FixedUpdate()
	{
		Move();
	}

	private void Move()
	{
		// Adjust the position of the tank based on the player's input.
		transform.Translate((m_Speed ) * m_TurnInputValue * Time.deltaTime, 0f, (m_Speed) * m_MovementInputValue * Time.deltaTime);
	}
}
