using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject player1Prefab;
    [SerializeField] private GameObject player2Prefab;

    [SerializeField] private GameObject grabagePrefab;
    public int numberOfGarbage = 4;

    private GameObject[] spawnPoints;
    private GameObject[] desks;
    static Vector3[] garbagePoints;

    private Transform player1Spawn;
    private Transform player2Spawn;

    private void Update()
    {
        CheckGarbageNumber();
    }
    void Awake()
    {
        SpawnPlayers();
    }
    // Update is called once per frame
    private void SpawnPlayers()
    {
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
