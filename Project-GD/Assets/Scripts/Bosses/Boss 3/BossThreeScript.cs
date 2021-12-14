using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossThreeScript : FSM
{
    public enum FSMState
    {
        MOVE,
        SHOOT,
        DEAD,
    }



    Rigidbody2D _rb;
    Transform playerTransformPOS;
    public GameObject fireProjectile;
    public FSMState curState; //what state are we in now
    public int health = 30;
    bool dead = false;
    public AudioClip _dyingClip;
    public AudioSource _as;
    Transform _transform;
    Transform nextPos;
    SpriteRenderer _sp;
    Vector2 direction = Vector2.left;
    float speed = .5f;
    protected override void Initialize()
    {
        playerTransformPOS = GameObject.FindGameObjectWithTag("Player").transform;
        curState = FSMState.MOVE;
        _transform = this.transform;
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        nextPos = this.transform;
        _rb = GetComponent<Rigidbody2D>(); //get the ridgid body
        _sp = gameObject.GetComponent<SpriteRenderer>();
        _as = GameObject.FindGameObjectWithTag("SFX").GetComponent<AudioSource>();

        if (!playerTransform)
        {
            Debug.Log("Player doesn't exist");
        }
    }

    protected override void FSMUpdate()
    {
        switch (curState)
        {
            case FSMState.MOVE: UpdateMoveState(); break;
            case FSMState.SHOOT: UpdateShootState(); break;
            case FSMState.DEAD: UpdateDeadState(); break;
        }
        Debug.Log(health);

        if (health < 0)
        {
            curState = FSMState.DEAD;
        }

        _rb.velocity = speed * direction;


    }

    private void UpdateMoveState()
    {
        if (Random.Range(0, 100) == 0)
        {
            direction = getRandomVector2();
        }
        if (Random.Range(0, 100) == 0)
        {
            curState = FSMState.SHOOT;
        }
    }

    private void UpdateShootState()
    {
        GameObject shot = Instantiate(fireProjectile, new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.identity);
        curState = FSMState.MOVE;
    }

    private void UpdateDeadState()
    {
        if (!dead)
        {
            dead = true;
            _as.PlayOneShot(_dyingClip);
            //do what ever your heart desires for the boss to do when he dies
        }
        Invoke("destroyObj", 3f);
    }

    private Vector2 getRandomVector2()
    {
        Vector2 right = Vector3.right;
        float angle = Random.Range(-180, 180);
        Vector2 final = Quaternion.Euler(0, 0, angle) * right;
        return final;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        string tag = other.gameObject.tag;

        if (tag.Equals("Collider"))
        {
            direction = -1 * direction;
        }

        if (tag.Equals("Skull"))
        {
            if (other.gameObject.GetComponent<SkullScript>().playerKicked)
            {
                health--;
                _sp.color = new Color(1, 0, 0);
                Invoke("resetColor", .5f);
            }
        }

        if (tag.Equals("attack"))
        {
            health--;
            _sp.color = new Color(1, 0, 0);
            Invoke("resetColor", .5f);
        }
        if (tag == "fireball")
        {
            health -= 3;
            _sp.color = new Color(1, 0, 0);
            Invoke("resetColor", .5f);
        }

    }

    void resetColor()
    {
        _sp.color = new Color(1, 1, 1);
    }

    void destoryObj(){
        Destroy(this.gameObject);
        Player.hasWon = true;
        SceneManager.LoadScene("YouWON");
    }


}
