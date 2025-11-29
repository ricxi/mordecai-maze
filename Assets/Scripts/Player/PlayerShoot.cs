using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public AudioClip gunshotClip;
    public Transform gunpoint;
    public Gun gun;
    private float _xInput;
    private float _yInput;
    private bool _isFiring;

    void Update()
    {
        GetInput();

        Vector2 direction = new Vector2(_xInput, _yInput);
        if (direction != Vector2.zero)
        {
            Vector3 vec3 = Vector3.left * _xInput + Vector3.down * _yInput;
            gunpoint.rotation = Quaternion.LookRotation(Vector3.forward, vec3);
            Vector2 aimDirection = direction;
            gun.Aim(aimDirection);
        }

        if (_isFiring)
        {
            SoundManager.Instance.PlayOne(gunshotClip);
            gun.Fire();
        }
    }

    private void GetInput()
    {
        _xInput = Input.GetAxisRaw("Horizontal");
        _yInput = Input.GetAxisRaw("Vertical");
        _isFiring = Input.GetButtonDown("Fire1");
    }
}
