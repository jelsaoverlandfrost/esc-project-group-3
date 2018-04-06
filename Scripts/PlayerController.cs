using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using NUnit.Framework;

public class PlayerController : NetworkBehaviour
{

    public float m_TurnSpeed = 180f;
    public float m_Speed = 2f;
	public VirtualJoystick joystick;
    private float m_MovementInputValue;
    private float m_TurnInputValue;
    private Rigidbody m_Rigidbody;

    public float pickupSlow = 0.5f;
    public Text countText;
	public static int pickupCount;
    private int pickupTriggerDuration = 0;
    public GameObject pickupPrefab;
	public static bool pickedUp = false;

	public static bool click = false;
    

	public delegate void ChangeEvent (bool condition);
	public static event ChangeEvent changeEvent = null;

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
        if (hasAuthority == true)
        {
            transform.Find("Main Camera").gameObject.SetActive(true);
            transform.Find("Canvas").gameObject.SetActive(true);
        }


		m_MovementInputValue = joystick.InputDirection[2];
		m_TurnInputValue = joystick.InputDirection[0];

    }

    public void OnDropClick()
    {
        if (hasAuthority == false)
            return;

        if (pickupCount >= 1)
        {
            CmdDropPickup();
            pickupCount--;
            print("setting pick up count");
            countText.text = "Resources: " + pickupCount.ToString();
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
	public void OnTriggerStay(Collider other)
    {

        if (hasAuthority == false)
            return;
        
        if (other.gameObject.CompareTag("pickup"))
        {
            pickupTriggerDuration++;
        }
			

        if (pickupTriggerDuration > 500)
        {
			pickedUp = true;

            Destroy(other.gameObject);
            CmdtakePickup(other.gameObject);
            pickupTriggerDuration = 0;
            pickupCount++;
            countText.text = "Resources: " + pickupCount.ToString();
        }


    }

    private void OnTriggerExit(Collider other)
    {
        if (hasAuthority == false)
            return;
        
        if (other.gameObject.CompareTag("pickup"))
        {
            pickupTriggerDuration = 0;
        }
    }


    [Command]
    private void CmdtakePickup(GameObject pickupObj)
    {
        //later add func to update total pickup count
        RpctakePickup(pickupObj);
    }
    
    [ClientRpc]
    private void RpctakePickup(GameObject pickupObj)
    {
        Destroy(pickupObj);
    }

    [Command]
    private void CmdDropPickup()
    {
        GameObject pickup = Instantiate(pickupPrefab, transform.position, Quaternion.identity);
        //later add func to decrease total pickup count
        NetworkServer.Spawn(pickup);
    }


}