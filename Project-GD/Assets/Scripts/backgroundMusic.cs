using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundMusic : MonoBehaviour
{
    private void Start() {
        DontDestroyOnLoad(this.gameObject);
    }
}
