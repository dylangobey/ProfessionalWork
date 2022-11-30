using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamSpawnManager : MonoBehaviour
{
    public static TeamSpawnManager instance;
    GameObject[] redTeamSpawns;
    GameObject[] blueTeamSpawns;

    private void Awake()
    {
        instance = this;
        redTeamSpawns = GameObject.FindGameObjectsWithTag("RedSpawn");
        blueTeamSpawns = GameObject.FindGameObjectsWithTag("BlueSpawn");
    }

    public Transform GetRandomRedSpawn()
    {
        return redTeamSpawns[Random.Range(0, redTeamSpawns.Length)].transform;
    }

    public Transform GetRandomBlueSpawn()
    {
        return blueTeamSpawns[Random.Range(0, blueTeamSpawns.Length)].transform;
    }

    public Transform GetTeamSpawn(int teamNumber)
    {
        return teamNumber == 0 ? GetRandomBlueSpawn() : GetRandomRedSpawn();
    }
}
