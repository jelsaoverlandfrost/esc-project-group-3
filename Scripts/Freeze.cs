using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Freeze : NetworkBehaviour {

    public static Material frozen;

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            CmdFreeze(collision.gameObject);
        }

//        if (collision.gameObject.name == "Player2")
//        {
//            GameObject.Find("Player2").GetComponent<Player2Controller>().enabled = false;
//            GameObject.Find("Player2").GetComponent<MeshRenderer>().material = frozen;
//        }
    }

    [Command]
    private void CmdFreeze(GameObject player)
    {
        RpcFreeze(player);
    }

    [ClientRpc]
    private void RpcFreeze(GameObject player)
    {
        player.GetComponent<PlayerController>().enabled = false;
        player.GetComponent<MeshRenderer>().material = frozen;
    }
}
