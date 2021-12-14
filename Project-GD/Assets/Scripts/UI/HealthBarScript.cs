using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    private Image _healthBar;
    int _curHealth;
    int _maxHealth;

    void Start()
    {
        _healthBar = GetComponent<Image>();
        _curHealth = Player.health;
        _maxHealth = Player.maxHealth;
    }

    void Update()
    {
        _curHealth = Player.health;
        _healthBar.fillAmount = (float)_curHealth / _maxHealth;
    }

}
