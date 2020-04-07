using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ChampionSorter : MonoBehaviour
{
    public float sortGap;
    public IEnumerator Start()
    {
        yield return new WaitForSeconds(0.05f);
        SortByName();
    }
    public void SortByCost()
    {
        GameObject temp = null;
        for (int i = 0; i < ChampionsManager.instance.champions.Count; i++)
        {
            for (int j = i + 1; j < ChampionsManager.instance.champions.Count; j++)
            {
                if (ChampionsManager.instance.champions[i].GetComponent<ChampionData>().cost > ChampionsManager.instance.champions[j].GetComponent<ChampionData>().cost)
                {
                    temp = ChampionsManager.instance.champions[i];
                    ChampionsManager.instance.champions[i] = ChampionsManager.instance.champions[j];
                    ChampionsManager.instance.champions[j] = temp;
                }
            }
        }
        ChangePositionAfterSort();
    }
    public void SortByName()
    {
        GameObject temp = null;

        for (int i = 0; i < ChampionsManager.instance.champions.Count; i++)
        {
            for (int j = i + 1; j < ChampionsManager.instance.champions.Count; j++)
            {
                if (ChampionsManager.instance.champions[i].GetComponent<ChampionData>().champName[0] > ChampionsManager.instance.champions[j].GetComponent<ChampionData>().champName[0])
                {
                    temp = ChampionsManager.instance.champions[i];
                    ChampionsManager.instance.champions[i] = ChampionsManager.instance.champions[j];
                    ChampionsManager.instance.champions[j] = temp;
                }
            }
        }
        ChangePositionAfterSort();
    }
    private void ChangePositionAfterSort()
    {
        int j = 0;
        int k = 0;
        for (int i = 0; i < ChampionsManager.instance.champions.Count; i++)
        {
            ChampionsManager.instance.champions[i].transform.position = Vector3.right * k * sortGap + Vector3.down * j * sortGap;
            k++;
            if (k > 9)
            {
                k = 0;
                j++;
            }
        }
    }
}
