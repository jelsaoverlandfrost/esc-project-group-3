using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKeyboardController : MonoBehaviour
{

    public float m_TurnSpeed = 90f;
    public float m_Speed = 2f;

    private float m_MovementInputValue;
    private float m_TurnInputValue;
    private Rigidbody m_Rigidbody;

    // Update is called once per frame
    private void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }


    private void OnEnable()
    {
        m_Rigidbody.isKinematic = false;
        m_MovementInputValue = 0f;
        m_TurnInputValue = 0f;
    }


    private void OnDisable()
    {
        m_Rigidbody.isKinematic = true;
    }

    void Update()
    {
        m_MovementInputValue = Input.GetAxisRaw("VerticalEnemy");
        m_TurnInputValue = Input.GetAxisRaw("HorizontalEnemy");

    }

    private void FixedUpdate()
    {
        Move();
        //Turn();
    }

    private void Move()
    {
        // Adjust the position of the tank based on the player's input.
        //  Vector3 movement = transform.forward * m_MovementInputValue * m_Speed * Time.deltaTime;

        //    m_Rigidbody.MovePosition(m_Rigidbody.position + movement);
        transform.Translate(m_Speed * m_TurnInputValue * Time.deltaTime, 0f, m_Speed * m_MovementInputValue * Time.deltaTime);
        
    }


    private void Turn()
    {
        // Adjust the rotation of the tank based on the player's input.
        float turn = m_TurnInputValue * m_TurnSpeed * Time.deltaTime;

        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);

        m_Rigidbody.MoveRotation(m_Rigidbody.rotation * turnRotation);
    }
}
