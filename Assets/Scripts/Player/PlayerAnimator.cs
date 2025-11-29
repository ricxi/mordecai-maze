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
    private static readonly int ShootLeft = Animator.StringToHash("Shoot_Left");
    private static readonly int ShootRight = Animator.StringToHash("Shoot_Right");
    private static readonly int ShootFront = Animator.StringToHash("Shoot_Front");
    private static readonly int ShootBack = Animator.StringToHash("Shoot_Back");

    [SerializeField] private Animator animator;
    private int _currentState; // Animator defaults to Idle_Left
    private int _prevState; // Used by non-movement or non-idle states
    private float _xInput;
    private float _yInput;
    private bool _isFiring;
    private Coroutine _playStateAndWaitCoHandler;

    void Start()
    {
        if (animator == null) animator = GetComponent<Animator>();
    }

    void Update()
    {
        GetInput();
        if (!_isFiring) Move(); // Don't move if is firing? !isFiring
        Shoot();
    }

    private void GetInput()
    {
        _xInput = Input.GetAxis("Horizontal");
        _yInput = Input.GetAxis("Vertical");
        _isFiring = Input.GetButtonDown("Fire1");
    }

    void ChangeAnimationState(int newState)
    {
        if (_currentState == newState) return;

        animator.Play(newState);
        _currentState = newState;
    }

    private void Move()
    {
        if (_isFiring) return;

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

    private void Shoot()
    {
        if (!_isFiring) return;

        if (_currentState == WalkLeft || _currentState == IdleLeft)
        {
            _prevState = _currentState;
            ChangeAnimationState(ShootLeft); // OnShootFinished is called by animation behaviour right after
        }
        else if (_currentState == WalkRight || _currentState == IdleRight)
        {
            _prevState = _currentState;
            ChangeAnimationState(ShootRight);// OnShootFinished is called by animation behaviour right after
        }
        else if (_currentState == WalkFront || _currentState == IdleFront)
        {
            _prevState = _currentState;
            ChangeAnimationState(ShootFront);// OnShootFinished is called by animation behaviour right after
        }
        else if (_currentState == WalkBack || _currentState == IdleBack)
        {
            _prevState = _currentState;
            ChangeAnimationState(ShootBack);// OnShootFinished is called by animation behaviour right after
        }
    }


    // Called by behaviours of the animator: OnShootBackFinished, OnShootFrontFinished, OnShootLeftFinished, and OnShootRightFinished    
    // After shooting is finished, it sets the current state to the previous movement/idle statement and resumes movement.
    public void OnShootFinished(float duration)
    {
        if (duration > 0) StartCoroutine(Wait());
        IEnumerator Wait()
        {
            yield return new WaitForSeconds(duration);
            ChangeAnimationState(_prevState);
            Move();
        }
    }

}
