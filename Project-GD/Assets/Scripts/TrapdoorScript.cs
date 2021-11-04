using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrapdoorScript : MonoBehaviour
{

    Animator _animator;
    bool _open = false;
    public static bool _bossDead = false;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        string colTag = collision.tag;

        if (_bossDead)
        {
            if (colTag.Equals("Player"))
            {
                _animator.SetBool("Open", true);
                _open = true;
                SceneManager.LoadScene("Scene1Level2");
            }
        }
    }

}
