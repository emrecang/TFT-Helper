﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompositonAdder : MonoBehaviour
{
    public GameObject buildedComp;
    public List<Vector3> compAreaStart;
    
    private void Awake()
    {
        buildedComp = new GameObject();
        buildedComp.name = "Builded Comp";
        for (int i = 0; i < 9; i++)
        {
            compAreaStart.Add(new Vector3(i, -5.5f, 0));
        }
    }
    
    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            GameObject selected = SendRayGameObject();

            if (selected != null && CheckChampionExistOnComp(selected) && selected.layer == 8)
                DeleteChampfromComp(selected);


            if (selected != null && CheckChampionExistOnComp(selected) && PlayerManager.instance.compChampions.Count != PlayerManager.instance.boardLimit)
            {
                AddChampToComp(selected);
                AddToCompArea(selected, compAreaStart);
            }
        }
    }
    
    private bool CheckChampionExistOnComp(GameObject go)
    {
        if (PlayerManager.instance.compChampions.Contains(go))
            return false;

        return true;
    }

    private void AddChampToComp(GameObject go)
    {
        PlayerManager.instance.compChampions.Add(go);
        AddTraitsToComp(go);
        UIManager.instance.RefreshBoardLimit();
    }

    private void AddTraitsToComp(GameObject go)
    {
        PlayerManager.instance.compTraits.Add(go.GetComponent<ChampionData>().traitsName1);
        PlayerManager.instance.compTraits.Add(go.GetComponent<ChampionData>().traitsName2);

        if (go.GetComponent<ChampionData>().traitsName3 != "")
            PlayerManager.instance.compTraits.Add(go.GetComponent<ChampionData>().traitsName3);
    }

    private void AddToCompArea(GameObject go, List<Vector3> Comp_pz)
    {
        GameObject CompChamp = Instantiate(go, Comp_pz[0], new Quaternion(0f, 0f, 0f, 0f)) as GameObject;
        CompChamp.layer = 8;
        CompChamp.transform.parent = buildedComp.transform;

        Comp_pz.RemoveAt(0);
    }

    private void DeleteChampfromComp(GameObject go)
    {
        compAreaStart.Insert(0, go.transform.position);
        GameObject delete = null;
        foreach (var item in PlayerManager.instance.compChampions)
        {
            if (item.GetComponent<ChampionData>().champName == go.GetComponent<ChampionData>().champName)
            {
                delete = item;
            }
        }

        PlayerManager.instance.compTraits.Remove(go.GetComponent<ChampionData>().traitsName1);
        PlayerManager.instance.compTraits.Remove(go.GetComponent<ChampionData>().traitsName2);
        PlayerManager.instance.compTraits.Remove(go.GetComponent<ChampionData>().traitsName3);
        PlayerManager.instance.compChampions.Remove(delete);

        DestroyImmediate(go);
        UIManager.instance.RefreshBoardLimit();
        
    }

    private GameObject SendRayGameObject()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider.CompareTag("Champion"))
                return hit.transform.gameObject;

            else
                return null;
        }

        else
            return null;

    }
}
