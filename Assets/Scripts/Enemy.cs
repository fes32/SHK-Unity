using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _distanceToDie;

    private Vector3 _targetPosition;
    private Player _target;

    public event UnityAction<Enemy> Dying;

    private void Start()
    {
        _targetPosition = GetRandomTargetPosition();
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _speed * Time.deltaTime);

        if (transform.position == _targetPosition)
            _targetPosition = GetRandomTargetPosition();

        if (Vector3.Distance(transform.position, _target.transform.position) < _distanceToDie)
            Die();
    }

    private Vector3 GetRandomTargetPosition()
    {
         return Random.insideUnitCircle * 4;
    }

    public void Die()
    {  
        Dying?.Invoke(this);
    }

    public void Spawn(Player player)
    {
        _target = player;
    }
}