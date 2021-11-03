using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colliderBehvoir : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        string tag = other.gameObject.tag;

        if(tag == "attack"){
            if(other.GetComponent<rangeWeapon>()){
                Debug.Log("Hit wall");
                other.GetComponent<rangeWeapon>().hitWall = true;
            }
        }
    }
}
