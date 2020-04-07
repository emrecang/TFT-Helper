using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;
    private void Awake()
    {
        instance = this;
    }

    public int boardLimit;
    public List<GameObject> compChampions = new List<GameObject>();
    public List<string> compTraits = new List<string>();

    private void Start()
    {
        if (boardLimit < 1)
            boardLimit = 1;
    }
}
