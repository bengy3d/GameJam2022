using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Player Settings")]
    [SerializeField] private GameObject player1Prefab;
    [SerializeField] private GameObject player2Prefab;
    [SerializeField] private TextMeshProUGUI player1ScoreText;
    [SerializeField] private TextMeshProUGUI player2ScoreText;
    
    [Header("Garbage Setting")]
    [SerializeField] private GameObject grabagePrefab;
    public int numberOfGarbage = 4;
    [Header("Time Setting")]

    public int startGameTime = 120;
    public TextMeshProUGUI timeText;        
    private GameObject[] spawnPoints;
    private GameObject[] desks;
    static Vector3[] garbagePoints;

    private float time;
    private Transform player1Spawn;
    private Transform player2Spawn;
    private int player1Score;
    private int player2Score;

    private void Update()
    {
        CheckGarbageNumber();
    }
    void Awake()
    {
        SpawnPlayers();
    }

    void Start(){
        time = startGameTime;
        player1ScoreText.text = player1Score.ToString();
        player2ScoreText.text = player2Score.ToString();

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


        if (spawnPoints.Length >= 2)
        {
            int firstSpawnIndex = 0;
            int secondSpawnIndex = 0;

            do
            {
                firstSpawnIndex = rnd.Next(0, spawnPoints.Length);
                secondSpawnIndex = rnd.Next(0, spawnPoints.Length);
            } while (firstSpawnIndex == secondSpawnIndex);

            player1Spawn = spawnPoints[firstSpawnIndex].transform;
            player2Spawn = spawnPoints[secondSpawnIndex].transform;

            Instantiate(player1Prefab, player1Spawn.position, Quaternion.identity);
            Instantiate(player2Prefab, player2Spawn.position, Quaternion.identity);
        }
    }

    private void CheckGarbageNumber()
    {
        int garbageNumberState = GameObject.FindGameObjectsWithTag("Garbage").Length - numberOfGarbage;


        if (garbageNumberState < 0)
        {
            for (int i = 0; i > garbageNumberState; i--)
            {
                SpawnGarbage();
            }
        }
    }

    private void SpawnGarbage()
    {
        desks = GameObject.FindGameObjectsWithTag("Desk");
        System.Random rnd = new System.Random();

        var garbagePositions = GameObject.FindGameObjectsWithTag("Garbage")
            .Select(garbage => garbage.transform.position);

        int deskIndex = rnd.Next(1, 9);
        GameObject desk = desks[deskIndex];

        float x = desk.transform.position.x;
        float y = desk.transform.position.y;
        float z = desk.transform.position.z;

        garbagePoints = new[] {
                new Vector3(x+1,y,z),
                new Vector3(x,y+1,z),
                new Vector3(x,y,z+1),
                new Vector3(x-1,y,z),
                new Vector3(x,y-1,z),
                new Vector3(x,y,z-1),
        };

        var validGarbagePoints = garbagePoints.Except(garbagePositions);

        int vectorIndex = rnd.Next(1, validGarbagePoints.Count());

        Instantiate(grabagePrefab, validGarbagePoints.ElementAt(vectorIndex), Quaternion.identity);
    }
}
