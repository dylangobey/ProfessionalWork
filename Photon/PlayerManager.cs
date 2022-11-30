using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System.IO;
using System.Linq;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class PlayerManager : MonoBehaviour
{
	PhotonView PV;

	GameObject controller;

	int kills;

	void Awake()
	{
		PV = GetComponent<PhotonView>();
	}

	void Start()
	{
		if(PV.IsMine)
		{
			CreateController();
		}
	}

	void CreateController()
	{
		Transform spawnpoint = SpawnManager.Instance.GetSpawnpoint();
		controller = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "MultiplayerPlayerControllerAnimated"), spawnpoint.position, spawnpoint.rotation, 0, new object[] { PV.ViewID });
	}

	public void Die()
	{
		StartCoroutine(DestroyController());
		StartCoroutine(WaitForRespawn());
	}

	IEnumerator DestroyController()
    {
		yield return new WaitForSeconds(5);
		PhotonNetwork.Destroy(controller);
    }

	IEnumerator WaitForRespawn()
    {
		yield return new WaitForSeconds(5);
		CreateController();
	}

	public void GetKill()
    {
		PV.RPC(nameof(RPC_GetKill), PV.Owner);
    }

	[PunRPC]
	void RPC_GetKill()
    {
		kills++;

		Hashtable hash = new Hashtable();
		hash.Add("kills", kills);
		PhotonNetwork.LocalPlayer.SetCustomProperties(hash);
    }

	public static PlayerManager Find(Player player)
    {
		return FindObjectsOfType<PlayerManager>().SingleOrDefault(x => x.PV.Owner == player);
    }
}