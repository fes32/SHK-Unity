using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(CircleCollider2D))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Vector3 _targetPosition;
    private int _moveRadius = 4;
    private float _distanceToDie;

    public event UnityAction<Enemy> Dying;

    private void Start()
    {
        _targetPosition = GetRandomTargetPosition();
        _distanceToDie = GetComponent<CircleCollider2D>().radius;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _speed * Time.deltaTime);

        if (transform.position == _targetPosition)
        _targetPosition = GetRandomTargetPosition();
    }

    private Vector3 GetRandomTargetPosition()
    {
        return Random.insideUnitCircle * _moveRadius;
    }

    public void Die()
    {
        Dying?.Invoke(this);
    }
}