using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rangeWeapon : MonoBehaviour
{
    Transform _transform;
    public float rotationSpeed = 10f;
    float velocity = 0f;
    float previousX = 0f;
    float previousY = 0f;
    float lifeTime = 0f;

    private void Start() {
        _transform = this.transform;
        Player.numberOfRangedAttack--;
    }

    // Update is called once per frame
    void Update()
    {
        lifeTime += Time.deltaTime;
        updateVelocity();
        previousX = _transform.position.x; 
        previousY = _transform.position.y;

        if(velocity < .2f){
            velocity = 0f;
        }

        Vector3 roatation = new Vector3(0f, 0f, rotationSpeed) * Time.deltaTime * Mathf.Sqrt(velocity);
        _transform.Rotate(roatation, Space.World);
    }

    //Gets the change in the x & y positions and returns the value, slows down the rotation of the shuriken
    void updateVelocity(){
        velocity = (Mathf.Abs(_transform.position.x - previousX) + Mathf.Abs(_transform.position.y - previousY)) / Time.deltaTime;
    }


    private void OnTriggerEnter2D(Collider2D other) {
        string tag = other.gameObject.tag;
        Debug.Log(tag);
        if(tag == "Player" && lifeTime > 1f){
            Player.numberOfRangedAttack++; 
            Destroy(this.gameObject);
        }
    }
}
