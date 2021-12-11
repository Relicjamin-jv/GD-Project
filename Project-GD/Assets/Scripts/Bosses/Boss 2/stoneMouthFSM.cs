using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stoneMouthFSM : FSM
{
    public enum FSMState
    {
        ModeSmash,
        ModeCharge,
        Dead,
    }

    Transform _transform;
    public FSMState curState; //what state are we in now
    public int health = 100; //the health of the enemy
    private Rigidbody2D _rigidbody;
    private Transform nextPos;
    SpriteRenderer _sp;
    public float timerAttack = 3f;
    public int changeStateHealth = 20;
    public List<GameObject> traversePoints = new List<GameObject>();
    public GameObject defaultTravelPoint;
    public GameObject attackSmashHorizontal;
    public GameObject attackSmashVerticle;
    public float speed = 5f;
    public float timerBeforeMove = -3f;

    public static bool attack = true;
    public static bool takeDamge = false;
    float takeDamageTimer = 1f;
    float timerBeforeMoveSetter = 5f;
    int maxHealth;
    public GameObject portal;
    public GameObject exitCover;
    public GameObject partileDeath;
    public AudioClip _dyingClip;
    public AudioSource _as;


    protected override void Initialize()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        curState = FSMState.ModeSmash;
        _transform = this.transform;
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        nextPos = this.transform;
        _rigidbody = GetComponent<Rigidbody2D>(); //get the ridgid body
        _sp = gameObject.GetComponent<SpriteRenderer>();
        maxHealth = health;
        _as = GameObject.FindGameObjectWithTag("SFX").GetComponent<AudioSource>();
        playerTransform = player.transform; //get the postion of the player to calculate whether it should change or not to the chasing state

        if (!playerTransform)
        {
            Debug.Log("Player doesn't exist");
        }
    }

    protected override void FSMUpdate()
    {
        switch (curState)
        {
            case FSMState.ModeSmash: UpdateSmashState(); break;
            case FSMState.ModeCharge: UpdateChargeState(); break;
            case FSMState.Dead: UpdateDeadState(); break;
        }
        Debug.Log(health);

        if(health < 0){
            partileDeath.GetComponent<Transform>().transform.position = this.transform.position;
            partileDeath.GetComponent<ParticleSystem>().Play();
            curState = FSMState.Dead;
        }

        
    }

    protected void chooseNextPoint()
    {
        if (Vector2.Distance(this.transform.position, defaultTravelPoint.transform.position) < .1f)
        {
            nextPos = traversePoints[Random.Range(0, traversePoints.Count)].transform;
        }
        else
        {
            nextPos = defaultTravelPoint.transform;
        }
    }


    //when in a curr state it checks whether or not it should be still in that state and whether it should change to a seperate state
    protected void UpdateSmashState()
    {
        // if (health < changeStateHealth)
        // { //arbitray number
        //     curState = FSMState.ModeCharge;
        // } ran out of time to implement more than one state

        if (Vector2.Distance(this.transform.position, nextPos.transform.position) < .1f && attack)
        {
            takeDamageTimer = 1f;
            if (Vector2.Distance(this.transform.position, defaultTravelPoint.transform.position) < .1f)
            {
                attackSmashHorizontal.GetComponent<ParticleSystem>().Play();
                attackSmashVerticle.GetComponent<ParticleSystem>().Play();
                attackSmashHorizontal.GetComponent<Collider2D>().enabled = true;
                attackSmashVerticle.GetComponent<Collider2D>().enabled = true;
            }
            if (Vector2.Distance(this.transform.position, traversePoints[0].transform.position) < .1f)
            { //leftmost
                attackSmashHorizontal.GetComponent<ParticleSystem>().Play();
                attackSmashHorizontal.GetComponent<Collider2D>().enabled = true;
            }
            if (Vector2.Distance(this.transform.position, traversePoints[2].transform.position) < .1f)
            { //rightmost
                attackSmashHorizontal.GetComponent<ParticleSystem>().Play();
                attackSmashHorizontal.GetComponent<Collider2D>().enabled = true;
            }
            if (Vector2.Distance(this.transform.position, traversePoints[1].transform.position) < .1f)
            { //bottom
                attackSmashVerticle.GetComponent<ParticleSystem>().Play();
                attackSmashVerticle.GetComponent<Collider2D>().enabled = true;
            }
            if (Vector2.Distance(this.transform.position, traversePoints[3].transform.position) < .1f)
            { //top
                attackSmashVerticle.GetComponent<ParticleSystem>().Play();
                attackSmashVerticle.GetComponent<Collider2D>().enabled = true;
            }
            attack = false;
        }
        timerBeforeMove -= Time.deltaTime;
        takeDamageTimer -= Time.deltaTime;
        if (timerBeforeMove < 0)
        {
            chooseNextPoint();
            attack = true;
            timerBeforeMove = timerBeforeMoveSetter;
        }
        if(takeDamageTimer < 0)
        {
            attackSmashHorizontal.GetComponent<Collider2D>().enabled = false;
            attackSmashVerticle.GetComponent<Collider2D>().enabled = false;
        }
        speed = 1 + (maxHealth - health) * .1f; //gets to move faster
        this.transform.position = Vector2.MoveTowards(this.transform.position, nextPos.transform.position, speed * Time.deltaTime);
    }

    protected void UpdateChargeState()
    {

    }

    protected void UpdateDeadState()
    {
        portal.SetActive(true);
        exitCover.SetActive(false);
        _as.PlayOneShot(_dyingClip);
        Destroy(gameObject, 2f);
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
