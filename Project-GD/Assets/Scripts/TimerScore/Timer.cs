using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public static float timer = 0f;
    public Text TimerText;

    private void Start() {
        DontDestroyOnLoad(this);
        TimerText = GameObject.FindGameObjectWithTag("Timer").GetComponent<Text>();
    }
    private void Update() {
        TimerText = GameObject.FindGameObjectWithTag("Timer").GetComponent<Text>();
        if(!Player.hasWon){
            timer += Time.deltaTime;
        }
        TimerText.text = "Time: " + timer.ToString("F2");
    }


}
