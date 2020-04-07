using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompositonAdder : MonoBehaviour
{
    public List<GameObject> compChampions = new List<GameObject>();
    public List<string> compTraits = new List<string>();
    public int level = 1;
    private void Update()
    {
        if(Input.GetMouseButtonUp(0))
        {
            GameObject selected = SendRayGameObject();
            if(selected != null)
            {
                CheckChampionExistOnComp(selected);
            }
        }
    }
    public GameObject CheckChampionExistOnComp(GameObject go)
    {
        for (int i = 0; i < compChampions.Count; i++)
        {
            if(go == compChampions[i])
            {
                return null;
            }
        }
        if(level > compChampions.Count)
        {
            compChampions.Add(go);
            AddTraits(go);
        }

        return go;
    }
    public void AddTraits(GameObject go)
    {
        compTraits.Add(go.GetComponent<ChampionData>().traitsName1);
        compTraits.Add(go.GetComponent<ChampionData>().traitsName2);
        if (go.GetComponent<ChampionData>().traitsName3 != "")
            compTraits.Add(go.GetComponent<ChampionData>().traitsName3);
    }
    public GameObject SendRayGameObject()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider.CompareTag("Champion"))
            {
                return hit.transform.gameObject;
            }
            else
            {
                return null;
            }

        }
        else
        {
            return null;
        }
    }
}
