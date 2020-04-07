using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonReader : MonoBehaviour
{
    public static JsonReader instance;
    public GameObject champTemp;

    void Awake()
    {
        instance = this;
    }
    string jsonData;
    public TextAsset textAsset;
    public List<Sprite> championSprites;
    public List<Sprite> traitsSprites;
    private void Start()
    {
        CreateChampBase();
    }
    int i = 0;
    int spriteIndex = 0;
    public void CreateChampBase()
    {
        jsonData = textAsset.ToString();

        ChampionList champList = JsonUtility.FromJson<ChampionList>(jsonData);
        
        GameObject parent = new GameObject();
        parent.name = "Champions";
        parent.gameObject.AddComponent<ChampionsManager>();
        foreach (ChampData champData in champList.targetObjects)
        {
            GameObject go = Instantiate(champTemp,parent.transform);
            go.GetComponent<ChampionData>().cost = champData.cost;
            go.GetComponent<ChampionData>().champName = champData.name;
            
            foreach (TraitsData traitsData in champList.targetObjects[i].traits)
            {
                go.GetComponent<ChampionData>().traitsName1 = traitsData.name1;
                go.GetComponent<ChampionData>().traitsName2 = traitsData.name2;
                if (traitsData.name3 != null)
                    go.GetComponent<ChampionData>().traitsName3 = traitsData.name3;
            }

            go.name = champData.name;
            go.GetComponent<SpriteRenderer>().sprite = championSprites[i    ];
            i++;
        }

    }
}

    [System.Serializable]
    public class ChampData
    {
        public string name;
        public string championId;
        public int cost;
        public string traitsName1;
        public string traitsName2;
        public string traitsName3;
        public List<TraitsData> traits = new List<TraitsData>();
    }

    [System.Serializable]
    public class TraitsData
    {
        public string name1;
        public string name2;
        public string name3;
    }

    [System.Serializable]
    public class ChampionList
    {
        public List<ChampData> targetObjects = new List<ChampData>();
    }

