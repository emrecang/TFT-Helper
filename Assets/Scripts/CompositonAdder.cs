using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompositonAdder : MonoBehaviour
{
    public GameObject buildedComp;

    public Vector3 CompAreaStart;

    private void Awake()
    {
        buildedComp = new GameObject();
        buildedComp.name = "Builded Comp";
        CompAreaStart = new Vector3(0, -6, 0);

    }
    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            GameObject selected = SendRayGameObject();

            if (selected != null && CheckChampionExistOnComp(selected))
                DeleteChampfromComp(selected);


            if (selected != null && CheckChampionExistOnComp(selected) && PlayerManager.instance.compChampions.Count != PlayerManager.instance.boardLimit)
            {
                AddChampToComp(selected);

                AddToCompArea(selected, CompAreaStart);
                CompAreaStart.x++;
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

    public void AddToCompArea(GameObject go, Vector3 Comp_pz)
    {
        GameObject CompChamp = Instantiate(go, Comp_pz, new Quaternion(0f, 0f, 0f, 0f)) as GameObject;
        CompChamp.layer = 8;
        CompChamp.transform.parent = buildedComp.transform;
    }

    void DeleteChampfromComp(GameObject go)
    {
        if (go.layer == 8)
        {
            PlayerManager.instance.compChampions.Remove(go);
            DestroyImmediate(go);
            UIManager.instance.RefreshBoardLimit();
        }
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
