using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigerBoxController : MonoBehaviour
{
    
    public List<GameObject> trashes = new List<GameObject>();
    public List<GameObject> bins = new List<GameObject>();
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Trash")){
            trashes.Add(other.gameObject);
        }
      

    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Trash")){
            trashes.Remove(other.gameObject);
        }
    }
}
