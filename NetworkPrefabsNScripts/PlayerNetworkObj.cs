using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerNetworkObj : NetworkBehaviour {
	
	private void Start()
	{
//		if (isServer)
//		{
//			CmdSpawnEnemy();
//		}
		 if (isLocalPlayer == true)
		{
			CmdSpawnPlayer();
		}
	}

	public GameObject playerObjPrefab;
	
	[Command]
	private void CmdSpawnPlayer()
	{
		//spawn player at playerNetworkObj position
		GameObject playerObj = Instantiate(playerObjPrefab, transform.position, Quaternion.identity);
		NetworkServer.SpawnWithClientAuthority(playerObj,connectionToClient);
	}

	public GameObject enemyObjPrefab;
	
	[Command]
	private void CmdSpawnEnemy()
	{
		GameObject enemyObj = Instantiate(enemyObjPrefab, transform.position, Quaternion.identity);
		NetworkServer.SpawnWithClientAuthority(enemyObj,connectionToClient);
	}

}
