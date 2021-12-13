using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1Script : FSM
{
    public enum FSMState
    {
        None,
        Hide,
        Appear,
        Dead,
    }

    public FSMState curState; //what state are we in now
    public int health = 50; //the health of the enemy
    private Renderer _renderer;
    public GameObject _ColliderPrefab;
    GameObject[,] _grid = new GameObject[5, 4];
    Transform _transform;
    public float _timeBeforeExplosion = 5f;
    public GameObject _SmokePrefab;
    ParticleSystem _smoke;
    public float _appearTime = 0f;
    public float _smokeLength = 0f;
    public GameObject _player;
    public AudioSource _as;
    public static int _numTiles = 5;
    public int _damage = 10;

    int[] r, c = new int[_numTiles];
    public float newAlpha;
    SpriteRenderer _colSR;
    ArrayList _colliders = new ArrayList();
    SpriteRenderer _sr;
    GameObject smoke;
    public AudioClip _dyingClip;
    bool dead;

    protected override void Initialize()
    {
        //_as = GameObject.FindGameObjectWithTag("SFX").GetComponent<AudioSource>();
        _renderer = GetComponent<Renderer>();
        _transform = transform;
        _sr = this.GetComponent<SpriteRenderer>();
        float x = _transform.position.x;
        float y = _transform.position.y;
        smoke = Instantiate(_SmokePrefab, new Vector2(x, y), Quaternion.identity);
        _smoke = smoke.GetComponent<ParticleSystem>();
        curState = FSMState.Appear;
        x = -1.23f;
        y=-2.3f;

        for (int r = 0; r < 5; r++)
        {
            x = -1.23f;
            for (int c = 0; c < 4; c++)
            {
                _grid[r, c] = Instantiate(_ColliderPrefab, new Vector2(x, y), Quaternion.identity);
                x += .855f;
            }
            y++;
        }
    }

    protected override void FSMUpdate()
    {
        switch (curState)
        {
            case FSMState.Hide: UpdateHideState(); break;
            case FSMState.Appear: UpdateAppearState(); break;
            case FSMState.Dead: UpdateDeadState(); break;
        }

        if (health < 0)
        {
            curState = FSMState.Dead;
        }
    }

    protected void UpdateHideState()
    { 
        foreach (SpriteRenderer col in _colliders)
        {
            col.color = new Color(255f, 0, 0, .25f);
        }

        _timeBeforeExplosion -= Time.deltaTime;
        if (_timeBeforeExplosion < 0)
        {
            _timeBeforeExplosion = 5f;
            for (int i=0; i < _colliders.Capacity; i++)
            {
                _grid[r[i], c[i]].GetComponent<ParticleSystem>().Play();
                if (Vector2.Distance(_grid[r[i], c[i]].transform.position, _player.transform.position) < .5f)
                {
                    Player.health -= _damage;
                }
            }
            foreach (SpriteRenderer col in _colliders)
            {
                col.color = new Color(255f, 0, 0, 0);
            }
            curState = FSMState.Appear;
            _smoke.Clear();
            //appear
            Vector2 randomPos = new Vector2(Random.Range(-1.11f,1.15f), Random.Range(-1.3f, .7f));
            this.transform.position = randomPos;
            smoke.transform.position = randomPos;
            _renderer.enabled = true;
        }
    }

    protected void UpdateAppearState()
    {
        _appearTime -= Time.deltaTime;
        if (_appearTime < 0)
        {
            _appearTime = 5f;
            curState = FSMState.Hide;
            _smoke.Play();
            //disable sprite renderer
            _renderer.enabled = false;

            //choose a tile
            for (int i=0; i<_numTiles; i++)
            {
                do {
                    r[i] =Random.Range(0, 5);
                    c[i] = Random.Range(0, 4);
                    _colSR = _grid[r[i], c[i]].GetComponent<SpriteRenderer>();
                } while (_colliders.Contains(_colSR));
                _colliders.Add(_colSR);
            }

            newAlpha = 0f;
        }
    }

    protected void UpdateDeadState()
    {
        //set boss bool in trapdoor script true
        TrapdoorScript._bossDead = true;
        if(dead == true){
            _as.PlayOneShot(_dyingClip);
            dead = false;
        }
        //destroy game object
        Destroy(gameObject, 1f);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        string tag = other.gameObject.tag;
        if(tag == "attack" && curState != FSMState.Hide){
             health--;
            _sr.color = new Color(1, 0, 0);
            Invoke("resetColor", .5f);
        }
    }

    void resetColor()
    {
        _sr.color = new Color(1, 1, 1);
    }
}
