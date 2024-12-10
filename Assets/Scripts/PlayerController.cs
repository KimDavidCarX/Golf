using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Spawn _spawn;
    public CloudController _cloud;
    public List<RefreshTools> _refreshTools;
    public FirstScript _while;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            _spawn.Spawner();
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            _cloud.Action();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            foreach (var villager in _refreshTools)
            {
                villager.ChangeTool();
            }
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            _while.Action();
        }
    }
}
