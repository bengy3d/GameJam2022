using System;
using UnityEngine;

class JSONReader: MonoBehaviour {
    public TextAsset jsonFile;
    
    private GarbagesUI garbageCollection;
    void Start()
    {
        garbageCollection = JsonUtility.FromJson<GarbagesUI>(jsonFile.text);
    }

    [Serializable]
    public class GarbageUI{
        public string name;
        public string type;
        public string imgName;

        public string imgUrl;
    }

    public GarbageUI getRandomGarbage(){
        System.Random rand = new System.Random();

        int garbageIndex = rand.Next(garbageCollection.garbages.Length);

        return garbageCollection.garbages[garbageIndex];
    }

    [Serializable]
    public class GarbagesUI
    {
        //employees is case sensitive and must match the string "employees" in the JSON.
        public GarbageUI[] garbages;
    }
}