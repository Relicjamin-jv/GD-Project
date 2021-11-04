using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGAme : MonoBehaviour
{

    public void startGame(){
        SceneManager.LoadScene("Scene1Level1");
    }

    public void exit(){ 
        Application.Quit();
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
