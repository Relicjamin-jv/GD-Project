using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GnevernScript : FSM
{

    public enum FSMState
    {
        Attacking,
        Patrolling,
        Dead,
    }
    public FSMState curState; //what state are we in now
    public int health = 10;

    SpriteRenderer _sp;

    public GameObject _portal;
    public GameObject _crystal;

    protected override void Initialize()
    {
        _sp = GetComponent<SpriteRenderer>();
    }

    protected override void FSMUpdate()
    {
        switch (curState)
        {
            case FSMState.Attacking: UpdateAttackState(); break;
            case FSMState.Patrolling: UpdatePatrolState(); break;
            case FSMState.Dead: UpdateDeadState(); break;
        }

        if (health < 0)
        {
            curState = FSMState.Dead;
        }


    }

    protected void UpdateAttackState()
    {
        //TODO: implement method
    }

    protected void UpdatePatrolState()
    {
        //TODO: implement method
    }

    protected void UpdateDeadState()
    {
        Destroy(gameObject);//TODO: re-add delay if using particles
        _portal.SetActive(true);
        _crystal.SetActive(false);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        string tag = other.gameObject.tag;

        if (tag == "attack")
        {
            health--;
            _sp.color = new Color(1, 0, 0);
            Invoke("resetColor", .5f);
        }
    }

    void resetColor()
    {
        _sp.color = new Color(1, 1, 1);
    }
}
