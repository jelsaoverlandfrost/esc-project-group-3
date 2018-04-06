using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class NewPlayModeTest {

	[Test]
	public void NewPlayModeTestSimplePasses() {
		// Use the Assert class to test conditions.
		if (PlayerController.click) {
			Assert.AreEqual(PlayerController.pickupCount, 0);
		}
	}

//	// A UnityTest behaves like a coroutine in PlayMode
//	// and allows you to yield null to skip a frame in EditMode
//	[UnityTest]
//	public IEnumerator NewPlayModeTestWithEnumeratorPasses() {
//		setUp ();
//
//		// Use the Assert class to test conditions.
//		// yield to skip a frame
//		yield return WaitForSeconds(3);
//	}
//
//	void setUp() {
//		MonoBehaviour.Instantiate (Resources.Load<GameObject> ("Player1"));
//		MonoBehaviour.Instantiate (Resources.Load<GameObject> ("Earth"));
//		MonoBehaviour.Instantiate (Resources.Load<GameObject> ("Pickups"));
//	}
}
