using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private static readonly int IdleLeft = Animator.StringToHash("Idle_Left");
    private static readonly int IdleRight = Animator.StringToHash("Idle_Right");
    private static readonly int IdleFront = Animator.StringToHash("Idle_Front");
    private static readonly int IdleBack = Animator.StringToHash("Idle_Back");
    private static readonly int WalkLeft = Animator.StringToHash("Walk_Left");
    private static readonly int WalkRight = Animator.StringToHash("Walk_Right");
    private static readonly int WalkFront = Animator.StringToHash("Walk_Front");
    private static readonly int WalkBack = Animator.StringToHash("Walk_Back");

    [SerializeField] private Animator animator;
    private int _currentState; // Animator defaults to Idle_Left
    private float _xInput;
    private float _yInput;

    void Start()
    {
        if (animator == null) animator = GetComponent<Animator>();
    }

    void Update()
    {
        GetInput();
        Move();
    }

    private void GetInput()
    {
        _xInput = Input.GetAxis("Horizontal");
        _yInput = Input.GetAxis("Vertical");
    }

    void ChangeAnimationState(int newState)
    {
        if (_currentState == newState) return;

        animator.Play(newState);
        _currentState = newState;
    }

    private void Move()
    {
        if (_xInput > 0) ChangeAnimationState(WalkRight);
        else if (_xInput < 0) ChangeAnimationState(WalkLeft);
        else if (_yInput > 0) ChangeAnimationState(WalkBack);
        else if (_yInput < 0) ChangeAnimationState(WalkFront);
        else Idle();
    }

    private void Idle()
    {
        if (_currentState == WalkLeft) ChangeAnimationState(IdleLeft);
        else if (_currentState == WalkRight) ChangeAnimationState(IdleRight);
        else if (_currentState == WalkFront) ChangeAnimationState(IdleFront);
        else if (_currentState == WalkBack) ChangeAnimationState(IdleBack);
    }
}
