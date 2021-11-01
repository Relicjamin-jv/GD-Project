using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    private List<Vector2> patrolPoints = new List<Vector2>(); //hold a list for where it can partrol to
    public FSMState curState; //what state are we in now
    public float curSpeed; // the speed of the enemy player
    public int health = 5; //the health of the enemy
    private Rigidbody2D _rigidbody;
    private Vector2 nextPos;
    public float distanceToPlayerToChase = 5f;


    protected override void Initialize()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        curState = FSMState.Partrol;
        curSpeed = 4f;
        _transform = this.transform;
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        nextPos = player.transform.position;
        _rigidbody = GetComponent<Rigidbody2D>(); //get the ridgid body

        playerTransform = player.transform; //get the postion of the player to calculate whether it should change or not to the chasing state
        
        if(!playerTransform){
            Debug.Log("Player doesn't exist");
        }
    }

    protected Vector2 getNextPoint(){
        return patrolPoints[Random.Range(0, patrolPoints.Count)];
    }

    protected override void FSMUpdate()
    {
        switch(curState){
            case FSMState.Partrol: UpdatePartrolState(); break;
            case FSMState.Chase: UpdateChaseState(); break;
            case FSMState.Attack: UpdateAttackState(); break;
            case FSMState.Dead: UpdateDeadState(); break;
        }
    }

    //patrol points that the enemy will move in
    protected void patrolPointListFill(){
        for(int i = 0; i < 4; i++){
            patrolPoints.Add(new Vector2(_transform.position.x + Random.Range(-.5f, 5f), _transform.position.y + Random.Range(-.5f, .5f)));
        }
    }

    //when in a curr state it checks whether or not it should be still in that state and whether it should change to a seperate state
    protected void UpdatePartrolState(){
        if(Vector2.Distance(_transform.position, nextPos) < .1f){ //it got to its destination
            nextPos = getNextPoint();
        }else if(Vector2.Distance(_transform.position, playerTransform.position) < distanceToPlayerToChase){
            curState = FSMState.Chase;
        }
    }

    protected void UpdateChaseState(){
       
    }   

    protected void UpdateAttackState(){

    }

    protected void UpdateDeadState(){

    }
}