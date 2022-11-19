using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player playerPrefab;
    // Start is called before the first frame update
    private Player p1;
          
    private GameObject[] playerSpawnPoints;

    private Transform playerSpawn;

    private GameObject[] garbageSpawnPoints;

    void Start()
    {   
        playerSpawnPoints = GameObject.FindGameObjectsWithTag("PlayerSpawnPosition");
        
        if(playerSpawnPoints.Length > 0){
            System.Random rand = new System.Random();

            int spawnIndex = rand.Next(playerSpawnPoints.Length);

            playerSpawn = playerSpawnPoints[spawnIndex].transform;

            Instantiate(playerPrefab, playerSpawn.position, Quaternion.identity);
        }
    
        garbageSpawnPoints = GameObject.FindGameObjectsWithTag("Garbage");
    }




}
