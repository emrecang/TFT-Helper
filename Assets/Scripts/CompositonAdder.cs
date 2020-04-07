using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompositonAdder : MonoBehaviour
{
    public GameObject buildedComp;

    public List<Vector3> CompAreaStart;

    private void Awake()
    {
        buildedComp = new GameObject();
        buildedComp.name = "Builded Comp";

        for (int i = 0; i < 9; i++)
        {
            CompAreaStart.Add(new Vector3(i, -6, 0));
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

                AddToCompArea(selected, CompAreaStart);

            }
        }
    }
    public bool CheckChampionExistOnComp(GameObject go)
    {
        if (PlayerManager.instance.compChampions.Contains(go))
            return false;

        return true;
    }

    public void AddChampToComp(GameObject go)
    {
        PlayerManager.instance.compChampions.Add(go);
        AddTraits(go);
        UIManager.instance.RefreshBoardLimit();
    }

    public void AddTraits(GameObject go)
    {
        PlayerManager.instance.compTraits.Add(go.GetComponent<ChampionData>().traitsName1);
        PlayerManager.instance.compTraits.Add(go.GetComponent<ChampionData>().traitsName2);

        if (go.GetComponent<ChampionData>().traitsName3 != "")
            PlayerManager.instance.compTraits.Add(go.GetComponent<ChampionData>().traitsName3);
    }

    public void AddToCompArea(GameObject go, List<Vector3> Comp_pz)
    {
        GameObject CompChamp = Instantiate(go, Comp_pz[0], new Quaternion(0f, 0f, 0f, 0f)) as GameObject;
        CompChamp.layer = 8;
        CompChamp.transform.parent = buildedComp.transform;

        Comp_pz.RemoveAt(0);
    }

    void DeleteChampfromComp(GameObject go)
    {

        CompAreaStart.Insert(0, go.transform.position);
        PlayerManager.instance.compChampions.RemoveAll(x => go);


        PlayerManager.instance.compTraits.Remove(go.GetComponent<ChampionData>().traitsName1);
        PlayerManager.instance.compTraits.Remove(go.GetComponent<ChampionData>().traitsName2);
        if(go.GetComponent<ChampionData>().traitsName2!=null)
            PlayerManager.instance.compTraits.Remove(go.GetComponent<ChampionData>().traitsName2);

        UIManager.instance.RefreshBoardLimit();
        DestroyImmediate(go);

    }
    public GameObject SendRayGameObject()
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
