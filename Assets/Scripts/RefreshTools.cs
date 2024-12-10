using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefreshTools : MonoBehaviour
{
    public List<GameObject> _tool;

    private void Start()
    {
        ChangeTool();
    }

    public void ChangeTool()
    {
        var Index = Random.Range(0, _tool.Count);
        SetActivTool(Index);
    }

    private void SetActivTool(int index)
    {
        for (int i = 0; i < _tool.Count; i++)
        {
            _tool[i].SetActive(i == index);
        }
    }
}
