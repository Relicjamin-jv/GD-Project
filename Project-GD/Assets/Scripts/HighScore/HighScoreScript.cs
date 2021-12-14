using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreScript : MonoBehaviour
{
    private void Start() {
        if(PlayerPrefs.GetFloat("score") > Timer.timer){
            PlayerPrefs.SetFloat("score", Timer.timer);
        }
    }
}
