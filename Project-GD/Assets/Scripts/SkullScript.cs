using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullScript : MonoBehaviour
{
    Rigidbody2D _rbody;
    Transform _transform;
    bool _rotate;
    Vector2 _rotationDir;
    float _angle;
    Quaternion _rotation;
    float _rotationSpeed = 0;
    float _maxVelo = 2;
    public bool playerKicked = false;
    float timer = 0f;


    // Start is called before the first frame update
    void Start()
    {
        _rbody = GetComponent<Rigidbody2D>();
        _transform = transform;
        _rotate = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_rotate)
        {
            _transform.Rotate(new Vector3(0, 0, _rotationSpeed) * 1000 * Time.deltaTime, Space.World);
        }
        if (_rbody.velocity.magnitude <= .1f)
        {
            _rbody.velocity = new Vector2(0, 0);
            _rotationSpeed = 0;
        }
        if (_rbody.velocity.magnitude > _maxVelo)
        {
            _rbody.velocity.Normalize();
        }
        if(playerKicked){
            timer += Time.deltaTime;
            if(timer > 3f){
                playerKicked = false;
                timer = 0f;
            }
        }
    }

    private void OnCollisionEnter2D (Collision2D collision)
    {
        string colTag = collision.gameObject.tag;
        if (colTag.Equals("Player"))
        {
            Vector2 direction = (collision.transform.position - _transform.position).normalized;
            _rbody.velocity = -direction * 3;

            _rotationSpeed = 0.5f;
            _rotate = true;
            playerKicked = true;
        }
    }
}
