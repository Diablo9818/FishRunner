using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosterMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void Update()
    {
        Quaternion rotation = Quaternion.Euler(0, 180, 0);
        transform.rotation = rotation;
        transform.Translate(Vector3.right * _speed * Time.deltaTime);
    }
}
