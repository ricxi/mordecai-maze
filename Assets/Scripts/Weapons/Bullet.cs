using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector2 direction = new Vector2(-1, 0);
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private GameObject impactFxPrefab; // animation for bullet impact effect on collision
    [SerializeField] private float lifespan = 3;
    [SerializeField] private float speed = 20;
    [SerializeField] private int damage = 1;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = direction * speed;
        Destroy(gameObject, lifespan);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        IDamageable item = collision.gameObject.GetComponent<IDamageable>();
        item?.TakeDamage(damage);

        GameObject impactFx = Instantiate(impactFxPrefab, transform.position, Quaternion.identity);
        Destroy(impactFx, 0.7f);
        Destroy(gameObject);
    }
}