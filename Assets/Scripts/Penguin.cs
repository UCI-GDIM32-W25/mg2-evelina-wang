using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Penguin : MonoBehaviour

{
    [SerializeField] private float _speed = 1.0f;
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private GameObject _coinPrefab;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _jump;
   
    [SerializeField] private Collider2D _groundCollider;
    [SerializeField] private Collider2D _collider;
private bool _isGrounded = true;
    // Start is called before the first frame update
    void Start()
    {
         _collider = GetComponent<Collider2D>();

    GameObject ground = GameObject.FindGameObjectWithTag("Ground");
    if (ground != null)
        _groundCollider = ground.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)&& _isGrounded)
     {
         _isGrounded = false;

         _rigidbody.velocity = new Vector2(
             _rigidbody.velocity.x,
             _jump
         );

     }
    }
     private void OnCollisionEnter2D(Collision2D collision)
    {
    string tag = collision.gameObject.tag;
    if (tag.Equals("Ground"))
    {
        _isGrounded = true;
    }
    }
}
