using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player playerPrefab;
    // Start is called before the first frame update
    private Player p1;
          
    private GameObject[] spawnPoints;

    private Transform playerSpawn;

    void Start()
    {   
        spawnPoints = GameObject.FindGameObjectsWithTag("PlayerSpawnPosition");
        
        if(spawnPoints.Length > 0){
            System.Random rand = new System.Random();

            int spawnIndex = rand.Next(0, spawnPoints.Length);

            playerSpawn = spawnPoints[spawnIndex].transform;

            Instantiate(playerPrefab, playerSpawn.position, Quaternion.identity);
        }
    }


}
