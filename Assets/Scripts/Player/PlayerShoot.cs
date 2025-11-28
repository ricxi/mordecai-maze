using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public Transform gunpoint;
    public Gun gun;

    void Update()
    {
        float xInput = Input.GetAxisRaw("Horizontal");
        if (xInput != 0)
            gun.Aim(new Vector2(xInput, gunpoint.right.y));

        if (Input.GetButtonDown("Fire1"))
            gun.Fire();
    }

}
