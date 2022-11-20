using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigerBoxController : MonoBehaviour
{
    
    public List<GameObject> trashes = new List<GameObject>();
    public List<GameObject> bins = new List<GameObject>();
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Garbage")){
            trashes.Add(other.gameObject);
        }
      

    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Garbage")){
            trashes.Remove(other.gameObject);
        }
    }

    public void RemoveTrashOnIndex(int index){
        trashes.RemoveAt(index);
    }
}
