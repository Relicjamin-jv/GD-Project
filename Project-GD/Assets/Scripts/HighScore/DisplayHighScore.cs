using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayHighScore : MonoBehaviour
{

    public Text highScore;
    // Start is called before the first frame update
    void Start()
    {
       highScore.text = "HighScore: " + PlayerPrefs.GetFloat("score").ToString("F2"); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
