using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.VectorGraphics;
using TMPro;

public class GameManager : MonoBehaviour
{   
    
    [Header("Player1 Settings")]
    [SerializeField] private Player player1Prefab;
    
    [SerializeField] private TextMeshProUGUI player1ScoreText;
    
    [SerializeField] private TextMeshProUGUI player1InventoryText;
    
    [SerializeField] private SVGImage player1InvetoryImg;

    [Header("Player2 Settings")]
    [SerializeField] private Player player2Prefab;
    
    [SerializeField] private TextMeshProUGUI player2ScoreText;
    
    [SerializeField] private TextMeshProUGUI player2InventoryText;
    [SerializeField] private SVGImage player2InvetoryImg;

    [Header("Garbage Setting")]
    [SerializeField] private GameObject garbagePrefab;
    [SerializeField] private int numberOfGarbage = 4;

    [Header("Time Setting")]
    [SerializeField] private int startGameTime = 120;
    [SerializeField] private TextMeshProUGUI timeText;
    private Player p1;
    private Player p2;
    private GameObject[] playerSpawnPoints;

    private Transform player1Spawn;
    private Transform player2Spawn;

    private GameObject[] garbageSpawnPoints;
    private GarbageSpawner garbageSpawner;
    private float time;
    void Awake(){
        garbageSpawner = new GarbageSpawner();
        garbageSpawner.SetGarbagePrefab(garbagePrefab);
    }
    void Start()
    {   
        playerSpawnPoints = GameObject.FindGameObjectsWithTag("PlayerSpawnPosition");
        print(playerSpawnPoints.Length);
        if(playerSpawnPoints.Length > 1){
            System.Random rand = new System.Random();
            int spawnP1Index;
            int spawnP2Index;

            do{
                spawnP1Index = rand.Next(playerSpawnPoints.Length);
                spawnP2Index = rand.Next(playerSpawnPoints.Length);
            
            }while(spawnP1Index == spawnP2Index);
            

            player1Spawn = playerSpawnPoints[spawnP1Index].transform;
            player2Spawn = playerSpawnPoints[spawnP2Index].transform;
            
            p1 = Instantiate(player1Prefab, player1Spawn.position, Quaternion.identity);
            p2 = Instantiate(player2Prefab, player2Spawn.position, Quaternion.identity);

            p1.SetGarbageSpawner(ref garbageSpawner);
            p2.SetGarbageSpawner(ref garbageSpawner);
        }

        garbageSpawner.InitGarabge(numberOfGarbage);

        time = startGameTime;

        player1ScoreText.text = p1.GetScore().ToString();
        player2ScoreText.text = p2.GetScore().ToString();
        player1InventoryText.text = p1.GetGarbageName();
        player2InventoryText.text = p2.GetGarbageName();
        Sprite imgP1 = Resources.Load<Sprite>(p1.GetGarbageImg());
        player1InvetoryImg.sprite = imgP1;
        Sprite imgP2 = Resources.Load<Sprite>(p2.GetGarbageImg());
        player2InvetoryImg.sprite = imgP2;
        
    }
    
    void FixedUpdate(){
        if(time < 0) GameOver(); 
        setScore(player1ScoreText, p1.GetScore(), p1.GetStreak());
        setScore(player2ScoreText, p2.GetScore(), p2.GetStreak());

        player1InventoryText.text = p1.GetGarbageName();
        player2InventoryText.text = p2.GetGarbageName();

        Sprite imgP1 = Resources.Load<Sprite>(p1.GetGarbageImg());
        player1InvetoryImg.sprite = imgP1;
        Sprite imgP2 = Resources.Load<Sprite>(p2.GetGarbageImg());
        player2InvetoryImg.sprite = imgP2;


        time -= Time.fixedDeltaTime;
        int minuts = (int)(time / 60);
        int secunds = (int)time - minuts * 60;
        timeText.text = minuts + ":" + secunds;
        
    }

    void GameOver(){

    }

    void setScore(TextMeshProUGUI playerScoreText, int score, int streak){
        if(streak > 6) playerScoreText.color =  new Color(1.0f, 0.1f, 0.1f, 1.0f);
        else if(streak > 2) playerScoreText.color =  new Color(1.0f, 0.8f, 0f, 1.0f);
        else playerScoreText.color =  new Color(0f,0f, 0f, 1.0f);

        playerScoreText.text = score.ToString();
    }



}
