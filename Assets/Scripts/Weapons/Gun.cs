using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private Transform gunpoint;

    private Vector2 aimDirection;

    void Awake()
    {
        aimDirection = new Vector2(-1 * gunpoint.right.x, gunpoint.right.y); // default to left because of sprite
    }

    public void Aim(Vector2 _aimDirection)
    {
        aimDirection = _aimDirection;
    }

    public void Fire()
    {
        Bullet bullet = Instantiate(bulletPrefab, gunpoint.position, Quaternion.identity);
        bullet.direction = aimDirection;
    }
}
