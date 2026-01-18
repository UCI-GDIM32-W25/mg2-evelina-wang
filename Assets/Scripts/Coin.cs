using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 4f;
    [SerializeField] private int _points = 1;
    // Start is called before the first frame update
    public static int TotalScore = 0;
    private Transform _target;
     public void SetTarget(Transform target)
    {
        _target = target;
    }

    private void Update()
    {
        transform.Translate(Vector3.left * _moveSpeed * Time.deltaTime);
    }
 
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            TotalScore += _points;
            Debug.Log("Score: " + TotalScore);
            Destroy(gameObject);
        }
    }
}