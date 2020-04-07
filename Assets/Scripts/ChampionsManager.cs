using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChampionsManager : MonoBehaviour
{
    public static ChampionsManager instance;
    private void Awake()
    {
        instance = this;
    }
    public List<string> traits = new List<string>();
    public List<GameObject> champions = new List<GameObject>();
    private void Start()
    {
        GetTraitsFromChild();
        GetChampionsFromChild();
    }
    private void GetTraitsFromChild()
    {
        
        for (int i = 0; i < transform.childCount; i++)
        {
            CheckTraitExist(transform.GetChild(i).GetComponent<ChampionData>().traitsName1);
            CheckTraitExist( transform.GetChild(i).GetComponent<ChampionData>().traitsName2);
            if(transform.GetChild(i).GetComponent<ChampionData>().traitsName3 != "")
                CheckTraitExist(transform.GetChild(i).GetComponent<ChampionData>().traitsName3);
        }
    }
    private void GetChampionsFromChild()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            champions.Add(transform.GetChild(i).gameObject);
        }
    }
    private string CheckTraitExist(string data)
    {;
        if(traits.Count > 0)
        {
            for (int i = 0; i < traits.Count; i++)
            {
                if (data == traits[i])
                {
                    return "";
                }
            }
        }
        
        traits.Add(data);
        return data;
    }
}
