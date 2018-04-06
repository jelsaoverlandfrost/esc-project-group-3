using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class UnFreeze : NetworkBehaviour {

    public Material unFronzen_player1;
    public Material unFronzen_player2;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            CmdUnFreeze(collision.gameObject);
        }

//        if(collision.gameObject.name == "Player2")
//        {
//            GameObject.Find("Player2").GetComponent<Player2Controller>().enabled = true;
//            GameObject.Find("Player2").GetComponent<MeshRenderer>().material = unFronzen_player2;
//        }
    }
    
    [Command]
    private void CmdUnFreeze(GameObject player)
    {
        RpcUnFreeze(player);
    }

    [ClientRpc]
    private void RpcUnFreeze(GameObject player)
    {
        player.GetComponent<PlayerController>().enabled = true;
        player.GetComponent<MeshRenderer>().material = unFronzen_player1;
    }
}
