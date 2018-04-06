using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player2Controller : MonoBehaviour
{

    public float m_TurnSpeed = 180f;
    public float m_Speed = 2f;
    private float m_MovementInputValue;
    private float m_TurnInputValue;
    private Rigidbody m_Rigidbody;

    public float pickupSlow = 0.5f;
    public Text countText;
    private int pickupCount;
    private int pickupTriggerDuration = 0;
    public GameObject pickupPrefab;

    // Update is called once per frame
    private void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        countText.text = "Resources: " + pickupCount.ToString();
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
        m_MovementInputValue = Input.GetAxisRaw("VerticalPlayer2");
        m_TurnInputValue = Input.GetAxisRaw("HorizontalPlayer2");

        //DROPPING PICKUPS
        if (Input.GetKeyDown("space"))
        {
            if (pickupCount >= 1)
            {
                Instantiate(pickupPrefab, transform.position, Quaternion.identity);
                pickupCount--;
                countText.text = "Resources: " + pickupCount.ToString();
            }
        }
    }

    private void FixedUpdate()
    {
        Move();

    }

    private void Move()
    {
        // Adjust the position of the tank based on the player's input.
        transform.Translate((m_Speed - pickupCount * pickupSlow) * m_TurnInputValue * Time.deltaTime, 0f, (m_Speed - pickupCount * pickupSlow) * m_MovementInputValue * Time.deltaTime);
    }



    //COLLECTING PICKUPS
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("pickup"))
        {
            pickupTriggerDuration++;
        }

        if (pickupTriggerDuration > 500)
        {
            Destroy(other.gameObject);

            pickupTriggerDuration = 0;
            pickupCount++;
            countText.text = "Resources: " + pickupCount.ToString();
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("pickup"))
        {
            pickupTriggerDuration = 0;
        }
    }


}