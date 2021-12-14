using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public enum idleLook
{
    LEFT,
    UP,
    DOWN,
    RIGHT,
}
public class Player : MonoBehaviour
{
    private idleLook idleDirection = idleLook.DOWN;
    public static bool hasWon = false;
    PlayerControls controls;
    public Animator _animator;
    public Vector3 offset;
    Vector2 move;
    public float playerSpeed = .5f;
    private float keyboardMove;
    public GameObject attackObj;
    private bool attack = false;
    private float timer;
    public static int numberOfAttacks;
    float rangePower;
    bool rangedAttack = false;
    public GameObject arrowObj;
    public float arrowSpeed = 10f;
    bool canMove = true;
    public static int mana = 100;
    public static int health = 100;
    public static int maxMana = 100;
    public static int maxHealth = 100;
    public static int fireBallCost = 10;
    public static SpriteRenderer _sp;
    public static int _healthPotAmount = 10;
    public static int _manaPotAmount = 50;
    ParticleSystem _healthBuff;
    public ParticleSystem _manaParticles;
    public static Transform _transform;


    public Text _lives;


    private void Start()
    {
        offset = new Vector3(.5f, .5f, 0f);
        _sp = gameObject.GetComponent<SpriteRenderer>();
        _healthBuff = GetComponent<ParticleSystem>();
        _transform = transform;
        numberOfAttacks = 0;
    }

    private void Awake()
    {
        controls = new PlayerControls();

        controls.Gameplay.Move.performed += context => move = context.ReadValue<Vector2>();
        controls.Gameplay.Move.canceled += context => move = Vector2.zero;

        controls.Gameplay.WASD.performed += context => move = context.ReadValue<Vector2>();
        controls.Gameplay.WASD.canceled += context => move = Vector2.zero;

        //melee
        controls.Gameplay.Attack.performed += context =>
        {
            attack = canAttack();
        };
        controls.Gameplay.Attack.canceled += context => attack = false;

        //ranged
        controls.Gameplay.RangedAttack.started += context =>
        {
            if (mana >= fireBallCost)
            {
                rangedAttack = true;
                canMove = false;
            }
        };
        controls.Gameplay.RangedAttack.canceled += context =>
        {
            if (mana >= fireBallCost)
            {
                rangeFire();
            }
            rangePower = 0f;
            rangedAttack = false;
            canMove = true;
        };

    }

    private void Update()
    {
        if (health != 10)
        {
            _lives.text = "Health: " + health;
        }

        if (health <= 0)
        {
            Time.timeScale = 1f;
            health = 10;
            SceneManager.LoadScene("DeathScene");
        }

        //movement
        Vector2 m = new Vector2(move.x, move.y) * Time.deltaTime;
        m *= playerSpeed;

        _animator.SetFloat("x", m.x);
        _animator.SetFloat("y", m.y);
        _animator.SetFloat("Speed", m.sqrMagnitude * 1000);


        //for idle looking a cetain direction
        if (m.x > 0 && Mathf.Abs(m.y) < Mathf.Abs(m.x))
        {
            _animator.SetBool("Right", true);
            _animator.SetBool("Left", false);
            _animator.SetBool("Up", false);
            _animator.SetBool("Down", false);
            idleDirection = idleLook.RIGHT;
        }

        if (m.x < 0 && Mathf.Abs(m.y) < Mathf.Abs(m.x))
        {
            _animator.SetBool("Right", false);
            _animator.SetBool("Left", true);
            _animator.SetBool("Up", false);
            _animator.SetBool("Down", false);
            idleDirection = idleLook.LEFT;
        }

        if (m.y > 0 && Mathf.Abs(m.y) > Mathf.Abs(m.x))
        {
            _animator.SetBool("Right", false);
            _animator.SetBool("Left", false);
            _animator.SetBool("Up", true);
            _animator.SetBool("Down", false);
            idleDirection = idleLook.UP;
        }

        if (m.y < 0 && Mathf.Abs(m.y) > Mathf.Abs(m.x))
        {
            _animator.SetBool("Right", false);
            _animator.SetBool("Left", false);
            _animator.SetBool("Up", false);
            _animator.SetBool("Down", true);
            idleDirection = idleLook.DOWN;
        }


        if (canMove)
        {
            transform.Translate(m, Space.World);
        }


        //melee attack logic
        meleeAttacking();


        if (rangedAttack && mana >= fireBallCost)
        { //how much power to put behind it
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
            timer = .5f;
            return true;
        }
        return false;
    }

    void meleeAttacking()
    {
        //where to attack logic
        if (attack && numberOfAttacks < 1)
        {
            float angle = Mathf.Atan2(move.x, move.y);
            float xComp = Mathf.Cos(angle);
            float yComp = Mathf.Sin(angle);
            float angleFin = Mathf.Atan2(xComp, yComp) * Mathf.Rad2Deg;
            Debug.Log(angleFin);
            Vector2 distanceOffset = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle));
            if(Mathf.Abs(move.x) > 0 && Mathf.Abs(move.y) > 0){
                GameObject attackGameObj = Instantiate(attackObj, new Vector3(this.transform.position.x + (offset.x * distanceOffset.x), transform.position.y + (offset.y * distanceOffset.y) , 0f), Quaternion.Euler(0f, 0f, angleFin));
            }
            
            if (move.x == 0 && move.y == 0)
            { //not moving
                //each idle state
                
                if (idleDirection == idleLook.DOWN)
                {
                    GameObject attackGameObjDir = Instantiate(attackObj, new Vector3(this.transform.position.x, transform.position.y - offset.y, 0f), Quaternion.Euler(0f, 0f, 270f));
                }
                if (idleDirection == idleLook.UP)
                {
                    GameObject attackGameObjDir = Instantiate(attackObj, new Vector3(this.transform.position.x, transform.position.y + offset.y, 0f), Quaternion.Euler(0f, 0f, 90f));
                }
                if (idleDirection == idleLook.RIGHT)
                {
                    GameObject attackGameObjDir = Instantiate(attackObj, new Vector3(this.transform.position.x + offset.x, transform.position.y, 0f), Quaternion.Euler(0f, 0f, 0f));
                }
                if (idleDirection == idleLook.LEFT)
                {
                    GameObject attackGameObjDir = Instantiate(attackObj, new Vector3(this.transform.position.x - offset.x, transform.position.y, 0f), Quaternion.Euler(0f, 0f, 180f));
                }
            }
            attack = false;
        }
        timer -= Time.deltaTime;
    }

    void rangeFire()
    {
        float angle = Mathf.Atan2(move.x, move.y);
        float xComp = Mathf.Cos(angle);
        float yComp = Mathf.Sin(angle);
        GameObject attackGameObj = Instantiate(arrowObj, new Vector3(this.transform.position.x, transform.position.y, 0f), Quaternion.identity);
        if (Mathf.Abs(move.x) > 0 && Mathf.Abs(move.y) > 0)
        {
            attackGameObj.GetComponent<Rigidbody2D>().AddForce(new Vector2(yComp, xComp).normalized * Mathf.Min(rangePower, 3f) * 100); //returns a smaller value if rangedPower goes over 3
        }
        else
        {
            if (idleDirection == idleLook.DOWN)
            {
                attackGameObj.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -1).normalized * Mathf.Min(rangePower, 3f) * 100); //returns a smaller value if rangedPower goes over 3
            }
            if (idleDirection == idleLook.UP)
            {
                attackGameObj.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 1).normalized * Mathf.Min(rangePower, 3f) * 100); //returns a smaller value if rangedPower goes over 3
            }
            if (idleDirection == idleLook.RIGHT)
            {
                attackGameObj.GetComponent<Rigidbody2D>().AddForce(new Vector2(1, 0).normalized * Mathf.Min(rangePower, 3f) * 100); //returns a smaller value if rangedPower goes over 3
            }
            if (idleDirection == idleLook.LEFT)
            {
                attackGameObj.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1, 0).normalized * Mathf.Min(rangePower, 3f) * 100); //returns a smaller value if rangedPower goes over 3
            }
        }
    }

    void powerCharge()
    {
        rangePower = rangePower + Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        string tag = other.gameObject.tag;

        if (tag == "eAttack")
        {
            health -= 5;
            _sp.color = new Color(1, 0, 0);
            //slashScript.slashSR.enabled = true;
            Invoke("resetPlayerColor", .5f);
            Destroy(other.gameObject, .5f);
        }

        if (tag == "SmashAttack")
        {
            health -= 20;
            _sp.color = new Color(1, 0, 0);
            //slashScript.slashSR.enabled = true;
            Invoke("resetPlayerColor", .5f);
        }

        if (tag == "Gnevern")
        {
            health -= GnevernScript._attackPower;
            _sp.color = new Color(1, 0, 0);
            Invoke("resetPlayerColor", .5f);
        }

        if (tag == "HealthPot")
        {
            _healthBuff.Play(); 
        }

        if (tag.Equals("ManaPot"))
        {
            ParticleSystem manaP = Instantiate(_manaParticles, transform.position, Quaternion.identity);
            manaP.transform.parent = _transform;
            _manaParticles.Play();
        }

        //Move from scene to scene
        if (tag.Equals("Level1Exit"))
        {
            SceneManager.LoadScene("Scene2Level1");
        }
        else if (tag.Equals("S2Level1Exit"))
        {
            SceneManager.LoadScene("Scene3Level1");
        }
        //trapdoor
        else if (tag.Equals("S1Level2Exit"))
        {
            SceneManager.LoadScene("Scene2Level2");
        }
        else if (tag.Equals("S2Level2Exit"))
        {
            SceneManager.LoadScene("BossSceneLevel1");
        }
        else if (tag.Equals("S3Level2Exit"))
        {
            SceneManager.LoadScene("Lvl2.5Scene1");
        }
        else if (tag.Equals("Lvl2.5Scene1Exit"))
        {
            SceneManager.LoadScene("Lvl2.5Scene2");
        }
        else if (tag.Equals("Lvl2.5Scene2Exit"))
        {
            SceneManager.LoadScene("Lvl2.5Scene3");
        }
        else if (tag.Equals("Lvl2.5Scene3Exit"))
        {
            SceneManager.LoadScene("Scene1Level3");
        }
        else if (tag.Equals("S1Level3Exit"))
        {
            SceneManager.LoadScene("Scene2Level3");
        }
        else if (tag.Equals("S2Level3Exit"))
        {
            SceneManager.LoadScene("BossSceneLevel3");
        }

    }

    void resetPlayerColor()
    {
        //slashScript.slashSR.enabled = false;
        Player._sp.color = new Color(1, 1, 1);
    }


}

