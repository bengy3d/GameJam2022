using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Spawning : MonoBehaviour
{
    // Start is called before the first frame update
    static public GameObject garbage;
    static public float radius = 1;
    static List<Vector3> spawnPoints;
    static void SpawnObject(string desk)
    {
        float x = GameObject.Find(desk).transform.position.x;
        float y = GameObject.Find(desk).transform.position.y;
        float z = GameObject.Find(desk).transform.position.z;


        spawnPoints = new List<Vector3> {
                new Vector3(x+1,y,z),
                new Vector3(x,y+1,z),
                new Vector3(x,y,z+1),
                new Vector3(x-1,y,z),
                new Vector3(x,y-1,z),
                new Vector3(x,y,z-1),
        };

        System.Random rnd = new System.Random();
        int vectorIndex = rnd.Next(1, 6);

        Instantiate(garbage,spawnPoints[vectorIndex], Quaternion.identity);
    }

}
