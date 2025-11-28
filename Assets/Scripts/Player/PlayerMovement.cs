using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed = 7;
    [SerializeField] private float sprintSpeed = 20;


    private string _currentState;
    private float _xInput;
    private float _yInput;
    private bool _isSprinting;
    private RigidbodyConstraints2D _baselineContraints;

    // Names of Animation States
    const string PLAYER_IDLE = "Idle";
    const string PLAYER_RUN = "Run";

    void Start()
    {
        // rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        GetInput();
        Flip();
        Animate();
    }

    void FixedUpdate()
    {
        Move();
    }

    void ChangeAnimationState(string newState)
    {
        if (_currentState == newState) return;

        animator.Play(newState);
        _currentState = newState;
    }

    private void GetInput()
    {
        _xInput = Input.GetAxis("Horizontal");
        _yInput = Input.GetAxis("Vertical");
        _isSprinting = Input.GetKey(KeyCode.LeftShift);
    }

    private void Move()
    {
        float currentSpeed = _isSprinting ? sprintSpeed : speed;
        Vector2 direction = new Vector2(_xInput, _yInput).normalized;
        rb.velocity = direction * currentSpeed;

    }

    private void Flip()
    {
        if (_xInput > 0 && transform.localScale.x > 0 || _xInput < 0 && transform.localScale.x < 0)
        {
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }
    }

    public IEnumerator Freeze(float duration)
    {
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        yield return new WaitForSeconds(duration);
        rb.constraints = _baselineContraints;
    }

    private void Animate()
    {
        if (_xInput != 0)
            ChangeAnimationState(PLAYER_RUN);
        else if (_yInput != 0)
            ChangeAnimationState(PLAYER_RUN);
        else
            ChangeAnimationState(PLAYER_IDLE);
    }
}
