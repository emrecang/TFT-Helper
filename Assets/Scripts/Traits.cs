using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traits : MonoBehaviour
{
    public List<string> traits = new List<string>();
    public List<GameObject> champions = new List<GameObject>();
    void Start()
    {
        GetTraitsFromChild();
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
