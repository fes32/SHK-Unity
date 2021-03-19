using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void Update()
    {
        float _currentSpeed = _speed * Time.deltaTime;

        if (Input.GetKey(KeyCode.W))
            transform.Translate(0, _currentSpeed, 0);

        if (Input.GetKey(KeyCode.S))
            transform.Translate(0, -_currentSpeed, 0);

        if (Input.GetKey(KeyCode.A))
            transform.Translate(-_currentSpeed, 0, 0);

        if (Input.GetKey(KeyCode.D))
            transform.Translate(_currentSpeed, 0, 0);
    }
}