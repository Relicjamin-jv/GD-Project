using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaParticlesScript : MonoBehaviour
{
    ParticleSystem _particles;
    float _startTime;
    ParticleSystem.MainModule main;
    Transform _transform;
    // Start is called before the first frame update
    void Start()
    {
        _startTime = Time.time;
        _particles = GetComponent<ParticleSystem>();

        main = _particles.main;
        Destroy(gameObject, main.duration);
        _transform = transform;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
