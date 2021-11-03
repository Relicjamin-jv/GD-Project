using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beeStingerScript : MonoBehaviour
{
    public float moveSpeed = 1f;

    Rigidbody2D _rb;

    GameObject _player;
    Vector2 moveDirection;

    private void Start() {
        _rb = GetComponent<Rigidbody2D>();
        _player = GameObject.FindGameObjectWithTag("Player");
        moveDirection = (_player.transform.position - transform.position).normalized * moveSpeed;
        _rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
    }   
}
