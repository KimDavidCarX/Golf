using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudController : MonoBehaviour
{
    private int _targetIndex = 0;
    private bool _moved = false;
    public float _moveSpeed = 9f;
    public Cloud _cloud;
    public Transform[] _targets;

    public void Action()
    {
        if (_moved)
        {
            return;
        }
        _moved = true;
        _cloud.StopFX();
        _targetIndex++;
        if(_targetIndex >= _targets.Length)
        {
            _targetIndex = 0;
        }
    }

    public void Update()
    {
        if (!_moved)
        {
            return;
        }

        Transform target = _targets[_targetIndex];
        Vector3 targetPosition = new Vector3(target.position.x, _cloud.transform.position.y, target.position.z);
        Vector3 offset = (targetPosition - _cloud.transform.position).normalized * Time.deltaTime * _moveSpeed;
        if (Vector3.Distance(_cloud.transform.position, targetPosition) < 0.1f)
        {
            _cloud.transform.position = targetPosition;
            _moved = false;
            _cloud.PlayFX();
        }
        else
        {
            _cloud.transform.Translate(offset);
        }
    }
}
