using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed = 7;
    [SerializeField] private float sprintSpeed = 20;

    private float _xInput;
    private float _yInput;
    private bool _isSprinting;
    private RigidbodyConstraints2D _baselineContraints;

    void Start()
    {
        // rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        GetInput();
    }

    void FixedUpdate()
    {
        Move();
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

    public IEnumerator Freeze(float duration)
    {
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        yield return new WaitForSeconds(duration);
        rb.constraints = _baselineContraints;
    }
}

