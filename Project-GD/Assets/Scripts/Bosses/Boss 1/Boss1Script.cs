using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridObject
{
    public int r, c;
    public GameObject gridCollider;
    public bool isExploding;
    public int key;

    public GridObject(int key, int r, int c, GameObject gridCollider, bool isExploding)
    {
        this.r = r;
        this.c = c;
        this.gridCollider = gridCollider;
        this.isExploding = isExploding;
        this.key = key;
    }
}

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
    //GameObject[,] _grid = new GameObject[5, 4];
    Transform _transform;
    public float _timeBeforeExplosion = 2f;
    public GameObject _SmokePrefab;
    ParticleSystem _smoke;
    public float _appearTime = 0f;
    public float _smokeLength = 0f;
    public GameObject _player;
    public AudioSource _as;
    public static int _numTiles = 5;
    public int _damage = 20;
    BoxCollider2D _boxC;
    public static bool _tookDamage = false;

    int r, c;
    ArrayList _grid = new ArrayList();

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
        //curState = FSMState.Appear;
        x = -1.23f;
        y=-2.3f;
        _boxC = GetComponent<BoxCollider2D>();

        int count = 0;
        for (int r = 0; r < 5; r++)
        {
            x = -1.23f;
            for (int c = 0; c < 4; c++)
            {
                _grid.Add(new GridObject(count, r, c, 
                    Instantiate(_ColliderPrefab, new Vector2(x, y), Quaternion.identity), false));
                x += .855f;
                count++;
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

        if (health <= 0)
        {
            curState = FSMState.Dead;
        }

        Debug.Log(Player.health);
    }

    protected void UpdateHideState()
    {
        foreach (GridObject sqr in _grid)
        {
            if (sqr.isExploding)
            {
                sqr.gridCollider.GetComponent<SpriteRenderer>().color = new Color(255f, 0, 0, .25f);
            }
        }

        _timeBeforeExplosion -= Time.deltaTime;
        if (_timeBeforeExplosion < 0)
        {
            _timeBeforeExplosion = 2f;
            foreach (GridObject sqr in _grid)
            {
                if (sqr.isExploding)
                {
                    sqr.gridCollider.GetComponent<ParticleSystem>().Play();
                    if (_tookDamage)//Vector2.Distance(sqr.gridCollider.transform.position, _player.transform.position) < .4f)
                    {
                        Player.health -= _damage;
                        _tookDamage = false;
                    }
                    sqr.gridCollider.GetComponent<SpriteRenderer>().color = new Color(255f, 0, 0, 0);
                    sqr.isExploding = false;
                }
            }
            _smoke.Clear();
            curState = FSMState.Appear;
            //appear
            Vector2 randomPos = new Vector2(Random.Range(-1.11f,1.15f), Random.Range(-1.3f, .7f));
            this.transform.position = randomPos;
            smoke.transform.position = randomPos;
            _renderer.enabled = true;
            _boxC.enabled = true;
        }
    }

    protected void UpdateAppearState()
    {
        //int chance = 0;
        _appearTime -= Time.deltaTime;
        if (_appearTime < 0)
        {
            _appearTime = 5f;

            int dontExplode = Random.Range(0, 20);
            foreach (GridObject sqr in _grid)
            {
                if (_grid[dontExplode] == sqr)
                {
                    sqr.isExploding = false;
                } else
                {
                    sqr.isExploding = true;
                }
            }


            //choose a tile
            /*foreach (GridObject sqr in _grid)
            {
                chance = Random.Range(0, 5);
                if (chance == 1)
                {
                    sqr.isExploding = true;
                }
            }*/
            newAlpha = 0f;
            curState = FSMState.Hide;
            //disable sprite renderer
            _renderer.enabled = false;
            _smoke.Play();
            _boxC.enabled = false;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        string tag = collision.gameObject.tag;
        if (tag == "attack" && curState != FSMState.Hide)
        {
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
