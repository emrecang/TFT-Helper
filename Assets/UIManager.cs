using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    private void Awake()
    {
        instance = this;
    }
    public GameObject boardLimitPanel;

    public void RefreshBoardLimit()
    {
        var compCount = PlayerManager.instance.compChampions.Count.ToString();
        var boardLimit = PlayerManager.instance.boardLimit.ToString();
        boardLimitPanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Board Limit \n" + compCount + "/" + boardLimit; 
    }
    public void ChangeLimitUp()
    {
        if (PlayerManager.instance.boardLimit >= 1)
        {
            PlayerManager.instance.boardLimit += 1;
        }
        RefreshBoardLimit();
    }
    public void ChangeLimitDown()
    {
        if (PlayerManager.instance.boardLimit >= 2 && PlayerManager.instance.boardLimit > PlayerManager.instance.compChampions.Count)
        {
            PlayerManager.instance.boardLimit -= 1;
        }
        RefreshBoardLimit();
    }
}
