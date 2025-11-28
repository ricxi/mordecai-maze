using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    // [SerializeField] private Weapon currentWeapon;
    [SerializeField] private Gun currentWeapon;
    [SerializeField] private Transform gunpoint;
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private Vector2 aimDirection = Vector2.right;


    private void Start()
    {
        // or should I use Awake()?
        // if (currentWeapon)
        // {
        // currentWeapon.Gunpoint = gunpoint;
        // }

    }

    // private void Update()
    // {
    // }


    // public void Fire()
    // {
    //     Bullet bullet = Instantiate(bulletPrefab, gunpoint.position, Quaternion.identity);
    //     bullet.direction = aimDirection;
    // }


    // public void SwitchWeapon(Gun weaponPrefab)
    // {
    //     currentWeapon = weaponPrefab;
    // }

    // public void ResetToBaseWeapon()
    // {
    //     currentWeapon = baseWeapon;
    // }
}
