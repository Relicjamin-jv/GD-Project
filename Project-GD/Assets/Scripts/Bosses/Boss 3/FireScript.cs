using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireScript : MonoBehaviour
{
    public float moveSpeed = 1f;

    Rigidbody2D _rb;

    GameObject _player;
    Vector2 moveDirection;
    float timer = 0f;

    private void Start() {
        _rb = GetComponent<Rigidbody2D>();
        _player = GameObject.FindGameObjectWithTag("Player");
        moveDirection = (_player.transform.position - transform.position).normalized * moveSpeed;
        _rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
    }

    private void Update() {
        timer += Time.deltaTime;
        if(timer > 2f){
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            Destroy(this.gameObject);
        }
    }
}
