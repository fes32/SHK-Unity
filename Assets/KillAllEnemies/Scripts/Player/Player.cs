using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void Update()
    {
        float _currentSpeed = _speed * Time.deltaTime;
        Move();
    }

    private void Move()
    {
        float yDirection = Input.GetAxis("Vertical");
        float xDirection = Input.GetAxis("Horizontal");

        float currentSpeed = _speed * Time.deltaTime;
        Vector3 targetPosition = new Vector3(transform.position.x + xDirection * currentSpeed, transform.position.y + yDirection * currentSpeed);
        transform.position = targetPosition;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
        {
            enemy.Die();
        }
        else if (collision.TryGetComponent(out Boost boost))
        {
            TakeBoost(boost);
            Destroy(boost.gameObject);
        }
    }

    private void TakeBoost(Boost boost)
    {
        StartCoroutine(UseBoost(boost.Acceleration, boost.Duration));
    }

    private IEnumerator UseBoost(int acceleration, int duration)
    {
        _speed += acceleration;
        yield return new WaitForSeconds(duration);
        _speed -= acceleration;
    }
}