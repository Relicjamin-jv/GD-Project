using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//author
public class basicEnemyFSM : FSM
{
    public enum FSMState
    {
        None,
        Partrol,
        Chase,
        Attack,
        Dead,
    }

    Transform _transform;
    public FSMState curState; //what state are we in now
    private float curSpeed = 10f; // the speed of the enemy player
    public float chaseSpeed = 10f;
    public float partrolSpeed = 5f;
    public int health = 1; //the health of the enemy
    private Rigidbody2D _rigidbody;
    private Vector2 nextPos;
    public float distanceToPlayerToChase = 5f;
    bool canMove = true;
    SpriteRenderer _sp;
    public float timerAttack = 3f;
    Animator _animator;
    public int _damage = 3;

    public AudioClip _dyingClip;
    public GameObject _as;
    bool play = true;



    protected override void Initialize()
    {
        _as = GameObject.FindGameObjectWithTag("SFX");
        _animator = GetComponent<Animator>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        curState = FSMState.Partrol;
        _transform = this.transform;
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        nextPos = this.transform.position;
        _rigidbody = GetComponent<Rigidbody2D>(); //get the ridgid body
        _sp = gameObject.GetComponent<SpriteRenderer>();

        playerTransform = player.transform; //get the postion of the player to calculate whether it should change or not to the chasing state

        if (!playerTransform)
        {
            Debug.Log("Player doesn't exist");
        }
    }

    protected override void FSMUpdate()
    {
        _animator.SetFloat("Speed", curSpeed);

        if (canMove)
        {
            switch (curState)
            {
                case FSMState.Partrol: UpdatePartrolState(); break;
                case FSMState.Chase: UpdateChaseState(); break;
                case FSMState.Attack: UpdateAttackState(); break;
                case FSMState.Dead: UpdateDeadState(); break;
            }
        }

        if (health < 0)
        {
            curState = FSMState.Dead;
        }
    }



    //when in a curr state it checks whether or not it should be still in that state and whether it should change to a seperate state
    protected void UpdatePartrolState()
    {
        curSpeed = partrolSpeed;
        if (Vector2.Distance(_transform.position, nextPos) < .1f)
        { //it got to its destination
            nextPos = new Vector2(this.transform.position.x + Random.Range(-.5f, .5f), this.transform.position.y + Random.Range(-.5f, .5f));
        }
        else if (Vector2.Distance(_transform.position, playerTransform.position) < distanceToPlayerToChase)
        {
            curState = FSMState.Chase;
        }

        transform.position = Vector2.MoveTowards(this.transform.position, nextPos, curSpeed * Time.deltaTime); //start moving towards the player
    }

    protected void UpdateChaseState()
    {
        if (playerTransform.position.x > transform.position.x)
        {
            _sp.flipX = true;
        }
        else
        {
            _sp.flipX = false;
        }
        curSpeed = chaseSpeed;
        if (Vector2.Distance(_transform.position, playerTransform.position) > 10f)
        { //it got to its destination
            curState = FSMState.Partrol;
        }

        if (Vector2.Distance(_transform.position, playerTransform.position) < 1f)
        {
            curState = FSMState.Attack;
        }

        transform.position = Vector2.MoveTowards(this.transform.position, playerTransform.position, curSpeed * Time.deltaTime); //start moving towards the player
    }

    protected void UpdateAttackState()
    {
        if (playerTransform.position.x > transform.position.x)
        {
            _sp.flipX = true;
        }
        else
        {
            _sp.flipX = false;
        }
        if (Vector2.Distance(_transform.position, playerTransform.position) > 1f)
        {
            curState = FSMState.Chase;
        }
        else
        {
            if (timerAttack < 0)
            {
                timerAttack = 5f;
                Player.health -= _damage;
                Player._sp.color = new Color(1, 0, 0);
                Invoke("resetPlayerColor", .5f);
            }
        }
        timerAttack -= Time.deltaTime; //allows the enemy to only be able to hit the taget every (timerAttack) seconds
    }

    protected void UpdateDeadState()
    {
        if(play){
            //_as.GetComponent<AudioSource>().PlayOneShot(_dyingClip);
            play = false;
            Debug.Log("played");
        }
        Destroy(gameObject, 1f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        string tag = other.gameObject.tag;

        if (tag == "attack")
        {
            canMove = false;
            Invoke("resetCanMove", .5f);
            health--;
            _sp.color = new Color(1, 0, 0);
            Invoke("resetColor", .5f);
        }
    }

    void resetCanMove()
    {
        canMove = true;
    }

    void resetColor()
    {
        _sp.color = new Color(1, 1, 1);
    }
    void resetPlayerColor()
    {
        Player._sp.color = new Color(1, 1, 1);
    }
}