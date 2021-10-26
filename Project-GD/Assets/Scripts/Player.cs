using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    PlayerControls controls;
    public Animator _animator;

    Vector2 move;
    Vector2 rotate;
    public float playerSpeed = 5f;
    private float keyboardMove;

    private void Awake() {
        controls = new PlayerControls();

        controls.Gameplay.Move.performed += context => move = context.ReadValue<Vector2>();
        controls.Gameplay.Move.canceled += context => move = Vector2.zero;

        controls.Gameplay.Look.performed += context => rotate = context.ReadValue<Vector2>();
        controls.Gameplay.Look.canceled += context => rotate = Vector2.zero;

        controls.Gameplay.WASD.performed += context => move = context.ReadValue<Vector2>();
        controls.Gameplay.WASD.canceled += context => rotate = Vector2.zero;

        //Example for button push
        //controls.Gameplay.hit.performed += context => hit();
    }

    private void Update() {
        Vector2 m = new Vector2(move.x, move.y) * Time.deltaTime;

        _animator.SetFloat("x", m.x);
        _animator.SetFloat("y", m.y);
        _animator.SetFloat("Speed", m.sqrMagnitude*1000);

        transform.Translate(m, Space.World);

        Vector3 r = new Vector3(0f, 0f, -rotate.x) * 100 * Time.deltaTime;

        transform.Rotate(r, Space.World);
    }

    private void OnEnable() {
        controls.Gameplay.Enable();
    }


    private void OnDisable() {
        controls.Gameplay.Disable();
    }
}

