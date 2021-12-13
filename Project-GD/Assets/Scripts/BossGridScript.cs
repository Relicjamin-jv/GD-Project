using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossGridScript : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        string colTag = collision.gameObject.tag;
        if (colTag.Equals("Player"))
        {
            Boss1Script._tookDamage = true;
        }
    }
}
