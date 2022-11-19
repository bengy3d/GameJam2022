using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Player Settings")]
    [SerializeField] private GameObject player1Prefab;
    [SerializeField] private GameObject player2Prefab;
    [Header("Garbage Setting")]
    [SerializeField] private GameObject grabagePrefab;
    public int numberOfGarbage = 4;
    [Header("Time Setting")]

    public int startGameTime = 120;
    public TextMeshProUGUI timeText;        
    private GameObject[] spawnPoints;
    private float time;
    private Transform player1Spawn;
    private Transform player2Spawn;

    void Awake() {
        SpawnPlayers();
    }

    void Start(){
        time = startGameTime;
    }
    
    void FixedUpdate(){
        time -= Time.fixedDeltaTime;
        int minuts = (int)(time / 60);
        int secunds = (int)time - minuts * 60;
        timeText.text = minuts + ":" + secunds;
    }

    private void SpawnPlayers() {
        spawnPoints = GameObject.FindGameObjectsWithTag("PlayerSpawnPosition");
        System.Random rnd = new System.Random();
        
       
        if(spawnPoints.Length >= 2) {
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
