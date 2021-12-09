using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaBarScript : MonoBehaviour
{
    private Image _manaBar;
    public float _curMana;
    public float _maxMana = 100f;
    Player _player;

    void Start()
    {
        _manaBar = GetComponent<Image>();
        _player = FindObjectOfType<Player>();

    }

    void Update()
    {
        _curMana = Player.mana;
        _manaBar.fillAmount = _curMana / _maxMana;
    }

}
