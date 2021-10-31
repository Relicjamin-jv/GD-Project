using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timerAttack : MonoBehaviour
{
    public float timer = .1f;

    private void Start() {
        Player.numberOfAttacks++;
    }

    private void Update() {
        if(timer < 0f){
            Destroy(this.gameObject);
            Player.numberOfAttacks--;
        }
        timer -= Time.deltaTime;
    } 
}
