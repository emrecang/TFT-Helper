using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChampionsManager : MonoBehaviour
{
    public List<string> traits = new List<string>();
    public List<GameObject> champions = new List<GameObject>();
    void Start()
    {
        GetTraitsFromChild();
        GetChampionsFromChild();
    }
    public void GetTraitsFromChild()
    {
        
        for (int i = 0; i < transform.childCount; i++)
        {
            CheckTraitExist(transform.GetChild(i).GetComponent<ChampionData>().traitsName1);
            CheckTraitExist( transform.GetChild(i).GetComponent<ChampionData>().traitsName2);
            if(transform.GetChild(i).GetComponent<ChampionData>().traitsName3 != "")
                CheckTraitExist(transform.GetChild(i).GetComponent<ChampionData>().traitsName3);
        }
    }
    public void GetChampionsFromChild()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            champions.Add(transform.GetChild(i).gameObject);
        }
    }
    public string CheckTraitExist(string data)
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
