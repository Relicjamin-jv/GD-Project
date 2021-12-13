using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotionScript : MonoBehaviour
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
        string colTag = collision.transform.tag;

        if (colTag == "Player")
        {
            if (Player.health < Player.maxHealth)
            {
                if (Player.health > Player.maxHealth - Player._healthPotAmount)
                {
                    Player.health += Player.maxHealth - Player.health;
                }
                else
                {
                    Player.health += Player._healthPotAmount;
                }
            }
            Destroy(gameObject);
        }
    }
}
