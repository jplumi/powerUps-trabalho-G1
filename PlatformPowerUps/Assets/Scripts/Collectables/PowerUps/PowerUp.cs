using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUp : MonoBehaviour
{
    [Header("Sound")]
    [SerializeField] private AudioClip _collectedSound;
    [Range(0, 1)] [SerializeField] private float _soundVolume;

    private AudioSource _audioSource;

    void Start()
    {
        _audioSource = GameManager.instance.GetComponent<AudioSource>();
    }

    public abstract void PowerUpAction(Collider2D playerCollision);

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _audioSource.PlayOneShot(_collectedSound, _soundVolume);
            PowerUpAction(collision);
            Destroy(gameObject);
        }
    }
}
