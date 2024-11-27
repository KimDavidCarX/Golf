using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefreshTools : MonoBehaviour
{
    public List<GameObject> _tools;

    private void Start()
    {
        ChangeTool();
    }

    public void ChangeTool()
    {
        var Index = Random.Range(0, _tools.Count);
        SetActivTool(Index);
    }

    private void SetActivTool(int index)
    {
        for (int i = 0; i < _tools.Count; i++)
        {
            _tools[i].SetActive(i == index);
        }
    }
}
