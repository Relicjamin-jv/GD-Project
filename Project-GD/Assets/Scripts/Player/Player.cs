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
    float rangePower;
    bool rangedAttack = false;
    public GameObject arrowObj;
    public float arrowSpeed = 10f;
    bool canMove = true;

    public static int numberOfRangedAttack = 3;
    


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

        //melee
        controls.Gameplay.Attack.started += context => attack = canAttack();
        controls.Gameplay.Attack.canceled += context => attack = false;

        //ranged
        controls.Gameplay.RangedAttack.started += context => {
            if(numberOfRangedAttack > 0){
                rangedAttack = true; 
                canMove = false;
            }
        };
        controls.Gameplay.RangedAttack.canceled += context => { 
            if(numberOfRangedAttack > 0){
                rangeFire(); 
            }
            rangePower = 0f; 
            rangedAttack = false; 
            canMove = true;};
    }

    private void Update()
    {
        //movement
        Vector2 m = new Vector2(move.x, move.y) * Time.deltaTime;

        _animator.SetFloat("x", m.x);
        _animator.SetFloat("y", m.y);
        _animator.SetFloat("Speed", m.sqrMagnitude * 1000);

        if(canMove){
            transform.Translate(m, Space.World);
        }


        //melee attack logic
        meleeAttacking();

        if (rangedAttack && numberOfRangedAttack > 0)
        { //how much power to put behind it
            Debug.Log(numberOfRangedAttack);
            powerCharge();
        } //the button has been released fire the arrow based on how much power is behind it


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

    void meleeAttacking()
    {
        //where to attack logic
        if (attack && numberOfAttacks < 1)
        {
            if (move.x == 1 && move.y == 0)
            { //moving E
                GameObject attackGameObj = Instantiate(attackObj, new Vector3(this.transform.position.x + offset.x, transform.position.y, 0f), Quaternion.Euler(0f, 0f, 0f));
            }
            if (move.x > 0 && move.y > 0)
            { //moving NE
                GameObject attackGameObj = Instantiate(attackObj, new Vector3(this.transform.position.x + offset.x, transform.position.y + offset.y, 0f), Quaternion.Euler(0f, 0f, 45f));
            }
            if (move.x > 0 && move.y < 0)
            { //moving SE
                GameObject attackGameObj = Instantiate(attackObj, new Vector3(this.transform.position.x + offset.x, transform.position.y - offset.y, 0f), Quaternion.Euler(0f, 0f, -45f));
            }
            if (move.x == 0 && move.y == 1)
            { //moving N
                GameObject attackGameObj = Instantiate(attackObj, new Vector3(this.transform.position.x, transform.position.y + offset.y, 0f), Quaternion.Euler(0f, 0f, 90f));
            }
            if (move.x == 0 && move.y == -1)
            { //moving S
                GameObject attackGameObj = Instantiate(attackObj, new Vector3(this.transform.position.x, transform.position.y - offset.y, 0f), Quaternion.Euler(0f, 0f, -90f));
            }
            if (move.x == -1 && move.y == 0)
            { //moving W
                GameObject attackGameObj = Instantiate(attackObj, new Vector3(this.transform.position.x - offset.x, transform.position.y, 0f), Quaternion.Euler(0f, 0f, 180f));
            }
            if (move.x < 0 && move.y > 0)
            { //moving NW
                GameObject attackGameObj = Instantiate(attackObj, new Vector3(this.transform.position.x - offset.x, transform.position.y + offset.y, 0f), Quaternion.Euler(0f, 0f, 135f));
            }
            if (move.x < 0 && move.y < 0)
            { //moving SW
                GameObject attackGameObj = Instantiate(attackObj, new Vector3(this.transform.position.x - offset.x, transform.position.y - offset.y, 0f), Quaternion.Euler(0f, 0f, -135f));
            }
            if (move.x == 0 && move.y == 0)
            { //not moving 
                GameObject attackGameObj = Instantiate(attackObj, new Vector3(this.transform.position.x, transform.position.y - offset.y, 0f), Quaternion.Euler(0f, 0f, 270f));
            }

        }
        timer -= Time.deltaTime;
    }

    void rangeFire()
    {
        if (move.x == 1 && move.y == 0)
        { //moving E
            GameObject attackGameObj = Instantiate(arrowObj, new Vector3(this.transform.position.x + offset.x, transform.position.y, 0f), Quaternion.Euler(0f, 0f, 0f));
            attackGameObj.GetComponent<Rigidbody2D>().AddForce(new Vector2(arrowSpeed, 0f) * Mathf.Min(rangePower, 3f)); //returns a smaller value if rangedPower goes over 3
        }
        if (move.x > 0 && move.y > 0)
        { //moving NE
            GameObject attackGameObj = Instantiate(arrowObj, new Vector3(this.transform.position.x + offset.x, transform.position.y + offset.y, 0f), Quaternion.Euler(0f, 0f, 45f));
            attackGameObj.GetComponent<Rigidbody2D>().AddForce(new Vector2(arrowSpeed, arrowSpeed) * Mathf.Min(rangePower, 3f)); //returns a smaller value if rangedPower goes over 3
        }
        if (move.x > 0 && move.y < 0)
        { //moving SE
            GameObject attackGameObj = Instantiate(arrowObj, new Vector3(this.transform.position.x + offset.x, transform.position.y - offset.y, 0f), Quaternion.Euler(0f, 0f, -45f));
            attackGameObj.GetComponent<Rigidbody2D>().AddForce(new Vector2(arrowSpeed, -arrowSpeed) * Mathf.Min(rangePower, 3f)); //returns a smaller value if rangedPower goes over 3
        }
        if (move.x == 0 && move.y == 1)
        { //moving N
            GameObject attackGameObj = Instantiate(arrowObj, new Vector3(this.transform.position.x, transform.position.y + offset.y, 0f), Quaternion.Euler(0f, 0f, 90f));
            attackGameObj.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, arrowSpeed) * Mathf.Min(rangePower, 3f)); //returns a smaller value if rangedPower goes over 3
        }
        if (move.x == 0 && move.y == -1)
        { //moving S
            GameObject attackGameObj = Instantiate(arrowObj, new Vector3(this.transform.position.x, transform.position.y - offset.y, 0f), Quaternion.Euler(0f, 0f, -90f));
            attackGameObj.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, -arrowSpeed) * Mathf.Min(rangePower, 3f)); //returns a smaller value if rangedPower goes over 3
        }
        if (move.x == -1 && move.y == 0)
        { //moving W
            GameObject attackGameObj = Instantiate(arrowObj, new Vector3(this.transform.position.x - offset.x, transform.position.y, 0f), Quaternion.Euler(0f, 0f, 180f));
            attackGameObj.GetComponent<Rigidbody2D>().AddForce(new Vector2(-arrowSpeed, 0f) * Mathf.Min(rangePower, 3f)); //returns a smaller value if rangedPower goes over 3
        }
        if (move.x < 0 && move.y > 0)
        { //moving NW
            GameObject attackGameObj = Instantiate(arrowObj, new Vector3(this.transform.position.x - offset.x, transform.position.y + offset.y, 0f), Quaternion.Euler(0f, 0f, 135f));
            attackGameObj.GetComponent<Rigidbody2D>().AddForce(new Vector2(-arrowSpeed, arrowSpeed) * Mathf.Min(rangePower, 3f)); //returns a smaller value if rangedPower goes over 3
        }
        if (move.x < 0 && move.y < 0)
        { //moving SW
            GameObject attackGameObj = Instantiate(arrowObj, new Vector3(this.transform.position.x - offset.x, transform.position.y - offset.y, 0f), Quaternion.Euler(0f, 0f, -135f));
            attackGameObj.GetComponent<Rigidbody2D>().AddForce(new Vector2(-arrowSpeed, -arrowSpeed) * Mathf.Min(rangePower, 3f)); //returns a smaller value if rangedPower goes over 3
        }
        if (move.x == 0 && move.y == 0) 
        {   //not moving
            GameObject attackGameObj = Instantiate(arrowObj, new Vector3(this.transform.position.x, transform.position.y - offset.y, 0f), Quaternion.Euler(0f, 0f, 270f));
            attackGameObj.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, -arrowSpeed) * Mathf.Min(rangePower, 3f)); //returns a smaller value if rangedPower goes over 3
        }

    }

    void powerCharge()
    {
        rangePower = rangePower + Time.deltaTime;
    }


}

