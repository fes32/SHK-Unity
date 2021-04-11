using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boost : MonoBehaviour
{
    [SerializeField] private int _acceleration;
    [SerializeField] private int _duration;

    public int Acceleration => _acceleration;
    public int Duration => _duration;

    public void Taked()
    {
        Destroy(this.gameObject);
    }
}