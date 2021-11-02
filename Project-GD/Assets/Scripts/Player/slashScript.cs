using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//author
public class slashScript : MonoBehaviour
{
    public static SpriteRenderer slashSR;

    private void Start()
    {
        slashSR = gameObject.GetComponent<SpriteRenderer>();
    }
}
