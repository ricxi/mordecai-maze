using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, IDamageable
{
    [SerializeField] private AudioClip explosionClip;
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private Sprite damagedSprite;
    [SerializeField] private GameObject explosionPrefab; // animation for bullet impact effect on collision
    [SerializeField] private GameObject itemDropPrefab;
    [SerializeField] private int maxHealth = 10;

    private int _currentHealth;
    private bool _isDamaged = false;
    private bool _isDestroyed = false;

    private void Start()
    {
        if (sr == null) sr = GetComponent<SpriteRenderer>();

        _currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (!_isDestroyed)
        {
            _currentHealth -= damage;

            if (!_isDamaged && _currentHealth <= 5)
            {
                _isDamaged = true;
                sr.sprite = damagedSprite;
            }

            if (_currentHealth <= 0)
            {
                _isDestroyed = true;

                SoundManager.Instance.PlayOneShot(explosionClip);
                GameObject explosionFx = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
                Destroy(explosionFx, 0.7f);

                if (itemDropPrefab) Instantiate(itemDropPrefab, transform.position, Quaternion.identity);

                Destroy(gameObject);
            }
        }
    }
}
