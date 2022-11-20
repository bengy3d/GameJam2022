using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageSpawner: MonoBehaviour
{
    private GameObject[] garbageSpawnPoints;
    private GameObject garbagePrefab;
    private List<GameObject> garbages = new List<GameObject>();
    public List<int> used = new List<int>();

    public void SetGarbagePrefab(GameObject garbPre){
        garbagePrefab = garbPre;
    }
    public void InitGarabge(int numberOfGarbage){
        
        garbageSpawnPoints = GameObject.FindGameObjectsWithTag("GarbageSpawnPosition");

        if(garbageSpawnPoints.Length > numberOfGarbage){
            System.Random rand = new System.Random();
            while(used.Count < numberOfGarbage){
                
                int spawnIndex = rand.Next(garbageSpawnPoints.Length);
                if(!used.Contains(spawnIndex)){
                    Transform garbageSpawn = garbageSpawnPoints[spawnIndex].transform;
                    used.Add(spawnIndex);
                    garbages.Add(Instantiate(garbagePrefab, garbageSpawn.position, Quaternion.identity));
                }

            }

        }
    }

    public void DestroyGarbage(GameObject garbage){

        int index = garbages.FindIndex(garbage1 => garbage == garbage1);
        Destroy(garbage);
        
        used.RemoveAt(index);
        garbages.RemoveAt(index);

    }

    public void SpawnGarbage(){
        System.Random rand = new System.Random();
        int spawnIndex;
        int i = 1;
        while(used.Contains(spawnIndex = rand.Next(garbageSpawnPoints.Length)) || !(i++ > 0)){ if(i > 100) break;}
        if(i > 100){
            for(int j = 0; j < garbageSpawnPoints.Length; j++){
                if(!used.Contains(j)) {
                    spawnIndex = j;
                    break;
                }
            }
        }
        Transform garbageSpawn = garbageSpawnPoints[spawnIndex].transform;
        used.Add(spawnIndex);
        garbages.Add(Instantiate(garbagePrefab, garbageSpawn.position, Quaternion.identity));

    }

}
