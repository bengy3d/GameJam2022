using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static JSONReader;

public class Player: MonoBehaviour {
    [SerializeField] private string verticalAxis;
    [SerializeField] private string horizontalAxis;
    [SerializeField] private string pickGarbageAxis;

    [SerializeField] private int _speed = 5;

    [SerializeField] private TrigerBoxController colider;
    [SerializeField] private JSONReader database;
    private Rigidbody _rb;
    private float x;
    private float z;

    private int score = 0;
    private int pickGarbage;
    private GarbageSpawner garbageSpawner;

    private bool hasGarbage = false;

    private GarbageUI garbage;

    void Start(){
        _rb = GetComponent<Rigidbody>();
        score = 0;
    }

    void Update()
    {
        x = Input.GetAxis(horizontalAxis);
        z = Input.GetAxis(verticalAxis);

        pickGarbage = (int) Mathf.Round(Input.GetAxis(pickGarbageAxis));
        
    }

    public void SetGarbageSpawner(ref GarbageSpawner gs){
        garbageSpawner = gs;
    }

    void FixedUpdate() {
        _rb.MovePosition(transform.position + new Vector3(x, 0, z) * Time.fixedDeltaTime * _speed) ;
        _rb.velocity = new Vector3(0, 0, 0);

        if(!hasGarbage && pickGarbage > 0 && colider.trashes.Count > 0) {
            
            
            float minDistance = Vector3.Distance(colider.trashes[0].transform.position, transform.position);
            int minIndex = 0;
            for(int i = 0; i < colider.trashes.Count; i++ ){
                if(Vector3.Distance(colider.trashes[i].transform.position, transform.position) < minDistance){
                    minIndex = i;
                    minDistance = Vector3.Distance(colider.trashes[i].transform.position, transform.position);
                }
            }
            
            garbageSpawner.DestroyGarbage(colider.trashes[minIndex]);
            colider.RemoveTrashOnIndex(minIndex);

            garbageSpawner.SpawnGarbage();
            pickGarbage = 0;

            garbage = database.getRandomGarbage();
            hasGarbage = true;
            
        }

        if(hasGarbage && pickGarbage > 0 && colider.bins.Count > 0) {
            float minDistance = Vector3.Distance(colider.bins[0].transform.position, transform.position);
            int minIndex = 0;
            for(int i = 0; i < colider.bins.Count; i++ ){
                if(Vector3.Distance(colider.bins[i].transform.position, transform.position) < minDistance){
                    minIndex = i;
                    minDistance = Vector3.Distance(colider.bins[i].transform.position, transform.position);
                }
            }
            //print(colider.bins[minIndex].GetComponentInChildren<Rigidbody>().name); 
            if (colider.bins[minIndex].GetComponentInChildren<Rigidbody>().name == garbage.type) {
                ++score;
            }
            print(score);
            hasGarbage = false;
            garbage = null;
            
        }
    }

    public int GetScore(){
        return score;
    }

    public string GetGarbageName(){
        if(garbage == null){
            return "Brak";
        }
        
        return garbage.name;
    }

    public string GetGarbageType(){
        if(garbage == null){
            return null;
        }
        
        return garbage.type;
    }

    public string GetGarbageImg(){
        if(garbage == null){
            return "Sprites/DEFAULT";
        }
        
        return "Sprites/"+garbage.imgName; 
    }

}
