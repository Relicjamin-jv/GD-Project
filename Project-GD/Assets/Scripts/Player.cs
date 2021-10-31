using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    PlayerControls controls;
    public Animator _animator;
    public Animator _attackAnimator;
    public Vector3 offset;

    Vector2 move;
    public float playerSpeed = 5f;
    private float keyboardMove;
    public GameObject attackObj;
    private bool attack = false;
    private float timer;
    GameObject initAttack;
    public static int numberOfAttacks = 0;
    Rigidbody2D _arb;

    private void Start()
    {
        offset = new Vector3(.5f, .5f, 0f);
    }

    private void Awake()
    {
        controls = new PlayerControls();

        controls.Gameplay.Move.performed += context => move = context.ReadValue<Vector2>();
        controls.Gameplay.Move.canceled += context => move = Vector2.zero;

        controls.Gameplay.WASD.performed += context => move = context.ReadValue<Vector2>();
        controls.Gameplay.WASD.canceled += context => move = Vector2.zero;

        controls.Gameplay.Attack.started += context => attack = canAttack();
        controls.Gameplay.Attack.canceled += context => attack = false;

        //Example for button push
        //controls.Gameplay.hit.performed += context => hit();
    }

    private void Update()
    {
        //movement
        Vector2 m = new Vector2(move.x, move.y) * Time.deltaTime;

        _animator.SetFloat("x", m.x);
        _animator.SetFloat("y", m.y);
        _animator.SetFloat("Speed", m.sqrMagnitude * 1000);


        transform.Translate(m, Space.World);


        //where to attack logic
        attacking();
    }

    private void OnEnable()
    {
        controls.Gameplay.Enable();
    }


    private void OnDisable()
    {
        controls.Gameplay.Disable();
    }

    bool canAttack()
    {
        if (timer <= 0)
        { //so the player cant spam the attack
            timer = .1f;
            return true;
        }
        return false;
    }

    void attacking(){
         //where to attack logic
        if (attack && numberOfAttacks < 1)
        {
            if(move.x == 1 && move.y == 0){ //moving E
                GameObject attackGameObj = Instantiate(attackObj, new Vector3(this.transform.position.x + offset.x, transform.position.y, 0f), Quaternion.Euler(0f, 0f, 0f));
            }
            if(move.x > 0 && move.y > 0){ //moving NE
                GameObject attackGameObj = Instantiate(attackObj, new Vector3(this.transform.position.x + offset.x, transform.position.y + offset.y, 0f), Quaternion.Euler(0f, 0f, 45f));
            }
            if(move.x > 0 && move.y < 0){ //moving SE
                GameObject attackGameObj = Instantiate(attackObj, new Vector3(this.transform.position.x + offset.x, transform.position.y - offset.y, 0f), Quaternion.Euler(0f, 0f, -45f));
            }
            if(move.x == 0 && move.y == 1){ //moving N
                GameObject attackGameObj = Instantiate(attackObj, new Vector3(this.transform.position.x, transform.position.y + offset.y, 0f), Quaternion.Euler(0f, 0f, 90f));
            }
            if(move.x == 0 && move.y == -1){ //moving S
                GameObject attackGameObj = Instantiate(attackObj, new Vector3(this.transform.position.x , transform.position.y - offset.y, 0f), Quaternion.Euler(0f, 0f, -90f));
            }
            if(move.x == -1 && move.y == 0){ //moving W
                GameObject attackGameObj = Instantiate(attackObj, new Vector3(this.transform.position.x - offset.x, transform.position.y, 0f), Quaternion.Euler(0f, 0f, 180f));
            }
            if(move.x < 0 && move.y > 0){ //moving NW
                GameObject attackGameObj = Instantiate(attackObj, new Vector3(this.transform.position.x - offset.x, transform.position.y + offset.y, 0f), Quaternion.Euler(0f, 0f, 135f));
            }
            if(move.x < 0 && move.y < 0){ //moving SW
                GameObject attackGameObj = Instantiate(attackObj, new Vector3(this.transform.position.x - offset.x, transform.position.y - offset.y, 0f), Quaternion.Euler(0f, 0f, -135f));
            }
            if(move.x == 0 && move.y == 0){
                GameObject attackGameObj = Instantiate(attackObj, new Vector3(this.transform.position.x, transform.position.y - offset.y, 0f), Quaternion.Euler(0f, 0f, 270f));
            }

        }
        timer -= Time.deltaTime;
        Debug.Log(timer);
    }
}

