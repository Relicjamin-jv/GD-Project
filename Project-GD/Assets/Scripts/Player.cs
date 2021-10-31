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

        controls.Gameplay.Attack.performed += context => attack = canAttack();
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
        float timerAttack = .3f;
        if (attack && timer > 0f)
        {
            if (!initAttack)
            {
                initAttack = Instantiate(attackObj);
                initAttack.transform.parent = this.transform;
            }
            //right side movement
            if (move.x == 1 && move.y == 0)
            {  //if the player is moving right
                Debug.Log("Rotate E");
                initAttack.transform.rotation = Quaternion.Euler(0f, 0f, 0f); //set the rotation to this
                initAttack.transform.position = new Vector3(this.transform.position.x + offset.x, this.transform.position.y, 0f);
            }
            if (move.x > 0 && move.y > 0)
            { //if the player if moving to the north east
                Debug.Log("Rotate NE");
                initAttack.transform.rotation = Quaternion.Euler(0f, 0f, 45f); //set the rotation to this
                initAttack.transform.position = new Vector3(this.transform.position.x + offset.x, this.transform.position.y + offset.y, 0f);
            }
            if (move.x > 0 && move.y < 0)
            { //if the player if moving to the sorth east
                Debug.Log("Rotate SE");
                initAttack.transform.rotation = Quaternion.Euler(0f, 0f, -45f); //set the rotation to this
                initAttack.transform.position = new Vector3(this.transform.position.x + offset.x, this.transform.position.y - offset.y, 0f);
            }

            //directly up and down
            if (move.x == 0 && move.y == 1)
            {  //if the player is moving up
                Debug.Log("Rotate N");
                initAttack.transform.rotation = Quaternion.Euler(0f, 0f, 90f); //set the rotation to this
                initAttack.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + offset.y, 0f);
            }
            if (move.x == 0 && move.y == -1)
            {  //if the player is moving down
                Debug.Log("Rotate S");
                initAttack.transform.rotation = Quaternion.Euler(0f, 0f, -90f); //set the rotation to this
                initAttack.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - offset.y, 0f);
            }

            //player is moving left
            if (move.x == -1 && move.y == 0)
            {  //if the player is moving right
                Debug.Log("Rotate W");
                initAttack.transform.rotation = Quaternion.Euler(0f, 0f, 180f); //set the rotation to this
                initAttack.transform.position = new Vector3(this.transform.position.x - offset.x, this.transform.position.y, 0f);
            }
            if (move.x < 0 && move.y > 0)
            { //if the player if moving to the north west
                Debug.Log("Rotate NW");
                initAttack.transform.rotation = Quaternion.Euler(0f, 0f, 135f); //set the rotation to this
                initAttack.transform.position = new Vector3(this.transform.position.x - offset.x, this.transform.position.y + offset.y, 0f);
            }
            if (move.x < 0 && move.y < 0)
            { //if the player if moving to the sorth west
                Debug.Log("Rotate SW");
                initAttack.transform.rotation = Quaternion.Euler(0f, 0f, -135f); //set the rotation to this
                initAttack.transform.position = new Vector3(this.transform.position.x - offset.x, this.transform.position.y - offset.y, 0f);
            }
            if (move.x == 0 && move.y == 0)
            { //if the player if moving to the sorth west
                Debug.Log("Rotate SW");
                initAttack.transform.rotation = Quaternion.Euler(0f, 0f, 270f); //set the rotation to this
                initAttack.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - offset.y, 0f);
            }
        }
        else
        {
            Destroy(initAttack);
        }
        timer -= Time.deltaTime;
        timerAttack -= Time.deltaTime;
        Debug.Log(timer);
    }
}

