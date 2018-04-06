using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using UnityEngine.Events;

public class FrozenTest
{
	private string initialScenePath;
	GameObject enemyTest;
	GameObject playerTest;

	[SetUp]
	public void Setup()
	{
		Debug.Log("Load Scene");
		initialScenePath = SceneManager.GetActiveScene().path;
		SceneManager.LoadScene("Scenes/World");
	}

	[TearDown]
	public void TearDown()
	{
		SceneManager.LoadScene(initialScenePath);
	}

	[UnityTest]
	public IEnumerator FrozenTestEnumerator() 
	{
		yield return new WaitForSeconds (1);
		Debug.Log("**The test started**");
		enemyTest = (GameObject) MonoBehaviour.Instantiate (Resources.Load<GameObject> ("EnemyObj"));
		playerTest = (GameObject) MonoBehaviour.Instantiate (Resources.Load<GameObject> ("PlayerObj"));
		Debug.Log (playerTest == null);
		// enemyTest.GetComponent<NetworkIdentity> ().AssignClientAuthority(playerTest.GetComponent<NetworkIdentity>().connectionToClient);
	}

	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.CompareTag("EnemyObj")) {
			Assert.IsTrue(playerTest.GetComponent<MeshRenderer>().material == Freeze.frozen);
		}
	}
}


//public class PickUpTest
//{
//	private string initialScenePath;
//	GameObject playerTest;
//	public static GameObject pickUpTest;
//	public static int initialCount;
//	private int pickupTriggerDuration;
//	public static GameObject[] pickups;
//
//	[SetUp]
//	public void Setup()
//	{
//		Debug.Log("Load Scene");
//		initialScenePath = SceneManager.GetActiveScene().path;
//		SceneManager.LoadScene("Scenes/World");	
//	}
//
//	[TearDown]
//	public void TearDown()
//	{
//		SceneManager.LoadScene(initialScenePath);
//	}
//
//	public static bool Checker() {
//		if (pickups.Length != initialCount) {
//			return true;
//		}
//		return false;
//	}
//
//	[UnityTest]
//	public IEnumerator PickUpTestEnumerator()
//	{
//		UnityEvent pickUpEvent;
//		Debug.Log("**The test started**");
//		playerTest = (GameObject) MonoBehaviour.Instantiate (Resources.Load<GameObject> ("PlayerObj"));
//		pickUpTest = (GameObject) MonoBehaviour.Instantiate (Resources.Load<GameObject> ("BackGround"));
//		pickups = GameObject.FindGameObjectsWithTag("pickup");
//		initialCount = pickups.Length;
//		Debug.Log (initialCount);
//		yield return new WaitUntil(Checker);
//	}
//		
//}

public class PickUpNumberTest
{
	private string initialScenePath;
	GameObject playerTest;
	public static GameObject pickUpTest;
	public static int initialCount;
	private int pickupTriggerDuration;
	public static GameObject[] pickups;
	private static bool checker = false;

	[SetUp]
	public void Setup()
	{
		Debug.Log("Load Scene");
		initialScenePath = SceneManager.GetActiveScene().path;
		SceneManager.LoadScene("Scenes/World");	
	}

	[TearDown]
	public void TearDown()
	{
		SceneManager.LoadScene(initialScenePath);
	}

	public static bool Checker() {
		if (PlayerController.pickupCount > 0) {
			return true;
		}
		return false;
	}

	[UnityTest]
	public IEnumerator PickUpTestEnumerator()
	{
		UnityEvent pickUpEvent;
		Debug.Log("**The test started**");
		playerTest = (GameObject) MonoBehaviour.Instantiate (Resources.Load<GameObject> ("PlayerObj"));
		pickUpTest = (GameObject) MonoBehaviour.Instantiate (Resources.Load<GameObject> ("BackGround"));
		pickups = GameObject.FindGameObjectsWithTag("pickup");
		initialCount = pickups.Length;
		Debug.Log (initialCount);
		yield return new WaitUntil (Checker);
	}

}