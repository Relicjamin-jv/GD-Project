using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    private Image _healthBar;
    public int _curHealth;
    public int _maxHealth = 10;
    Player _player;

    void Start()
    {
        _healthBar = GetComponent<Image>();
        _player = FindObjectOfType<Player>();

    }

    void Update()
    {
        _curHealth = Player.health;
        _healthBar.fillAmount = _curHealth / _maxHealth;
    }

}
