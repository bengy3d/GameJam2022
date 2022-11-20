using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player: MonoBehaviour {
    
    [SerializeField] private int _speed = 5;

    [SerializeField] private TrigerBoxController colider;
    private Rigidbody _rb;
    private float x;
    private float z;

    private int score;
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
        x = Input.GetAxis(GameData.HORIZONTALP1);
        z = Input.GetAxis(GameData.VERTICALP1);

        pickGarbage = (int) Mathf.Round(Input.GetAxis("PickGarbage"));
        
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

            garbage = new GarbageUI("Puszka", "Metal");
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
            
        }
    }

}

public class GarbageUI{
    public string name;
    public string type;
    public GarbageUI(string _name, string _type) {
        name = _name;
        type = _type;
    }
}