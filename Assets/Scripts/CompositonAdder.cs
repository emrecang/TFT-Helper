using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompositonAdder : MonoBehaviour
{
    
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
        for (int i = 0; i < PlayerManager.instance.compChampions.Count; i++)
        {
            if(go == PlayerManager.instance.compChampions[i])
            {
                return null;
            }
        }
        if(PlayerManager.instance.boardLimit > PlayerManager.instance.compChampions.Count)
        {
            PlayerManager.instance.compChampions.Add(go);
            AddTraits(go);
            UIManager.instance.RefreshBoardLimit();
        }

        return go;
    }
    public void AddTraits(GameObject go)
    {
        PlayerManager.instance.compTraits.Add(go.GetComponent<ChampionData>().traitsName1);
        PlayerManager.instance.compTraits.Add(go.GetComponent<ChampionData>().traitsName2);
        if (go.GetComponent<ChampionData>().traitsName3 != "")
            PlayerManager.instance.compTraits.Add(go.GetComponent<ChampionData>().traitsName3);
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
