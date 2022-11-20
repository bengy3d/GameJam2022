using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{   
    public int numberOfGarbage = 4;
    public Player playerPrefab;
    public GameObject garbagePrefab;
    private Player p1;
          
    private GameObject[] playerSpawnPoints;

    private Transform playerSpawn;

    private GameObject[] garbageSpawnPoints;
    private GarbageSpawner garbageSpawner;

    void Awake(){
        garbageSpawner = new GarbageSpawner();
        garbageSpawner.SetGarbagePrefab(garbagePrefab);
    }
    void Start()
    {   
        playerSpawnPoints = GameObject.FindGameObjectsWithTag("PlayerSpawnPosition");
        
        if(playerSpawnPoints.Length > 0){
            System.Random rand = new System.Random();

            int spawnIndex = rand.Next(playerSpawnPoints.Length);

            playerSpawn = playerSpawnPoints[spawnIndex].transform;

            p1 = Instantiate(playerPrefab, playerSpawn.position, Quaternion.identity);
            p1.SetGarbageSpawner(ref garbageSpawner);
        }

        garbageSpawner.InitGarabge(numberOfGarbage);
    }
    




}
