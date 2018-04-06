using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DropController : MonoBehaviour
{
	public Button dropButton;

	void Start()
	{
		Button btn = dropButton.GetComponent<Button>();
		btn.onClick.AddListener(click);
	}

	void click()
	{	
		PlayerController.click = true;
		Debug.Log("You have clicked the button!");
	}
}