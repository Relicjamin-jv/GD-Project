using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGAme : MonoBehaviour
{

    public void startGame(){
        SceneManager.LoadScene("Scene1Level1");
        Player.numberOfAttacks = 0;
        Player.mana = 100;
        Player.health = 100;
        Player.hasWon = false;
        Timer.timer = 0f;
    }

    public void exit(){ 
        Application.Quit();
    }

    public void restartGame(){ 
        SceneManager.LoadScene("Scene1Level1");
        Player.numberOfAttacks = 0;
        Player.mana = 100;
        Player.health = 100;
        Player.hasWon = false;;
        Timer.timer = 0f;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
