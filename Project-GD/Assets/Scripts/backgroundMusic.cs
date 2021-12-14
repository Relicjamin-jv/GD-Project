using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundMusic : MonoBehaviour
{
    private void Awake()
    {
        int numMusicPlayers = FindObjectsOfType<backgroundMusic>().Length;
        Debug.Log(numMusicPlayers);
        if (numMusicPlayers >= 3)
        {
            Destroy(this.gameObject);
        }
        // if more then one music player is in the scene
        //destroy ourselves
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
