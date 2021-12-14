using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    private Image _healthBar;
    public int _curHealth = Player.health;
    public int _maxHealth = Player.health;

    void Start()
    {
        _healthBar = GetComponent<Image>();
        _curHealth = Player.health;
    }

    void Update()
    {
        _curHealth = Player.health;
        _healthBar.fillAmount = (float)_curHealth / _maxHealth;
    }

}
