using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject player1Prefab;
    [SerializeField] private GameObject player2Prefab;

    [SerializeField] private GameObject grabagePrefab;
    public int numberOfGarbage = 4;
        
    private GameObject[] spawnPoints;

    private Transform player1Spawn;
    private Transform player2Spawn;

    void Awake() {
        SpawnPlayers();
    }
    // Update is called once per frame
    private void SpawnPlayers() {
        spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPosition");
        System.Random rnd = new System.Random();
        
       
        if(spawnPoints.Length > 2) {
            int firstSpawnIndex = 0;
            int secondSpawnIndex = 0;

            do{
                firstSpawnIndex = rnd.Next(0, spawnPoints.Length);
                secondSpawnIndex = rnd.Next(0, spawnPoints.Length);
            } while(firstSpawnIndex == secondSpawnIndex)  ;
            
            player1Spawn = spawnPoints[firstSpawnIndex].transform;
            player2Spawn = spawnPoints[secondSpawnIndex].transform;

            Instantiate(player1Prefab, player1Spawn.position, Quaternion.identity);
            Instantiate(player2Prefab, player2Spawn.position, Quaternion.identity);
        }
    }

    private void SpawnGarbage(){

    }
}
