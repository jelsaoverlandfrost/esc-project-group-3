using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
	
	public Transform playerTransform;

	// Update is called once per frame
//	void Update()
//	{
//		if(playerTransform != null)
//		{
//			transform.position = playerTransform.position + new Vector3(0,3,0.4f);
//		}
//	}
// 
	public void setTarget(Transform target)
	{
		playerTransform = target;
		transform.position = playerTransform.position + new Vector3(0,3,0.4f);
		gameObject.transform.parent = playerTransform;
	}

}
