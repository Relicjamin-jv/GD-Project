using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GnevernScript : FSM
{

    public enum FSMState
    {
        Attacking,
        Charging,
        Dead,
    }
    public static FSMState curState = FSMState.Charging; //what state are we in now
    public int health = 30;

    static float _timeBetweenAttacks = 5f;
    float _attackChargeTime = _timeBetweenAttacks;
    float _lastAttackTime = 0f;
    bool _hasAttacked = false;
    public static int _attackPower = 20;
    bool _hit = false;
    float _speed = 1.12f;

    float _colorChangeTime = 0;
    float _red = 255, _green = 255, _blue = 255;

    SpriteRenderer _sp;
    CircleCollider2D _cCollider;

    Player _player;

    public ParticleSystem _attackParticles;
    ParticleSystem _particles;
    public GameObject _portal;
    public GameObject _crystal;
    public AudioSource _as;
    public AudioClip _dyingClip;
    bool dead;
    public static Transform _transform;

    protected override void Initialize()
    {
        _sp = GetComponent<SpriteRenderer>();
        _player = FindObjectOfType<Player>();
        _cCollider = GetComponent<CircleCollider2D>();
        _transform = transform;
    }

    protected override void FSMUpdate()
    {
        switch (curState)
        {
            case FSMState.Attacking: UpdateAttackState(); break;
            case FSMState.Charging: UpdateChargingState(); break;
            case FSMState.Dead: UpdateDeadState(); break;
        }

        if (health <= 0)
        {
            curState = FSMState.Dead;
        }

        if (Vector2.Distance(transform.position, _player.transform.position) > .1f)
        {
            transform.position = Vector2.MoveTowards(this.transform.position
                , _player.transform.position, _speed * Time.deltaTime);
        }

    }

    protected void UpdateAttackState()
    {
        if (!_hasAttacked)
        {
            _particles = Instantiate(_attackParticles, transform.position, Quaternion.identity);
            _cCollider.enabled = true;
            _hasAttacked = true;
        }
        if (_particles == null)
        {
            //at end of method
            _lastAttackTime = Time.time;
            _colorChangeTime = _lastAttackTime;
            curState = FSMState.Charging;
        }
    }

    protected void UpdateChargingState()
    {
        _cCollider.enabled = false;
        UpdateColor();
        _attackChargeTime -= Time.deltaTime;
        if (_attackChargeTime < 0)
        {
            _sp.color = new Color(255, 255, 2555);
            _red = 255;
            _green = 255f;
            _blue = 255f;
            curState = FSMState.Attacking;
            _hasAttacked = false;
            _attackChargeTime = _timeBetweenAttacks;
        }
    }

    protected void UpdateDeadState()
    {
        Destroy(gameObject);//TODO: re-add delay if using particles
        _portal.SetActive(true);
        _crystal.SetActive(false);
        if (dead == true)
        {
            _as.PlayOneShot(_dyingClip);
            dead = false;
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        string tag = other.gameObject.tag;

        if (tag == "attack")
        {
            _hit = true;
            health--;
            _sp.color = new Color(1, 0, 0);
            Invoke("resetColor", .25f);
        }
        if (tag == "fireball")
        {
            _hit = true;
            health -= 3;
            _sp.color = new Color(1, 0, 0);
            Invoke("resetColor", .5f);
        }
    }

    private void UpdateColor()
    {
        if (Time.time - _colorChangeTime >= .1 && !_hit) 
        {
            _red -= 3.1f;
            _green -= 5.1f;
            _blue -= 2.3f;
            _sp.color = new Color(_red / 255f, _green / 255f, _blue / 255f);
            _colorChangeTime = Time.time;
        }
    }

    void resetColor()
    {
        _hit = false;
        _sp.color = new Color(_red/255f, _green/255f, _blue/255f);
    }
}
