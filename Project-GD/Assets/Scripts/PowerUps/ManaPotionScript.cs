using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaPotionScript: MonoBehaviour
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
            if (Player.mana < Player.maxMana)
            {
                if (Player.mana > Player.maxMana - Player._manaPotAmount)
                {
                    Player.mana += Player.maxMana - Player.mana;
                }
                else
                {
                    Player.mana += Player._manaPotAmount;
                }
            }
            Destroy(gameObject);
        }
    }
}
