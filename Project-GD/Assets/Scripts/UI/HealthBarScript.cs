using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    private Image _healthBar;
    public int _curHealth;
    public int _maxHealth;

    void Start()
    {
        _healthBar = GetComponent<Image>();
        _maxHealth = Player.maxHealth;
        _curHealth = Player.health;
    }

    void Update()
    {
        _curHealth = Player.health;
        _healthBar.fillAmount = (float)_curHealth / _maxHealth;
    }

}
